using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services   

            // Web API routes
            config.MapHttpAttributeRoutes();//启用Web API特性路由

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 2.config.Filters.Add(new WebApiExceptionFilterAttribute());//需要对整个应用程序都启用异常过滤(1.在Global.asax全局配置里面添加)
        }
    }
}
