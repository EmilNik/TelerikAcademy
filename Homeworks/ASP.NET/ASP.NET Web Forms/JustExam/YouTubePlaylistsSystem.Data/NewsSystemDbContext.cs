namespace YouTubePlaylistsSystem.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class YouTubePlaylistsSystemDbContext : IdentityDbContext<User>, IYouTubePlaylistsSystemDbContext
    {
        public YouTubePlaylistsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Playlist> Playlists { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Rate> Rates { get; set; }

        public static YouTubePlaylistsSystemDbContext Create()
        {
            return new YouTubePlaylistsSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Playlist>()
                .HasRequired(p => p.Category)
                .WithMany(x => x.Playlists)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
