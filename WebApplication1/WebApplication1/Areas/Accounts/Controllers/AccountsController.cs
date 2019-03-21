using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static WebApplication1.FilterConfig;


namespace WebApplication1.Areas.Accounts.Controllers
{
    //[SessionExpireFilter2]
    public class AccountsController : Controller
    {
        public class Car
        {
            public int Id { get; set; }
            public string Colour { get; set; }
        }

     

        // GET: Accounts/Accounts
        public ActionResult Index()//Html.DisplayForModel与action的返回有关 https://forums.asp.net/p/2153813/6255405.aspx?p=True&t=636885543646542577 case
        {
            var car = new Car { Id = 1, Colour = "Black" };

            return View(car);
        }
    }
}