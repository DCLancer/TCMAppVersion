using System.Web.Mvc;
using System.Web.Routing;

namespace GetAppVersions
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add",
                url: "add",
                defaults: new { controller = "Home", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StoreInfo",
                url: "storeinfo",
                defaults: new { controller = "Home", action = "StoreInfo", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Default",
                url: "{appName}",
                defaults: new { controller = "Home", action = "Index", appName = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "StoreInfo", appName = UrlParameter.Optional }
            );



        }
    }
}
