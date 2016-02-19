namespace JustAsk.Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Idea;
    using System.Linq;
    public class SearchController : BaseController
    {
        private IIdeasServices ideas;

        public SearchController(IIdeasServices ideas)
        {
            this.ideas = ideas;
        }

        public ActionResult Search()
        {
            var ideas = this.ideas.FindByTitle(this.Request.QueryString["q"]).To<IdeaViewModel>().ToList();

            var viewModel = new IdeaHomeViewModel()
            {
                CurrentPage = 1,
                TotalPages = 1,
                Ideas = ideas
            };

            return this.View("~/Views/Home/Index.cshtml", viewModel);
        }
    }
}
