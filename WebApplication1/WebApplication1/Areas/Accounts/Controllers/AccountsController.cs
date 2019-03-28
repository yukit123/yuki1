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
        // GET: Accounts/Accounts
        public ActionResult Index()
        {
            return View();
        }
    }
}