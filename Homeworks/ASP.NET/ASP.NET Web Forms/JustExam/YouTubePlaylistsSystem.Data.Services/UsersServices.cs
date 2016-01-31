namespace YouTubePlaylistsSystem.Data.Services
{
    using Models;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetById(int id)
        {
            return this.users.GetById(id);
        }

        public User GetCurrentUser(string name)
        {
            return this.users.All().Where(u => u.UserName == name).FirstOrDefault();
        }
    }
}
