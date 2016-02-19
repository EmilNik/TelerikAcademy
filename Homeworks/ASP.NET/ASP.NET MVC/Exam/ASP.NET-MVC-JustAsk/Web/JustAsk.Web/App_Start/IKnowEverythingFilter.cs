namespace JustAsk.Web.App_Start
{
    using Common;
    using System.Web.Mvc;

    public class IKnowEverythingFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add(GlobalConstants.CreepyMessage, filterContext.HttpContext.Request.UserHostAddress);
            base.OnActionExecuting(filterContext);
        }
    }
}
