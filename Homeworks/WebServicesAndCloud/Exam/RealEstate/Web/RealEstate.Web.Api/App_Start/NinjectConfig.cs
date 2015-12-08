namespace RealEstate.Web.Api
{
    using System;
    using System.Web;

    using Common.Constants;
    using Common.Providers;
    using Data;
    using Data.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Infrastructure;

    public static class NinjectConfig
    {
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel.Bind<IRealEstateDbContext>().To<RealEstateDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        };

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            DependenciesRegistration(kernel);

            kernel.Bind<IRandomProvider>().To<RandomProvider>();
            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();

            kernel.Bind(b => b
                .From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}