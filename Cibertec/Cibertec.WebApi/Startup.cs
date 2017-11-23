using Cibertec.WebApi.Middlewares;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

[assembly: OwinStartup(typeof(Cibertec.WebApi.Startup))]

namespace Cibertec.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            log4net.Config.XmlConfigurator.Configure();
            var log = log4net.LogManager.GetLogger(typeof(Startup));
            log.Debug("Logging is enabled");

            var config = new HttpConfiguration();            
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            DIConfig.ConfigureInjector(config);
            TokenConfig.ConfigureOAuth(app, config);
            RouteConfig.Register(config);
            WebApiConfig.Configure(config);            
            app.UseWebApi(config);
        }
    }
}
