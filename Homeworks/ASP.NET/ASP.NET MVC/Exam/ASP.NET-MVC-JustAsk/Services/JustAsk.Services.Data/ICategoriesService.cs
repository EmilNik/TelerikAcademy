namespace JustAsk.Services.Data
{
    using System.Linq;

    using JustAsk.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
