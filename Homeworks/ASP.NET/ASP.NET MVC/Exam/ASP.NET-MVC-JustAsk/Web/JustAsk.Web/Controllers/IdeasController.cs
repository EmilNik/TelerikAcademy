namespace JustAsk.Web.Controllers
{
    using System.Web.Mvc;
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
    }
}