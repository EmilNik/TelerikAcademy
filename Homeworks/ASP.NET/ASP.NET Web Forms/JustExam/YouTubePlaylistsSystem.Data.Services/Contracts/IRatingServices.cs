namespace YouTubePlaylistsSystem.Data.Services.Contracts
{
    using Models;

    public interface IRatingServices
    {
        Rate GetByAuthorIdAndArticledId(string userId, int articleId);

        void ChangeRate(string userId, int articleId);

        void CreateRate(Rate like);
    }
}
