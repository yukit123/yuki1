using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArrayList arrayList = new ArrayList() { 1, "abc", 33.5M };
            StringBuilder a = new StringBuilder();
            foreach (object obj in arrayList) a.Append(obj);
            string str = a.ToString();
            return View();
        }

       
    }
}