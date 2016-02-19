namespace JustAsk.Web.App_Start
{
    using System.Web.Mvc;
    using Common;

    public class IKnowEverythingFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add(GlobalConstants.CreepyMessage, filterContext.HttpContext.Request.UserHostAddress);
            base.OnActionExecuting(filterContext);
        }
    }
}
