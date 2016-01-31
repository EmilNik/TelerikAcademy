using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Controls_And_HTML_Controls.Startup))]
namespace Web_Controls_And_HTML_Controls
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
