using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Web
{
    public partial class Book : System.Web.UI.Page
    {
        private LibraryDbContext context;

        public Book()
        {
            context = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Category> ListViewCategories_GetData()
        {
            return this.context.Categories;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParams = string.Format("?q={0}", this.TextBoxSearchParam.Text);
            Response.Redirect(string.Format("~/Search{0}", queryParams));

        }
    }
}