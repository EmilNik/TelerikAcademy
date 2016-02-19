namespace JustAsk.Services.Data
{
    using JustAsk.Data.Common;
    using JustAsk.Data.Models;
    using Web;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> ideas;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsService(IRepository<Comment> ideas, IIdentifierProvider identifierProvider)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Comment comment)
        {
            this.ideas.Add(comment);
            this.ideas.Save();
        }
    }
}
