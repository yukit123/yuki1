using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//自带地异常过滤器
            filters.Add(new SessionExpireFilterAttribute());//额外添加自定义过滤器 SessionExpireFilter
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class SessionExpireFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower().Trim();
                string actionName = filterContext.ActionDescriptor.ActionName.ToLower().Trim();

                //if (!actionName.StartsWith("log")) // && !actionName.StartsWith("sessionlogoff")
                //{
                //    var session = HttpContext.Current.Session["UserID"];
                //    HttpContext ctx = HttpContext.Current;
                //    //Redirects user to login screen if session has timed out
                //    if (session == null)
                //    {
                //        base.OnActionExecuting(filterContext);
                //        if (filterContext.RouteData.DataTokens["area"] != null)
                //        {
                //            #region redirection to area
                //            switch (filterContext.RouteData.DataTokens["area"].ToString())
                //            {
                //                case "Home":
                //                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                //                    {
                //                        controller = "Accounts",
                //                        action = "Index",
                //                        //area = "Accounts"
                //                        Areas = "Accounts"
                //                    }));
                //                    //filterContext.Result = new RedirectResult("~/Accounts/Accounts/Index");
                //                    //Redirection to area not working
                //                    break;
                //                case "Accounts":
                //                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                //                    {
                //                        controller = "Accounts",
                //                        action = "Index",
                //                        Areas = "Accounts"
                //                    }));
                //                    //filterContext.Result = new RedirectResult("~/Accounts/Accounts/Index");
                //                    //Redirection to area not working
                //                    break;
                //            }
                //            #endregion
                //        }
                //        else
                //        {
                //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                //            {
                //                controller = "Home",
                //                action = "Index"
                //            }));
                //        }
                //    }
                //}
            }
        }
    }
}
