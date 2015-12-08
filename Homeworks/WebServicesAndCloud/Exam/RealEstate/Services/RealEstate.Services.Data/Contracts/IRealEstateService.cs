namespace RealEstate.Services.Data.Contracts
{
    using System.Linq;
    using RealEstate.Data.Models;

    public interface IRealEstateService
    {
        RealEstate CreateRealEstate(string title, string description, string userId, string contact, bool canBeSold, bool canBeRented, int? sellingPrice = null, int? rentingPrice = null);
        IQueryable<RealEstate> GetAllRealEstates();
        IQueryable<RealEstate> GetRealEstateById(int id);
        IQueryable<RealEstate> GetRealEstates(int skip = 0, int take = 10);
    }
}