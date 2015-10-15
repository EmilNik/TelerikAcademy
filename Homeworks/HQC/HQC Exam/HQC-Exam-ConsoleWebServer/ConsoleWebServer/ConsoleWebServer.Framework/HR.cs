namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;

    public class HttpResponse
    {
        private string ServerEngineName;

        public HttpResponse(Version httpVersion, HttpStatusCode statusCode, string body, string contentType = "text/plain; charset=utf-8")
        {
            this.ServerEngineName = "ConsoleWebServer";
            this.ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower().Replace("HTTP/".ToLower(), string.Empty));
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Body = body;
            this.StatusCode = statusCode;
            this.AddHeader("Server", ServerEngineName);
            this.AddHeader("Content-Length", body.Length.ToString());
            this.AddHeader("Content-Type", contentType);
        }

        public Version ProtocolVersion { get; protected set; }

        public IDictionary<string, ICollection<string>> Headers { get; protected set; }

        public void AddHeader(string name, string value)
        {
            if (!Headers.ContainsKey(name))
            {
                Headers.Add(name, new HashSet<string>());
            }

            Headers[name].Add(value);
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string Body { get; private set; }

        public string StatusCodeAsString
        {
            get
            {
                return this.StatusCode.ToString();
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("{0}{1} {2} {3}", "HTTP/", ProtocolVersion, (int)StatusCode, StatusCodeAsString));
            var headerStringBuilder = new StringBuilder();

            foreach (var key in Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", Headers[key])));
            }

            stringBuilder.AppendLine(headerStringBuilder.ToString());

            if (!string.IsNullOrWhiteSpace(Body))
            {
                stringBuilder.AppendLine(Body);
            }

            return stringBuilder.ToString();
        }
    }
}
