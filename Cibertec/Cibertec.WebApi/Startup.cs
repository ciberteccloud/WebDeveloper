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
            var config = new HttpConfiguration();
            //config.Services.Replace(typeof(IExceptionHandler), new ContentNegotiatedExceptionHandler());
            app.UseOwinExceptionHandler();

            DIConfig.ConfigureInjector(config);
            TokenConfig.ConfigureOAuth(app, config);
            RouteConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
