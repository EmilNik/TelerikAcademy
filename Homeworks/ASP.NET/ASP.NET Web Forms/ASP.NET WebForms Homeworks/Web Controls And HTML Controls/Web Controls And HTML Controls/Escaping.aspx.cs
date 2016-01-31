using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Controls_And_HTML_Controls
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowText(object sender, EventArgs e)
        {
            var text = this.escapingInput.Text;
            this.escapedLabel.Text = text;
            this.unescapedLabel.Text = text;
        }
    }
}