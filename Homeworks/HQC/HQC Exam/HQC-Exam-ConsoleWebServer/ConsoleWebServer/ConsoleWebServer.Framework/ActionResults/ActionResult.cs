namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;

    public abstract class ActionResult : IActionResult
    {
        public readonly object Model;

        public ActionResult(HttpRequest request, object model)
        {
            this.Model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; set; }

        public abstract HttpResponse GetResponse();

        public HttpResponse ReturnResponse(HttpResponse response)
        {
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}
