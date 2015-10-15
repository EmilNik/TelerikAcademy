namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using System.Linq;
    using Framework;
    using Framework.ActionResults;
    using Framework.ActionResults.ContentActions;

    public class ApiController : Controller
    {
        private const string RefererStringFormat = "Referer";
        private const string InvalidRefererStringFormat = "Invalid referer!";
        private const string DateAvailableForStringFormat = "Data available for ";
        private const string DateStringFormat = "yyyy-MM-dd";

        public ApiController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;

            if (this.Request.Headers.ContainsKey(RefererStringFormat))
            {
                requestReferer = this.Request.Headers[RefererStringFormat].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException(InvalidRefererStringFormat);
            }

            return new WithCors(domainName, new JsonActionResult(this.Request, new { date = DateTime.Now.ToString(DateStringFormat), moreInfo = DateAvailableForStringFormat + domainName }));
        }
    }
}
