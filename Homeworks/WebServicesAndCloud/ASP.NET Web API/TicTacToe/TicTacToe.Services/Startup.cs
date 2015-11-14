using Microsoft.Owin;

[assembly: OwinStartup(typeof(TicTacToe.Services.Startup))]

namespace TicTacToe.Services
{
    using System.Reflection;
    using System.Web.Http;

    using Data;
    using GameLogic;
    using Infrastructure;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<ITicTacToeData>().To<TicTacToeData>()
                .WithConstructorArgument("context",
                c => new TicTacToeDbContext());

            kernel.Bind<IGameResultValidator>().To<GameResultValidator>();

            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}
