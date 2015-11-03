using Microsoft.Owin;

[assembly: OwinStartup(typeof(SourceControlSystem.API.Startup))]

namespace SourceControlSystem.API
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
