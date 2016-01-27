using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Web.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        private LibraryDbContext context = new LibraryDbContext();

        public EditBooks()
        {
            this.context = new LibraryDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Library.Web.Models.Book> GridViewBooks_GetData()
        {
            var books = this.context.Books.OrderBy(b => b.Id);
            return books;
        }

        protected void GridViewBooks_UpdateItem(int id)
        {
            Library.Web.Models.Book item = this.context.Books.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.context.SaveChanges();
            }
        }

        protected void GridViewBooks_DeleteItem(int id)
        {
            Library.Web.Models.Book item = this.context.Books.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.context.Books.Remove(item);
            this.context.SaveChanges();
        }

        public void FormViewIsertBook_InsertItem()
        {
            var item = new Library.Web.Models.Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.context.Books.Add(item);
                this.context.SaveChanges();
            }
        }
        public IQueryable<Library.Web.Models.Category> DropDownListCategoriesCreate_GetData()
        {
            return this.context.Categories.OrderBy(b => b.Name);
        }

        protected void DropDownListCategoriesCreate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.btnWrapper.Visible = false;

            var fv = this.UpdatePanelInsertBook.FindControl("FormViewIsertBook") as FormView;
            fv.Visible = true;
        }
    }
}