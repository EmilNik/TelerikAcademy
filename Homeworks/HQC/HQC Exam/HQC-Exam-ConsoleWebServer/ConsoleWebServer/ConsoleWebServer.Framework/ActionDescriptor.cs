namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;

    public class ActionDescriptor
    {
        private const string HomeStringFormat = "Home";
        private const string IndexStringFormat = "Index";
        private const string ToStringFormat = "/{0}/{1}/{2}";

        public ActionDescriptor(string uri)
        {
            var uriParts = uri.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ControllerName = uriParts.Length > 0 ? uriParts[0] : "Home";
            this.ActionName = uriParts.Length > 1 ? uriParts[1] : "Index";
            this.Parameter = uriParts.Length > 2 ? uriParts[2] : string.Empty;
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public string Parameter { get; private set; }

        public override string ToString()
        {
            return string.Format(ToStringFormat, this.ControllerName, this.ActionName, this.Parameter);
        }
    }
}
