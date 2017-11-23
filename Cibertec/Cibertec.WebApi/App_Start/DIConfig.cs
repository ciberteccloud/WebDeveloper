using SimpleInjector;
using System.Configuration;
using SimpleInjector.Lifestyles;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using log4net;
using log4net.Core;

namespace Cibertec.WebApi
{
    public class DIConfig
    {
        public static void ConfigureInjector(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();            
            container.Register<IUnitOfWork>(() => new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString()));
            container.RegisterConditional(typeof(ILog), c => typeof(Log4NetAdapter<>).MakeGenericType(c.Consumer.ImplementationType), Lifestyle.Singleton, c => true);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }

    public sealed class Log4NetAdapter<T> : LogImpl
    {
        public Log4NetAdapter() : base(LogManager.GetLogger(typeof(T)).Logger) { }
    }
}