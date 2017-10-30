using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;

namespace Cibertec.Mvc
{
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
                        
            container.Register<IUnitOfWork>(()=> new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString()));
            
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}