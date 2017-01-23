using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sell_Buy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "AuthorizationName",
             url: "Authorization",
             defaults: new { controller = "Authorization", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "AuthenticatioName",
               url: "Authentication",
               defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
           );

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
