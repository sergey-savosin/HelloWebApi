using HelloWebApi.Tech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace HelloWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Конфигурация и службы веб-API
            //config.EnableSystemDiagnosticsTracing();

            // custom xml Tracer
            //config.Services.Replace(typeof(ITraceWriter), new WebApiTracer());

            config.Services.Replace(typeof(ITraceWriter), new EntryExitTracer());
        }
    }
}
