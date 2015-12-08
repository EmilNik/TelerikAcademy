namespace RealEstate.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class RealEstateDbContext : IdentityDbContext<User>, IRealEstateDbContext
    {
        public RealEstateDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static RealEstateDbContext Create()
        {
            return new RealEstateDbContext();
        }
    }
}
