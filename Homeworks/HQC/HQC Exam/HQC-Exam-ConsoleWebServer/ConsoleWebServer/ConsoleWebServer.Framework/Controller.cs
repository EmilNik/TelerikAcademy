﻿using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.ActionResults.ContentActions;

namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        public HttpRequest Request { get; private set; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResult(this.Request, model);
        }

        protected Controller(HttpRequest request)
        {
            this.Request = request;
        }
    }
}
