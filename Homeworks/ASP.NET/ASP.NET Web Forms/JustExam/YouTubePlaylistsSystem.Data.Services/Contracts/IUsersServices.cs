using YouTubePlaylistsSystem.Data.Models;

namespace YouTubePlaylistsSystem.Data.Services
{
    public interface IUsersServices
    {
        User GetById(int id);

        User GetCurrentUser(string name);
    }
}