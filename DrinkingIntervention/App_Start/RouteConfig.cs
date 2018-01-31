using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DrinkingIntervention
{
    public class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration configuration)
        {
            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "module1",
                url: "module/1/{id}",
                defaults: new { controller = "Module", action = "Module1" }
            );

            routes.MapRoute(
                name: "module2",
                url: "module/2/{id}",
                defaults: new { controller = "Module", action = "Module2" }
            );

            routes.MapRoute(
                name: "module3",
                url: "module/3/{id}",
                defaults: new { controller = "Module", action = "Module3" }
            );

            routes.MapRoute(
                name: "module4",
                url: "module/4/{id}",
                defaults: new { controller = "Module", action = "Module4" }
            );

            routes.MapRoute(
                name: "module5",
                url: "module/5/{id}",
                defaults: new { controller = "Module", action = "Module5" }
            );

            routes.MapRoute(
                name: "module6",
                url: "module/6/{id}",
                defaults: new { controller = "Module", action = "Module6" }
            );

            routes.MapRoute(
                name: "module7",
                url: "module/7/{id}",
                defaults: new { controller = "Module", action = "Module7" }
            );

            routes.MapRoute(
                name: "module8",
                url: "module/8/{id}",
                defaults: new { controller = "Module", action = "Module8" }
            );

            routes.MapRoute(
                name: "module9",
                url: "module/9/{id}",
                defaults: new { controller = "Module", action = "Module9" }
            );

            routes.MapRoute(
                name: "module10",
                url: "module/10/{id}",
                defaults: new { controller = "Module", action = "Module10" }
            );

            routes.MapRoute(
                name: "module11",
                url: "module/11/{id}",
                defaults: new { controller = "Module", action = "Module11" }
            );

            routes.MapRoute(
                name: "module12",
                url: "module/12/{id}",
                defaults: new { controller = "Module", action = "Module12" }
            );

            routes.MapRoute(
                name: "consent",
                url: "consent",
                defaults: new { controller = "Home", action = "Consent" }
            );

            routes.MapRoute(
                name: "demographics",
                url: "demographics",
                defaults: new { controller = "Home", action = "Demographics" }
            );

            routes.MapRoute(
               name: "survey",
               url: "survey/{id}",
               defaults: new { controller = "Home", action = "Survey" }
            );

            routes.MapRoute(
               name: "additional",
               url: "additional/{id}",
               defaults: new { controller = "Home", action = "Additional" }
            );

            routes.MapRoute(
               name: "phone",
               url: "phone/{id}",
               defaults: new { controller = "Home", action = "Phone" }
            );

            routes.MapRoute(
               name: "complete",
               url: "complete",
               defaults: new { controller = "Home", action = "Complete" }
            );

            routes.MapRoute(
               name: "default",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
            );

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/
        }
    }
}
