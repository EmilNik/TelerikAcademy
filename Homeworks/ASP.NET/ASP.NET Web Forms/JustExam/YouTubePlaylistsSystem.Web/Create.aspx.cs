using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data.Services.Contracts;
using YouTubePlaylistsSystem.Data.Models;
using YouTubePlaylistsSystem.Data.Services;

namespace YouTubePlaylistsSystem.Web
{
    public partial class Create : System.Web.UI.Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        [Inject]
        public IUsersServices UserServices { get; set; }

        public int count { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var categories = this.CategoriesServices.GetAll();
                foreach (var item in categories)
                {
                    this.CategoryDropDown.Items.Add(new ListItem(item.Name, item.Id.ToString()));
                }

                count = 0;
            }
        }

        public void CreatePlaylist_Click(object sender, EventArgs e)
        {
            var user = this.UserServices.GetCurrentUser(this.User.Identity.Name);
            var videoURL = this.VideoURl.Text;
            var url = videoURL.Substring(32);

            var playlist = new Playlist
            {
                CategoryId = int.Parse(this.CategoryDropDown.SelectedValue),
                DateCreated = DateTime.Now,
                Description = this.Description.Text,
                Title = this.Name.Text,
                Videos = new List<Video>
                {
                    new Video
                    {
                        URL = url
                    }
                },
                UserId = user.Id
            };

            PlaylistsServices.Create(playlist);

            Response.Redirect("~/Account/Profile");
        }

        public void Add_Click(object sender, EventArgs e)
        {
        }
    }
}