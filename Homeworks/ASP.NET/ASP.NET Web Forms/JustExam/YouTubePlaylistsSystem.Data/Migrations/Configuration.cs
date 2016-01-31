namespace YouTubePlaylistsSystem.Data.Migrations
{
    using Models;
    using YouTubePlaylistsSystem.Migrations;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.Validation;
    using System;
    using Microsoft.AspNet.Identity;
    public sealed class Configuration : DbMigrationsConfiguration<YouTubePlaylistsSystem.Data.YouTubePlaylistsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(YouTubePlaylistsSystem.Data.YouTubePlaylistsSystemDbContext context)
        {
            if (context.Playlists.Any())
            {
                return;
            }

            var passwordHasher = new PasswordHasher();

            var user = new User()
            {
                UserName = "admin@site.com",
                PasswordHash = passwordHasher.HashPassword("admin"),
                FirstName = "admin",
                LastName = "admin",
                imageURL = "http://zblogged.com/wp-content/uploads/2015/11/c1.png"
            };

            context.Users.Add(user);

            context.SaveChanges();

            var seed = new SeedData(user);

            seed.Users.ForEach(x => context.Users.Add(x));

            seed.Categories.ForEach(x => context.Categories.Add(x));

            seed.Playlists.ForEach(x => context.Playlists.Add(x));

            context.SaveChanges();
        }
    }
}
