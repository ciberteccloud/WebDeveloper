using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cibertec.Mvc.Startup))]
namespace Cibertec.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
