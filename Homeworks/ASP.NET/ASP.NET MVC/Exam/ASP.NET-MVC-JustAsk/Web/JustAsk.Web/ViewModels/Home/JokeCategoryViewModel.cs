namespace JustAsk.Web.ViewModels.Home
{
    using JustAsk.Data.Models;
    using JustAsk.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
