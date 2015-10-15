using System;

namespace ConsoleWebServer.Framework
{
    public class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }

        internal object InvokeAction(object controller, ActionDescriptor action)
        {
            throw new NotImplementedException();
        }
    }
}
