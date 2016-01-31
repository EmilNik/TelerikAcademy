using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTubePlaylistsSystem.Data.Models;
using YouTubePlaylistsSystem.Data.Services.Contracts;

namespace YouTubePlaylistsSystem.Web
{
    public partial class Categories : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Category lvCategories_GetData([QueryString]string id)
        {
            if (id == null)
            {
                return null;
            }

            return this.CategoriesServices.GetById(int.Parse(id)); ;
        }
    }
}