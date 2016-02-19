namespace JustAsk.Web.Views.Comments
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Data;

    public class CommentsListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Comment> comments = this.db.Comments;
            DataSourceResult result = comments.ToDataSourceResult(request, comment => new
            {
                Id = comment.Id,
                Content = comment.Content,
                AuthorEmail = comment.AuthorEmail,
                AuthorId = comment.AuthorId,
                CreatedOn = comment.CreatedOn,
                ModifiedOn = comment.ModifiedOn,
                IsDeleted = comment.IsDeleted,
                DeletedOn = comment.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    AuthorEmail = comment.AuthorEmail,
                    AuthorId = comment.AuthorId,
                    CreatedOn = comment.CreatedOn,
                    ModifiedOn = comment.ModifiedOn,
                    IsDeleted = comment.IsDeleted,
                    DeletedOn = comment.DeletedOn
                };

                this.db.Comments.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    AuthorEmail = comment.AuthorEmail,
                    AuthorId = comment.AuthorId,
                    CreatedOn = comment.CreatedOn,
                    ModifiedOn = comment.ModifiedOn,
                    IsDeleted = comment.IsDeleted,
                    DeletedOn = comment.DeletedOn
                };

                this.db.Comments.Attach(entity);
                this.db.Comments.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
