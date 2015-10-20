namespace ConsoleWebServer.Framework
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class StaticFileHandler
    {
        private const string FileNotFound = "File not found!";

        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal) > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Uri;

            if (!this.FileExists(filePath))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, FileNotFound);
            }

            string fileContents = File.ReadAllText(filePath);

            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);

            return response;
        }

        private bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
