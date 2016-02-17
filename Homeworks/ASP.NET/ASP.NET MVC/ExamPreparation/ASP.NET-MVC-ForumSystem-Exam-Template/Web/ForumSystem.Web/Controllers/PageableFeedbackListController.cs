namespace ForumSystem.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.Common.Repository;
    using Data.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Feedback;

    [Authorize]
    public class PageableFeedbackListController : Controller
    {
        private IDeletableEntityRepository<Feedback> feedback;
        private const int ItemsPerPage = 4;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedback)
        {
            this.feedback = feedback;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            FeedbackListViewModel viewModel;
            if (this.HttpContext.Cache["Feedback_page_" + id] != null)
            {
                viewModel = (FeedbackListViewModel)this.HttpContext.Cache["Feedback_page_" + id];
            }
            else
            {

                var page = id;
                var allItemsCount = this.feedback.All().Count();
                var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                var itemsToSkip = (page - 1) * ItemsPerPage;
                var feedbacks = this.feedback.All()
                    .OrderByDescending(x => x.CreatedOn)
                    .ThenBy(x => x.Id)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .Project().To<FeedbackViewModel>()
                    .ToList();

                viewModel = new FeedbackListViewModel
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Feedbacks = feedbacks
                };

                this.HttpContext.Cache["Feedback_page_" + id] = viewModel;
            }

            return this.View(viewModel);
        }
    }
}