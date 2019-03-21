using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace TestApplication2
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
        //public void Application_AuthenticateRequest(Object src, EventArgs e)
        //{
        //    FormsAuthentication.RedirectFromLoginPage("pp", true);

        //    //if (!(HttpContext.Current.User == null))
        //    //{
        //    //    if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
        //    //    {
        //    //        System.Web.Security.FormsIdentity id;
        //    //        id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
        //    //        String[] myRoles = new String[2];
        //    //        myRoles[0] = "Manager";
        //    //        myRoles[1] = "Admin";
        //    //        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
        //    //    }
        //    //}

        //    HttpCookie decryptedCookie =
        //    Context.Request.Cookies[FormsAuthentication.FormsCookieName];

        //    FormsAuthenticationTicket ticket =
        //        FormsAuthentication.Decrypt(decryptedCookie.Value);

        //    var identity = new GenericIdentity(ticket.Name);
        //    var principal = new GenericPrincipal(identity, null);

        //    HttpContext.Current.User = principal;
        //    Thread.CurrentPrincipal = HttpContext.Current.User;
        //}
    }
}
