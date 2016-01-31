using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data.Models;
using YouTubePlaylistsSystem.Data.Services;

namespace YouTubePlaylistsSystem.Web.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        [Inject]
        public IUsersServices UsersServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public User fvDetails_GetItem()
        {
            var user = this.UsersServices.GetCurrentUser(this.User.Identity.Name);
            return user;
        }
    }
}