namespace JustAsk.Services.Data
{
    using System.Linq;
    using JustAsk.Data.Models;

    public interface IIdeasServices
    {
        Idea GetById(int id);

        IQueryable<Idea> GetIdeas(int skip, int count);

        IQueryable<Idea> FindByTitle(string title);

        int Count();

        Idea Add(Idea idea);
    }
}
