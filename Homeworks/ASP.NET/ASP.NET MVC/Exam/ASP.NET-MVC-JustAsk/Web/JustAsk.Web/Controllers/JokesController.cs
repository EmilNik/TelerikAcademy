namespace JustAsk.Web.Controllers
{
    using System.Web.Mvc;

    using JustAsk.Services.Data;
    using JustAsk.Web.Infrastructure.Mapping;
    using JustAsk.Web.ViewModels.Home;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;

        public JokesController(
            IJokesService jokes)
        {
            this.jokes = jokes;
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }
    }
}
