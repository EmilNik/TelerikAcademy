namespace JustAsk.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Models;
    using Services.Data;
    using ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private ICommentsService comments;
        private IIdeasServices ideas;

        public CommentsController(ICommentsService comments, IIdeasServices ideas)
        {
            this.comments = comments;
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult AddComment()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var comment = new Comment()
            {
                AuthorEmail = model.AuthorEmail,
                Content = model.Content,
                AuthorId = this.HttpContext.Request.UserHostAddress,
                Idea = this.ideas.GetById(model.IdeaId)
            };

            this.comments.Add(comment);

            this.TempData["Notification"] = "Your comment was added!";
            return this.Redirect("/Ideas/Index/" + model.IdeaId);
        }
    }
}
