using System;
using System.Web.Http;
using System.Web.Mvc;

namespace Lab3
{
    public static class WebApiConfig
    {
        public static Action<HttpConfiguration> RegisterWithResolver(System.Web.Http.Dependencies.IDependencyResolver dependencyResolver)
        {
            return config =>
            {
                config.EnableCors();
                config.DependencyResolver = dependencyResolver;
                Register(config);
            };
        }

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );
        }
    }
}