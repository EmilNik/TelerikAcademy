using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Controls_And_HTML_Controls
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Selection_Change_University(object sender, EventArgs e)
        {
            if (this.university.SelectedValue == "0")
            {
                this.specialityDiv.Visible = false;
            }
            else
            {
                this.specialityDiv.Visible = true;
            }
        }

        protected void Selection_Change_Speciality(object sender, EventArgs e)
        {
            if (this.speciality.SelectedValue == "0")
            {
                this.coursesDiv.Visible = false;
            }
            else
            {
                this.coursesDiv.Visible = true;
            }
        }

        protected void Register(object sender, EventArgs e)
        {

        }
    }
}