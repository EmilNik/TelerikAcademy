using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data.Models;
using YouTubePlaylistsSystem.Data.Services.Contracts;

namespace YouTubePlaylistsSystem.Web
{
    public partial class ListPlaylists : System.Web.UI.Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Playlist> GridViewPlaylists_GetData()
        {
            return this.PlaylistsServices.GetAll();
        }
    }
}