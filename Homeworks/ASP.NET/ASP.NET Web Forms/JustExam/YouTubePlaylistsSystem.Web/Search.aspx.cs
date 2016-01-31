using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data;
using YouTubePlaylistsSystem.Data.Models;
using YouTubePlaylistsSystem.Data.Services.Contracts;

namespace YouTubePlaylistsSystem.Web
{
    public partial class Search : System.Web.UI.Page
    {
        private YouTubePlaylistsSystemDbContext dbContext;

        public Search()
        {
            dbContext = new YouTubePlaylistsSystemDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Playlist> Reapeater_GetData([QueryString("q")] string query)
        {
            this.LiteralSearchQuery.Text = string.Format("“{0}”:", query);
            var playlists = this.dbContext.Playlists.Where(p => p.Title.Contains(query) || p.Description.Contains(query));
            return playlists;
        }
    }
}