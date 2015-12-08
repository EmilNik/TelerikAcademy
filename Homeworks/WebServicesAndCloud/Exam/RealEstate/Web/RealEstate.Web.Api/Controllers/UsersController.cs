namespace RealEstate.Web.Api.Controllers
{
    using Models.Users;
    using Infrastructure;
    using System.Web.Http;
    using Services.Data.Contracts;

    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUsersService users;
        private IUserIdProvider userIdProvider;

        public UsersController(IUserIdProvider idProvider, IUsersService users)
        {
            this.userIdProvider = idProvider;
            this.users = users;
        }

        [HttpPost]
        [Route("api/User/Rate")]
        public IHttpActionResult RateUser(RateUserRequestModel model)
        {
            this.users.RateUser
                (
                model.UserId,
                model.Value
                );

            return this.Ok();
        }

        [HttpGet]
        //[Route("api/Users/{username}")]
        public IHttpActionResult GetUserByUsername(string username)
        {
            var user = users.GetUserByUsername(username);

            var result = user
                .ProjectTo<ListUserRequestModel>();

            return this.Ok(result);
        }
    }
}