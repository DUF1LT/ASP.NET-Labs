using System.Web.Mvc;
using System.Web.Routing;

namespace Lab3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Lab5a
            // routes.MapRoute(
            //     name: "1",
            //     url: "V3",
            //     new { controller = "MResearch", action = "M03" }
            // );
            //
            // routes.MapRoute(
            //     name: "2",
            //     url: "V3/{controller}/{id}/{action}",
            //     defaults: new { controller = "MResearch", action = "M03" },
            //     constraints: new { id = @"X?" }
            // );
            //
            // routes.MapRoute(
            //     name: "3",
            //     url: "V2/{controller}/{action}",
            //     defaults: new { controller = "MResearch", action = "M02" },
            //     constraints: new { action = "M01|M02" }
            // );
            //
            // routes.MapRoute(
            //     name: "4",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
            //     constraints: new { id = @"1?", action = "M01" }
            // );
            //
            // routes.MapRoute(
            //     name: "5",
            //     url: "{controller}/{action}",
            //     defaults: new { controller = "MResearch", action = "M01" },
            //     constraints: new { action = "M01|M02" }
            // );
            //
            // routes.MapRoute(
            //     name: "MXX",
            //     url: "{controller}/{action}",
            //     defaults: new { controller = "MResearch", action = "MXX", }
            // );

            // routes.MapRoute(
            //     name: "Default",
            //     url: "{controller}/{action}",
            //     defaults: new { controller="CResearch", action = "C01"}
            // );

            //Lab5b

            // routes.MapMvcAttributeRoutes();
            //
            // routes.MapRoute(
            //     name: "Default",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "AResearch", action = "AA", id = UrlParameter.Optional }
            // );
            //
            // routes.MapRoute(
            //     name: "Default2",
            //     url: "{controller}/{action}/{id}",
            //     defaults: new { controller = "CHResearch", action = "AD", id = UrlParameter.Optional }
            // );
        }
    }
}