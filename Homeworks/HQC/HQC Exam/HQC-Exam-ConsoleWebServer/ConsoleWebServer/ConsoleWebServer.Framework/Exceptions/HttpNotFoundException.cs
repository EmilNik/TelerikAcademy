namespace ConsoleWebServer.Framework.Exceptions
{
    using System;

    public class HttpNotFoundException : Exception
    { 
        public HttpNotFoundException(string message)
            : base(message)
        {
        }
    }
}
