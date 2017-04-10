using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace UnderstandConneg
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("frmt", "json",
                    new MediaTypeHeaderValue("application/json")));

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("frmt", "xml",
                    new MediaTypeHeaderValue("application/xml")));

            config.EnableSystemDiagnosticsTracing();

            foreach (var formatter in config.Formatters)
            {
                Trace.WriteLine(formatter.GetType().Name);
                Trace.WriteLine("\tCanReadType: " + formatter.CanReadType(typeof(Employee)));
                Trace.WriteLine("\tCanWriteType: " + formatter.CanWriteType(typeof(Employee)));
                Trace.WriteLine("\tBase: " + formatter.GetType().BaseType.Name);
                Trace.WriteLine("\tMedia Types: " + String.Join(", ", formatter.SupportedMediaTypes));
            }
        }
    }
}
