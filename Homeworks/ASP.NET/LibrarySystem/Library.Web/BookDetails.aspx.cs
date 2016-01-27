using Library.Web.Models;
using System;
using System.Linq;
using System.Web.ModelBinding;

namespace Library.Web
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private LibraryDbContext context;

        public BookDetails()
        {
            context = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Library.Web.Models.Book FormViewBookDetails_GetItem([QueryString("id")]int? id)
        {
            if(id == null)
            {
                Response.Redirect("~/");
            }

            return context.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}