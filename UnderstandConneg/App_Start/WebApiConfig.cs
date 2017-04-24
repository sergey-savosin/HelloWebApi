using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using UnderstandConneg.Tech;

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

            config.Services.Add(typeof(
                System.Web.Http.ValueProviders.ValueProviderFactory),
                new HeaderValueProviderFactory());

            config.Formatters.JsonFormatter.SerializerSettings
                .Converters.Add(new DateTimeConverter());

            config.EnableSystemDiagnosticsTracing();

            config.MessageHandlers.Add(new CultureHandler());
        }
    }
}
