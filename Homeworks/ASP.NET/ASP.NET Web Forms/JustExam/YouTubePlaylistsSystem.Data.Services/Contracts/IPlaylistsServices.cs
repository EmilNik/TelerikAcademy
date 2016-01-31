namespace YouTubePlaylistsSystem.Data.Services.Contracts
{
    using YouTubePlaylistsSystem.Data.Models;
    using System.Linq;

    public interface IPlaylistsServices
    {
        IQueryable<Playlist> GetTop(int count);

        IQueryable<Playlist> GetAll();

        Playlist GetById(int id);

        void UpdateById(int id, Playlist updateArticle);

        void DeleteById(int id);

        void Create(Playlist article);
    }
}
