using System.Web.Mvc;
using System.Web.Routing;

namespace EmptyMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EmptyMVC.Controllers" }
            );

            routes.MapRoute(
                name: "App",
                url: "App/{action}/{id}",
                defaults: new { controller = "Person", id = UrlParameter.Optional }
            );
        }
    }
}