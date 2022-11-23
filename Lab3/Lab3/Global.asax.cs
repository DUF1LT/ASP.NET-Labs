using Ninject.Web.Mvc;
using Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web;
using Lab3.Ninject;
using WebApiContrib.IoC.Ninject;

namespace Lab3
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            var mvcResolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(mvcResolver);

            var webApiResolver = new NinjectResolver(kernel);
            GlobalConfiguration.Configure(WebApiConfig.RegisterWithResolver(webApiResolver));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}