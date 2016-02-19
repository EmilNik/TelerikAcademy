namespace JustAsk.Services.Data
{
    using System.Linq;

    using JustAsk.Data.Common;
    using JustAsk.Data.Models;
    using Web;

    public class IdeasServices : IIdeasServices
    {
        private readonly IRepository<Idea> ideas;
        private readonly IIdentifierProvider identifierProvider;

        public IdeasServices(IRepository<Idea> ideas, IIdentifierProvider identifierProvider)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
        }

        public Idea GetById(int id)
        {
            var idea = this.ideas.GetById(id);
            return idea;
        }

        public IQueryable<Idea> GetIdeas(int skip, int count)
        {
            return this.ideas.All()
                .OrderByDescending(x => x.TotalVotes)
                .ThenBy(x => x.Id)
                .Skip(skip)
                .Take(count);
        }

        public IQueryable<Idea> FindByTitle(string title)
        {
            return this.ideas.All()
                .Where(x => x.Title.Contains(title) || x.Description.Contains(title));
        }

        public int Count()
        {
            return this.ideas.All().Count();
        }

        public Idea Add(Idea idea)
        {
            this.ideas.Add(idea);
            this.ideas.Save();
            return idea;
        }
    }
}
