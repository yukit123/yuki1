using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication2.Controllers
{
    /* [Authorize]*///Forms Authentication:<authentication mode="Forms"> https://stackoverflow.com/questions/4087300/asp-net-mvc-issue-with-configuration-of-forms-authentication-section //https://forums.asp.net/p/2146965/6230187.aspx?p=True&t=636729198218106213
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}