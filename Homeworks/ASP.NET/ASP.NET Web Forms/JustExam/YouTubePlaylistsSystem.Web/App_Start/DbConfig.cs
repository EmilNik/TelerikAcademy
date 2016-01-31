namespace YouTubePlaylistsSystem.Web.App_Start
{
    using Data;
    using System.Data.Entity;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YouTubePlaylistsSystemDbContext, Configuration>());
            YouTubePlaylistsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}