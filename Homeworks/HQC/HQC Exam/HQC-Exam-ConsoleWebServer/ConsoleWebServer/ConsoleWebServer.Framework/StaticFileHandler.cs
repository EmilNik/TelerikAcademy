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

            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, FileNotFound);
            }

            string fileContents = File.ReadAllText(filePath);

            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);

            return response;
        }

        private bool FileExists(string path, string filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var filePaths = Directory.GetFiles(path);

                if (filePaths.Contains(filePath))
                {
                    return true;
                }

                var directoryPaths = Directory.GetDirectories(path);

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
