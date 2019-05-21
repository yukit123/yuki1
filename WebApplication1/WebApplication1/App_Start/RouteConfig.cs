using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //  routes.MapRoute(
            //    name: "admin123",
            //    url: "admin123/{controller}/{action}",
            //    defaults: new { controller = "admin", action = "Index" },
            //    namespaces: new string[] { "WebApplication1.Controllers" }
            //);
            routes.MapMvcAttributeRoutes();//启动属性路由 [Route("AAA/Index")] 包括Area
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebApplication1.Controllers" }//namespaces: new[] { string.Format("{0}.Controllers", typeof(RoutingConfig).Namespace) }

            ).DataTokens.Add("area", "Home");


        }
    }
}
