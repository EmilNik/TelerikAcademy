namespace YouTubePlaylistsSystem.Data.Services
{
    using Contracts;
    using System.Linq;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Repositories;

    public class PlaylistsServices : IPlaylistsServices
    {
        private IRepository<Playlist> playlists;

        public PlaylistsServices(IRepository<Playlist> playlist)
        {
            this.playlists = playlist;
        }

        public IQueryable<Playlist> GetAll()
        {
            return this.playlists.All();
        }

        public IQueryable<Playlist> GetTop(int count)
        {
            return this.playlists.All().OrderByDescending(x => x.Rates.Count()).Take(count);
        }

        public Playlist GetById(int id)
        {
            return this.playlists.GetById(id);
        }

        public void Create(Playlist playlist)
        {
            this.playlists.Add(playlist);
            this.playlists.SaveChanges();
        }

        public void UpdateById(int id, Playlist updatePlaylist)
        {
            var playlistToUpdate = this.playlists.GetById(id);

            playlistToUpdate.CategoryId = updatePlaylist.CategoryId;
            playlistToUpdate.Title = updatePlaylist.Title;
            playlistToUpdate.Description = updatePlaylist.Description;

            this.playlists.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.playlists.Delete(id);
            this.playlists.SaveChanges();
        }
    }
}
