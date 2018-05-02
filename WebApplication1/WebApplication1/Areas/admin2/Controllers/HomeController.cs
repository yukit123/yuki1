using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.admin2.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin2/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}