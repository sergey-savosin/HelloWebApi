using RequestValidation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;

namespace RequestValidation
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

            //config.Services.Add(typeof(ModelValidatorProvider), new InvalidModelValidatorProvider());
            config.Filters.Add(new ValidationErrorHandlerFilterAttribute());
            config.MessageHandlers.Add(new CultureHandler());
        }
    }
}
