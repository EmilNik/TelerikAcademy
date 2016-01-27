using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Web
{
    public partial class Search : System.Web.UI.Page
    {
        public LibraryDbContext dbContext;

        public Search()
        {
            dbContext = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Library.Web.Models.Book> Reapeater_GetData([QueryString("q")] string query)
        {
            this.LiteralSearchQuery.Text = string.Format("“{0}”:", query);
            var books = this.dbContext.Books.Where(b => b.Author.Contains(query) || b.Title.Contains(query));
            return books;
        }

        protected string GetTitle(Library.Web.Models.Book book)
        {
            return string.Format("“{0}” <i>by {1}</i>", Server.HtmlEncode(book.Title), Server.HtmlEncode(book.Author));
        }
    }
}