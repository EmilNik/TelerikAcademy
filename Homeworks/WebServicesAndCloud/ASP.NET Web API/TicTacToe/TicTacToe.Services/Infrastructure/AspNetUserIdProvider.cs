namespace TicTacToe.Services.Infrastructure
{
    using System.Security.Principal;
    using Microsoft.AspNet.Identity;
    using System.Threading;

    public class AspNetUserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}