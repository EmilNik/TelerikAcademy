namespace YouTubePlaylistsSystem.Data.Services
{
    using Contracts;
    using System.Linq;
    using Models;
    using Repositories;
    using System;

    public class RatingServices : IRatingServices
    {
        private IRepository<Rate> rates;

        public RatingServices(IRepository<Rate> rates)
        {
            this.rates = rates;
        }

        public void ChangeRate(string userId, int playlistId)
        {
            var rate = this.GetByAuthorIdAndArticledId(userId, playlistId);

            rate.Value = rate.Value;

            this.rates.SaveChanges();
        }

        public void CreateRate(Rate rate)
        {
            this.rates.Add(rate);
            this.rates.SaveChanges();
        }

        public Rate GetByAuthorIdAndArticledId(string userId, int playlistId)
        {
            return this.rates.All().FirstOrDefault(x => x.UserId == userId && x.PlaylistId == playlistId);
        }
    }
}
