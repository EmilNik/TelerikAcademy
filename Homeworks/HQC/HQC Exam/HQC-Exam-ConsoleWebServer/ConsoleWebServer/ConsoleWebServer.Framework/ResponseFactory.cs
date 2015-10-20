namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Exceptions;

    public class ResponseFactory : IResponseFactory
    {
        private List<string> routes;

        public HttpResponse CreateResponse(HttpRequest request)
        {
            if (request.Method.ToLower() == "head")
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, new List<string>()));
            }
            else if (request.Method.ToLower() == "options")
            {
                if (this.routes == null)
                {
                    this.routes = this.GetRoutes();
                }

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, this.routes));
            }
            else if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }
            else if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;

                try
                {
                    Controller controller = this.CreateController(request);
                    ActionInvoker actionInvoker = new ActionInvoker();
                    IActionResult actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFoundException exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                return response;
            }
            else
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));

            if (type == null)
            {
                throw new HttpNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);

            return instance;
        }

        private List<string> GetRoutes()
        {
            return Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                        .Select(
                            x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(
                            x =>
                            x.Methods.Select(
                                m =>
                                string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                        .ToList();
        }
    }
}
