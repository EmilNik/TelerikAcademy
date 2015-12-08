using System.Linq;
using RealEstate.Data.Models;

namespace RealEstate.Services.Data
{
    public interface ICommentService
    {
        Comment AddCommentToSpecificPost(int realEstateId, string content, string userId);
        IQueryable<Comment> GetAllCommentsForRealEstate(int id, int skip = 0, int take = 10);
        IQueryable<Comment> GetCommentsForSpecificUser(string userId, int skip = 0, int take = 10);
        Comment GetLastComment();
    }
}