using System;
using System.Web.Http;
using System.Web.Mvc;
using TicTacToe.Services.Areas.HelpPage.ModelDescriptions;
using TicTacToe.Services.Areas.HelpPage.Models;

namespace TicTacToe.Services.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();
            return View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = this.Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return this.View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = this.Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return this.View(modelDescription);
                }
            }

            return this.View(ErrorViewName);
        }
    }
}