namespace RealEstate.Services.Data
{
    using RealEstate.Data.Models;
    using RealEstate.Data.Repositories;
    using System.Linq;

    public class UsersService
    {
        private readonly IRepository<Rating> ratings;
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users, IRepository<Rating> ratings)
        {
            this.users = users;
            this.ratings = ratings;
        }

        public double GetUsersRating(string userId)
        {
            var user = this.users.GetById(userId);
            var ratings = this.users.GetById(userId).Raiting;
            var count = 0;
            double sum = 0;

            foreach (var item in ratings)
            {
                sum += item.Value;
                count++;
            }

            double average = sum / count;
            user.Rate = average;
            return average;
        }

        public IQueryable<User> GetUserByUsername(string username)
        {
            var user = this.users.GetByUsername(username);
            return (IQueryable<User>)user;
        }

        public IQueryable<Rating> GetAllRaitingsForSpecificUser(string userId)
        {
            var raitings = this.ratings.All()
                .Where(r => r.UserId == userId);

            return (IQueryable<Rating>)ratings;
        }
        public Rating RateUser(string userId, int value)
        {
            var rating = new Rating
            {
                Value = value
            };

            this.ratings.Add(rating);
            this.ratings.SaveChanges();

            return rating;
        }
    }
}
