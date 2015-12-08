namespace RealEstate.Web.Api
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initiliaze()
        { 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RealEstateDbContext, Configuration>());
        }
    }
}