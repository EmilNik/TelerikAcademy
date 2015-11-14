namespace TicTacToe.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public abstract class BaseApiController : ApiController
    {
        protected ITicTacToeData data;

        protected BaseApiController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}