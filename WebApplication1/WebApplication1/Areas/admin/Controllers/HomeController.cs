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
            //return RedirectToAction("Index2","Home",new { area="Home"});
            //return RedirectToAction("HakkimizdaEkle",new { area = "admin" });
            //return RedirectToAction("Index2", "Home", new { area = "admin" });
            return View();
        }

        //[HttpPost]
        public ActionResult Index2()
        {
            return View();
        }
    }
}