namespace ConsoleWebServer.Framework.ActionResults.ContentActions
{
    using System.Collections.Generic;

    public class WithCors : Decorator
    {
        public WithCors(string corsSettings, IActionResult actionResult)
            : base(actionResult)
        {
            actionResult.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}
