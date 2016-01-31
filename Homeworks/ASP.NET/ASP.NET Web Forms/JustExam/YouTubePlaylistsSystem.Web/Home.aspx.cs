namespace YouTubePlaylistsSystem.Web
{
    using YouTubePlaylistsSystem.Data.Models;
    using YouTubePlaylistsSystem.Data.Services.Contracts;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Home : System.Web.UI.Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Playlist> repeaterPlaylist_GetData1()
        {
            return this.PlaylistsServices.GetTop(10);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> lvCategories_GetData()
        {
            return this.CategoriesServices.GetAll(); ;
        }
        
        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParam = string.Format("?q={0}", this.TextBoxSearchParam.Text);
            Response.Redirect("~/Search" + queryParam);
        }
    }
}