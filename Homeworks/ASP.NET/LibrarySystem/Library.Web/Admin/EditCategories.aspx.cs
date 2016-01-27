using Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Web.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        public LibraryDbContext context;

        public EditCategories()
        {
            this.context = new LibraryDbContext();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //var data = this.dbContext.Categories.ToList();
            //this.ListViewCategories.DataSource = data;
            //this.ListViewCategories.DataBind();
        }
        
        public IQueryable<Library.Web.Models.Category> ListViewCategories_GetData()
        {
            return this.context.Categories.OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int Id)
        {
            Library.Web.Models.Category item = this.context.Categories.Find(Id);
            this.context.Categories.Remove(item);
            this.context.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int ID)
        {
            Library.Web.Models.Category item = context.Categories.Find(ID);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }

        public void ListViewCategories_InsertItem()
        {
            var item = new Library.Web.Models.Category();
            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                context.Categories.Add(item);
                context.SaveChanges();
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {

        }
    }
}