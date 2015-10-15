﻿namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Net;

    public class StaticFileHandler
    {
        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal) > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Uri;

            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found!");
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

                foreach (var directoryPath in directoryPaths)
                {
                    if (FileExists(directoryPath, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
