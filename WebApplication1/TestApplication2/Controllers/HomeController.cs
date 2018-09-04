using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication2.Controllers
{
    [Authorize]//Forms Authentication:<authentication mode="Forms"> https://stackoverflow.com/questions/4087300/asp-net-mvc-issue-with-configuration-of-forms-authentication-section
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
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