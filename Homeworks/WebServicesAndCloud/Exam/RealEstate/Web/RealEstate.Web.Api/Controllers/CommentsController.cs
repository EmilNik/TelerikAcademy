namespace RealEstate.Web.Api.Controllers
{
    using Infrastructure;
    using Data.Models;
    using Services.Data;
    using System.Web.Http;
    using Models.Comments;

    [Authorize]
    public class CommentsController : ApiController
    {
        private readonly ICommentService comments;
        private IUserIdProvider userIdProvider;

        public CommentsController(IUserIdProvider idProvider, ICommentService comments)
        {
            this.comments = comments;
            this.userIdProvider = idProvider;
        }

        public IHttpActionResult Get(int id, int skip = 0, int take = 10)
        {
            var comments = this.comments.GetAllCommentsForRealEstate(id, skip, take);

            if (comments == null)
            {
                return this.NotFound();
            }
            return this.Ok(comments);
        }

        [Route("api/Comments/ByUser/{id}")]
        public IHttpActionResult Get(string id)
        {
            var comments = this.comments.GetCommentsForSpecificUser(id);
            return this.Ok(comments);
        }

        public IHttpActionResult Post(CreateCommentRequestModel model)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (model == null)
            {
                return this.BadRequest();
            }

            var newComment = this.comments.AddCommentToSpecificPost
                (
                model.RealEstateId,
                model.Content,
                currentUserId
                );

            return this.Ok(new ListCommentRequestModel
            {
                Content = newComment.Content,
                CreatedOn = newComment.DateCreated,
                UserId = newComment.UserId
            });
        }
    }
}