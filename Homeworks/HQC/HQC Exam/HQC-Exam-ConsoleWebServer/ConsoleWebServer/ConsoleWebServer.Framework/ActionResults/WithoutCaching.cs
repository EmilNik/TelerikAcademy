namespace ConsoleWebServer.Framework.ActionResults.ContentActions
{
    using System.Collections.Generic;

    public class WithoutCaching : Decorator
    {
        public WithoutCaching(IActionResult actionResult) 
            : base(actionResult)
        {
            actionResult.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}
