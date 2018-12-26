using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            //routes.MapRoute( //https://forums.asp.net/t/2150332.aspx
            //     name: "route_site",
            //     url: "site/{action}/{id}",
            //     defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional },
            //     namespaces: new string[] { "TestApplication1.Controllers" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TestApplication1.Controllers" }
            );
        }
    }
}
