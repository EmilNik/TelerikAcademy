namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;

    public class JsonActionResult : ActionResult
    {
        public JsonActionResult(HttpRequest request, object model) 
            : base(request, model)
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), HighQualityCodeExamPointsProvider.GetContentType());

            return this.ReturnResponse(response);
        }
    }
}
