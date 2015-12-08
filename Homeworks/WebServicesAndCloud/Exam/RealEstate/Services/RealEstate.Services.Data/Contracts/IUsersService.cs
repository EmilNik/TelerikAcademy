using System.Linq;
using RealEstate.Data.Models;

namespace RealEstate.Services.Data.Contracts
{
    public interface IUsersService
    {
        IQueryable<Comment> GetAllCommentsForSpecificUser(string userId);
        IQueryable<User> GetAllUsers();
        User GetUserByUsername(string username);
        IQueryable<Rating> GetAllRaitingsForSpecificUser(string userId);
        Rating RateUser(string userId, int value);
    }
}