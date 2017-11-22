using SimpleInjector;
using System.Configuration;
using SimpleInjector.Lifestyles;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;

namespace Cibertec.WebApi
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString()));
            
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
   
}