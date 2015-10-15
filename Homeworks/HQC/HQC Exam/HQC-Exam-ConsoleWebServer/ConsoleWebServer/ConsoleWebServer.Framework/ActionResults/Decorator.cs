namespace ConsoleWebServer.Framework.ActionResults.ContentActions
{
    using System;
    using System.Collections.Generic;

    public abstract class Decorator : IActionResult
    {
        protected Decorator(IActionResult actionResult)
        {
            this.ActionResult = actionResult;
        }
        
        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        protected IActionResult ActionResult { get; set; }

        public HttpResponse GetResponse()
        {
            return this.ActionResult.GetResponse();
        }

        public HttpResponse GetResponse(HttpResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
