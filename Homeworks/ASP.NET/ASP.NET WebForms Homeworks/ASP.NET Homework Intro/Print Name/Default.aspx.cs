using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Web_Forms_Application
{
    public partial class _Default : Page
    {
        protected void PrintName(object sender, EventArgs e)
        {
            var name = this.name;
            this.OutputLabel.Text = $"Hello, {name}";
        }
    }
}