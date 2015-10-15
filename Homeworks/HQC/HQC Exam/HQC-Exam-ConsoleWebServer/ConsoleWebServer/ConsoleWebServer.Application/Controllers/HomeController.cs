namespace ConsoleWebServer.Application.Controllers
{
    using Framework;
    using Framework.ActionResults.ContentActions;

    public class HomeController : Controller
    {
        private const string HomePageSmile = "Home page :)";
        private const string LivePageWithNoCaching = "Live page with no caching";
        private const string LivePageWithNoCachingAndCORS = "Live page with no caching and CORS";

        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content(HomePageSmile);
        }

        public IActionResult LivePage(string param)
        {
            return new WithoutCaching(new ContentActionResult(this.Request, LivePageWithNoCaching));
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new WithCors("*", new WithoutCaching(new ContentActionResult(this.Request, LivePageWithNoCachingAndCORS)));
        }

        public IActionResult Forum(string param)
        {
            // TODO asdasd
            return new ContentActionResult(this.Request, string.Empty);
        }
    }
}
