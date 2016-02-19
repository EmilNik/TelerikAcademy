using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(JustAsk.Web.Startup))]

namespace JustAsk.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
