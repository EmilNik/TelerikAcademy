namespace ConsoleWebServer.Application.Controllers
{
    using Framework.ActionResults.ContentActions;
    using Framework;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            return new WithoutCaching(new ContentActionResult(this.Request, "Live page with no caching"));
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new WithCors("*", new WithoutCaching(new ContentActionResult(this.Request, "Live page with no caching and CORS")));
        }

        public IActionResult Forum(string param)
        {
            // TODO asdasd
            return null;
        }
    }
}
