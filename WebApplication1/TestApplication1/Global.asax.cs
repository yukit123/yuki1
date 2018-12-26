using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
