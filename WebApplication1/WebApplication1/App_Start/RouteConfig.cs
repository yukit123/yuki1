﻿using System;
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

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebApplication1.Controllers" }
            ).DataTokens.Add("area", "Home");


        }
    }
}
