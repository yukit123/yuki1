using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Home
        //[HttpPost]
        public ActionResult Index()
        {
            //return RedirectToAction("Index","Home",new { area="Home"});
            return View();
        }

        //[HttpPost]
        public ActionResult Index2()
        {
            return View();
        }
    }
}