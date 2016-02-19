namespace JustAsk.Web
{
    using System.Web.Mvc;
    using App_Start;

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new IKnowEverythingFilter());
        }
    }
}
