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
            #region 跨域配置
            ///1.
            //Nuget搜索“microsoft.aspnet.webapi.cors”
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));//http://www.cnblogs.com/landeanfen/p/5177176.html
            //不过 *是不安全的，可以在web.config里设置，然后调用

            ///2.如果你只想对某一些api做跨域，可以直接在API的类上面使用特性标注即可。
            //[EnableCors(origins: "http://localhost:8081/", headers: "*", methods: "GET,POST,PUT,DELETE")] //using System.Web.Http.Cors
            //public class ChargingController : ApiController
            //    {
            //        /// <summary>
            //        /// 得到所有数据
            //        /// </summary>
            //        /// <returns>返回数据</returns>
            //        [HttpGet]
            //        public string GetAllChargingData()
            //        {
            //            return "Success";
            //        }
            //    }
            //jQuery.support.cors = true; 解决IE8 IE9不兼容跨域的问题
            #endregion


            // Web API configuration and services   

            // Web API routes
            config.MapHttpAttributeRoutes();//启用Web API特性路由

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
              //  routeTemplate: "api/{controller}/{id}",
                     routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 2.config.Filters.Add(new WebApiExceptionFilterAttribute());//需要对整个应用程序都启用异常过滤(1.在Global.asax全局配置里面添加)
        }
    }
}
