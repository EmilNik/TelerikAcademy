namespace ConsoleWebServer.Framework
{
    using System;
    using System.Net;

    public class ResponseProvider
    {
        private IResponseFactory responseFactory;

        public ResponseProvider()
        {
            this.responseFactory = new ResponseFactory();
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;

            try
            {
                var requestParser = new HttpRequest("GET", "/", "1.1");
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.responseFactory.CreateResponse(request);

            return response;
        }
    }
}
