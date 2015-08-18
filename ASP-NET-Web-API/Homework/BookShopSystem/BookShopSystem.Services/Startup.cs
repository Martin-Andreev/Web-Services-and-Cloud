using BookShopSystem.Services;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace BookShopSystem.Services
{
    using System.Reflection;
    using System.Web.Http;
    using Data;
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

            BindTypes(kernel);

            return kernel;
        }

        private static void BindTypes(StandardKernel kernel)
        {
            kernel.Bind<IBookShopData>().To<BookShopData>()
                .WithConstructorArgument("context", c => new BookShopContext());
            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}
