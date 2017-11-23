using log4net;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace Cibertec.WebApi.Middlewares
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class OwinExceptionHandlerMiddleware
    {
        private readonly AppFunc _next;

        public OwinExceptionHandlerMiddleware(AppFunc next)
        {
            _next = next ?? throw new ArgumentNullException("next");
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            try
            {
                await _next(environment);
            }
            catch (Exception ex)
            {
                var log = LogManager.GetLogger(typeof(OwinExceptionHandlerMiddleware));
                var owinContext = new OwinContext(environment);
                log.Error(ex);
                HandleException(ex, owinContext);
            }
        }
        private void HandleException(Exception ex, IOwinContext context)
        {
            var request = context.Request;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ReasonPhrase = "Internal Server Error";
            context.Response.ContentType = "application/json";
            context.Response.Write("Error");

        }

    }

    public static class OwinExceptionHandlerMiddlewareAppBuilderExtensions
    {
        public static void UseOwinExceptionHandler(this IAppBuilder app)
        {
            app.Use<OwinExceptionHandlerMiddleware>();
        }
    }
}