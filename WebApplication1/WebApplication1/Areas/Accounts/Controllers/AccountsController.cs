using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Accounts.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts/Accounts
        public ActionResult Index()
        {
            return View();
        }
    }
}