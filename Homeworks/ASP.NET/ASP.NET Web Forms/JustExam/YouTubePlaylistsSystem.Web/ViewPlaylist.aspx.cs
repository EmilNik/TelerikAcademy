namespace YouTubePlaylistsSystem.Web
{
    using System;
    using System.Web.ModelBinding;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.UI;

    using Ninject;
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Services.Contracts;

    public partial class ViewPlaylist : Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        public int id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Playlist fvDetails_GetItem([QueryString]string id)
        {
            // TODO: validate id
            if (id == null)
            {
                return null;
            }

            int asd;
            if (!int.TryParse(id, out asd))
            {
                return null;
            }

            //var playlist = 
            //this.id = playlist.Id;

            //if (this.User.Identity.Name == playlist.User.UserName)
            //{

            //}

            return this.PlaylistsServices.GetById(asd);
        }

        public ICollection<Video> videoRepeater_Select([QueryString]string id)
        {
            var sad = this.PlaylistsServices.GetById(int.Parse(id)).Videos.ToList();
            return sad;
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            this.PlaylistsServices.DeleteById(this.id);
            Response.Redirect("~/");
        }
    }
}