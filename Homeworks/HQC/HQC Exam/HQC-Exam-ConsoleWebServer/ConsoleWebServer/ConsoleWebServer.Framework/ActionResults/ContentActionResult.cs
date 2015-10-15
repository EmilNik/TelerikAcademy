namespace ConsoleWebServer.Framework.ActionResults.ContentActions
{
    using System.Collections.Generic;
    using System.Net;

    public class ContentActionResult : ActionResult
    {
        public ContentActionResult(HttpRequest request, object model)
            : base(request, model)
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.Model.ToString(), "text/plain; charset=utf-8");

            return this.ReturnResponse(response);
        }
    }
}
