namespace RealEstate.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using Common.Constants;
    using RealEstate.Data.Models;
    using RealEstate.Data.Repositories;

    public class RealEstateService : IRealEstateService
    {
        private readonly IRepository<RealEstate> realEstates;
        private readonly IRepository<User> users;

        public RealEstateService(IRepository<RealEstate> realEstates, IRepository<User> users)
        {
            this.realEstates = realEstates;
            this.users = users;
        }

        public IQueryable<RealEstate> GetAllRealEstates()
        {
            var realEstates = this.realEstates
                .All()
                .OrderByDescending(r => r.DateCreated)
                .Take(GlobalConstants.RealEstatesPerPage);

            return realEstates;
        }

        public IQueryable<RealEstate> GetRealEstates(int skip = RealEstateConstants.DefaultSkip, int take = RealEstateConstants.DefaultTake)
        {
            if (take > 100)
            {
                throw new ArgumentException("You cannot take more than 100 ads!");
            }

            var realEstates = this.realEstates
                .All()
                .OrderBy(r => r.DateCreated)
                .Skip(skip)
                .Take(take);

            return realEstates;
        }

        public IQueryable<RealEstate> GetRealEstateById(int id)
        {
            var realEstates = this.realEstates
                .All()
                .Where(r => r.Id == id);

            return realEstates;
        }

        public RealEstate CreateRealEstate(string title, string description, string contact, string userId, bool canBeSold, bool canBeRented, int? sellingPrice = 0, int? rentingPrice = null)
        {
            var newRealEstate = new RealEstate
            {
                Title = title,
                Description = description,
                CanBeSold = canBeSold,
                CanBeRented = canBeRented,
                UserId = userId,
                //User = users.GetById(userId),
                Contact = contact,
                DateCreated = DateTime.UtcNow,
                SellingPrice = sellingPrice,
                RentingPrice = rentingPrice
            };

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate;
        }
    }
}
