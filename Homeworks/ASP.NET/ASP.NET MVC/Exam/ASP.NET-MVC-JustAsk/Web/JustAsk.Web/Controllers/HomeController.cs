namespace JustAsk.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Idea;

    public class HomeController : BaseController
    {
        private IIdeasServices ideas;

        public HomeController(IIdeasServices ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            IdeaHomeViewModel viewModel;
            if (this.HttpContext.Cache["Home_page_" + id] != null)
            {
                viewModel = (IdeaHomeViewModel)this.HttpContext.Cache["Home_page_" + id];
            }
            else
            {
                var page = id;
                var allItemsCount = this.ideas.Count();
                var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)GlobalConstants.IdeasPerPage);

                if (page > totalPages)
                {
                    page = totalPages;
                }

                var itemsToSkip = (page - 1) * GlobalConstants.IdeasPerPage;
                var allIdeas = this.ideas.GetIdeas(itemsToSkip, GlobalConstants.IdeasPerPage).To<IdeaViewModel>().ToList();

                viewModel = new IdeaHomeViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Ideas = allIdeas
                };

                this.HttpContext.Cache["Home_page_" + id] = viewModel;
            }

            return this.View(viewModel);
        }
    }
}
