namespace YouTubePlaylistsSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IYouTubePlaylistsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Playlist> Playlists { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Rate> Rates { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
