namespace RealEstate.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RealEstate.Data.Models;
    using RealEstate.Data.Repositories;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;
        private readonly IRealEstateService realEstates;

        public CommentService(IRepository<Comment> comments, IRealEstateService realEstates)
        {
            this.comments = comments;
            this.realEstates = realEstates;
        }

        public IQueryable<Comment> GetAllCommentsForRealEstate(int id, int skip, int take)
        {
            IQueryable<Comment> comments;
            try
            {
                comments = this.realEstates.GetRealEstateById(id).FirstOrDefault()
                    .Comments
                    .OrderBy(c => c.DateCreated)
                    .Skip(skip)
                    .Take(take).AsQueryable();
            }
            catch (Exception)
            {
                return null;
            }

            return comments;
        }

        public IQueryable<Comment> GetCommentsForSpecificUser(string userId, int skip, int take)
        {
            var comments = this.comments
                .All()
                .Where(c => c.UserId == userId);

            return comments;
        }

        public Comment AddCommentToSpecificPost(int realEstateId, string content, string userId)
        {
            var newComment = new Comment
            {
                Content = content,
                UserId = userId,
                RealEstateId = realEstateId,
                DateCreated = DateTime.UtcNow
            };

            this.comments.Add(newComment);
            this.comments.SaveChanges();

            return newComment;
        }

        public Comment GetLastComment()
        {
            var comment = this.comments.All().OrderByDescending(c => c.DateCreated).FirstOrDefault();
            return comment;
        }
    }
}
