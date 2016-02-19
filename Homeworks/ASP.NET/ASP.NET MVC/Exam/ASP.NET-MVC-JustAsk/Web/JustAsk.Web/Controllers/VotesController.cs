namespace JustAsk.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class VotesController : BaseController
    {
        private IRepository<Vote> votes;

        public VotesController(IRepository<Vote> votes)
        {
            this.votes = votes;
        }

        [HttpPost]
        public ActionResult Vote(int postId, int voteType)
        {
            var userId = this.User.Identity.GetUserId();
            var vote = this.votes.All().FirstOrDefault(x => x.AuthorId == userId && x.IdeaId == postId);

            if (vote == null)
            {
                vote = new Vote
                {
                    AuthorId = userId,
                    IdeaId = postId,
                    Value = (VoteType)voteType
                };
                this.votes.Add(vote);
            }
            else
            {
            }

            this.votes.Save();
            var postVotes = this.votes
                .All()
                .Where(x => x.IdeaId == postId)
                .Sum(x => (int)x.Value);

            return this.Json(new { Count = postVotes });
        }
    }
}
