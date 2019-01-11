using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Timer timer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //HttpContext context = HttpContext.Current;
            //if (context != null)
            //{
            //    // 能运行到这里，就肯定是在处理ASP.NET请求，我们可以放心地访问Request的所有数据
            //    //sb.AppendLine("Url:" + context.Request.RawUrl);

            //    // 还有记录什么数据，您自己来实现吧。
            //}



            //timer = new System.Timers.Timer();
            //timer.Enabled = true;
            //timer.Interval = 60000;
            //timer.Start();
            //timer.Elapsed += HandleTimerElapsed;
        }

        public static void HandleTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            //System.Web.Mvc.UrlHelper helper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
            //string link = helper.Action("Partial_Index", "Home2");


            //UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            //return url.Action("ViewAction", "MyModelController");

            Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);


        }

       

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.Mvc.UrlHelper helper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
            string link = helper.Action("Partial_Index", "Home2");

            if (HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".jpg") && HttpContext.Current.Request.UrlReferrer.Host != "localhost")
            {
                HttpContext.Current.Response.WriteFile(HttpContext.Current.Server.MapPath("~/imgs/forbid.png"));
                HttpContext.Current.Response.End();
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        //void Session_Start(object sender, EventArgs e)
        //{
        //    //// 在新会话启动时运行的代码

        //    ////存储path
        //    ////文件路径
        //    //List<string> paths = new List<string>();
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_b.png"));//二值化文件
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_d.png"));//纹理消除文件
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_search.png"));//搜索结果文件
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_p1.png"));//图像分割文件1
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_p2.png"));//图像分割文件2
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_p3.png"));//图像分割文件3
        //    //paths.Add(Server.MapPath("temp/" + Session.SessionID + "_p4.png"));//图像分割文件4
        //    //Session.Add("paths", paths);
        //    Debug.WriteLine("Session Start");
        //    Session["session"] = "Session Works Nice";
        //}



        void Session_End(object sender, EventArgs e)//见note,如果注释掉Partial_Index的session,也不会被执行
       {
            //// 在会话结束时运行的代码。
            //// 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            //// InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
            //// 或 SQLServer，则不会引发该事件。

            ////删除本次会话产生的临时文件
            ////文件路径
            //List<string> pathes = (List<string>)Session["paths"];
            ////删除
            //foreach (string path in pathes)
            //    File.Delete(path);
            //string sessionText = Session["session"].ToString();
            //string anotherText = Session["anoterText"].ToString();
            //Debug.WriteLine(sessionText);
            //Debug.WriteLine(anotherText);
            //Debug.WriteLine("Session End");

        }
    }
}
