namespace JustAsk.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using ViewModels.Idea;

    public class IdeasController : BaseController
    {
        private IIdeasServices ideas;

        public IdeasController(IIdeasServices ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var idea = this.ideas.GetById(id);

            var model = this.Mapper.Map<IdeaViewModel>(idea);
            return this.View(model);
        }

        [HttpGet]
        public ActionResult AddIdea()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddIdea(IdeaInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var idea = new Idea()
            {
                AuthorIP = this.HttpContext.Request.UserHostAddress,
                Description = model.Description,
                Title = model.Title
            };

            var newIdea = this.ideas.Add(idea);

            this.TempData["Notification"] = "Your Idea was added successfuly!";
            return this.Redirect("/");
        }
    }
}
