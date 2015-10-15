namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class HttpResponse
    {
        private const string ConsoleWebServerStringFormat = "ConsoleWebServer";
        private const string ServerNameStringFormat = "Server";
        private const string ContentLengthStringFormat = "Content-Length";
        private const string ContentTypeStringFormat = "Content-Type";
        private const string HTTPSlashStringFormat = "HTTP/";
        private const string StringBuilderLineToAppendStringFormat = "{0}{1} {2} {3}";
        private const string StringBuilderSecondLineToAppendStringFormat = "{0}: {1}";
        private const string HttpResponseContentType = "text/plain; charset=utf-8";

        private string ServerEngineName;

        public HttpResponse(Version httpVersion, HttpStatusCode statusCode, string body, string contentType = HttpResponseContentType)
        {
            this.ServerEngineName = ConsoleWebServerStringFormat;
            this.ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower());
            this.Headers = new SortedDictionary<string, ICollection<string>>();
            this.Body = body;
            this.StatusCode = statusCode;
            this.AddHeader(ServerNameStringFormat, this.ServerEngineName);
            this.AddHeader(ContentLengthStringFormat, body.Length.ToString());
            this.AddHeader(ContentTypeStringFormat, contentType);
        }

        public Version ProtocolVersion { get; protected set; }

        public IDictionary<string, ICollection<string>> Headers { get; protected set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string Body { get; private set; }

        public string StatusCodeAsString
        {
            get
            {
                return this.StatusCode.ToString();
            }
        }

        public void AddHeader(string name, string value)
        {
            if (!this.Headers.ContainsKey(name))
            {
                this.Headers.Add(name, new HashSet<string>());
            }

            this.Headers[name].Add(value);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(StringBuilderLineToAppendStringFormat, HTTPSlashStringFormat, this.ProtocolVersion, (int)this.StatusCode, this.StatusCodeAsString));
            var headerStringBuilder = new StringBuilder();

            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format(StringBuilderSecondLineToAppendStringFormat, key, string.Join("; ", this.Headers[key])));
            }

            stringBuilder.AppendLine(headerStringBuilder.ToString());

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                stringBuilder.AppendLine(this.Body);
            }

            return stringBuilder.ToString();
        }
    }
}
