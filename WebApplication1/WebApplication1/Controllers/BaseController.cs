using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        #region common method to get actionname and controllername 然后在当前action中调用：ViewBag.aa = CurrentAction;ViewBag.bb = CurrentController;
        //string actionName = this.ControllerContext.RouteData.Values["action"].ToString(); 当前方法名
        //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString(); 当前控制器名
        //https://stackoverflow.com/a/34823027 
        protected string CurrentAction { get; private set; }
        protected string CurrentController { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);//和例子不一样，要加这一行，不然报错

            PopulateControllerActionInfo(requestContext);
        }

        protected void PopulateControllerActionInfo(RequestContext requestContext)
        {
            RouteData routedata = requestContext.RouteData;

            object routes;

            if (routedata.Values.TryGetValue("MS_DirectRouteMatches", out routes))
            {
                routedata = (routes as List<RouteData>)?.FirstOrDefault();
            }

            if (routedata == null)
                return;

            Func<string, string> getValue = (s) =>
            {
                object o;
                return routedata.Values.TryGetValue(s, out o) ? o.ToString() : String.Empty;
            };

            this.CurrentAction = getValue("action");
            this.CurrentController = getValue("controller");
        }
        #endregion
        // GET: Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            //base.OnActionExecuted(filterContext);
            ///// Here I have fetch value as static but you can take if from your entity framework or db.
            //List<SelectListItem> oList = new List<SelectListItem>();
            //SelectListItem oItem = new SelectListItem();
            //oItem.Text = "Store1";
            //oItem.Value = "1";

            //oList.Add(oItem);
            //SelectListItem oItem1 = new SelectListItem();
            //oItem1.Text = "Store2";
            //oItem1.Value = "2";
            //oList.Add(oItem1);

            //ViewBag.Users = oList;
        }

        protected override void ExecuteCore()
        {

            base.ExecuteCore();
        }
    }
}