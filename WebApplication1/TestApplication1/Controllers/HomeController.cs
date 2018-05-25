﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication1.Models;


namespace TestApplication1.Controllers
{
    public class HomeController : Controller
    {
        private TestApplication1Context db = new TestApplication1Context();
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

        #region How to use checkbox and submit the check values  https://forums.asp.net/t/1943984.aspx?How+to+use+checkbox+and+submit+the+check+values+

        public class Product
        {
            public int ProductId { get; set; }
            public float Price { get; set; }

            //other things

        }
        public class SelectableProduct : Product
        {
            public bool IsSelected { get; set; }
        }

        public ActionResult check_List()
        {
            var products = new List<Product>
            {
                new Product{ Price =11.20f, ProductId = 1},
                new Product{ Price =12.20f, ProductId = 2},
                new Product{ Price =15.20f, ProductId = 3},

            };

            //use AutoMapper
            return View(products.Select(m => new SelectableProduct { Price = m.Price, ProductId = m.ProductId }).ToList());
        }

        [HttpPost]
        public ActionResult check_List(IEnumerable<SelectableProduct> item)
        {
            var userSelectedProducts = item.Where(m => m.IsSelected);
            if (userSelectedProducts != null && userSelectedProducts.Any())
            {
                //return another view
            }

            return View(item);
        }

        #endregion

        #region How to make Check Box List in ASP.Net MVC https://stackoverflow.com/questions/37778489/how-to-make-check-box-list-in-asp-net-mvc
        public class HomeModel
        {
            public IList<string> SelectedFruits { get; set; }
            public IList<SelectListItem> AvailableFruits { get; set; }

            public HomeModel()
            {
                SelectedFruits = new List<string>();
                AvailableFruits = new List<SelectListItem>();
            }
        }

        public ActionResult check_Index()
        {
            var model = new HomeModel
            {
                AvailableFruits = GetFruits()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult check_Index(HomeModel model)
        {
            if (ModelState.IsValid)
            {
                var fruits = string.Join(",", model.SelectedFruits);

                // Save data to database, and redirect to Success page.

                //return RedirectToAction("Success");
            }
            model.AvailableFruits = GetFruits();
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        private IList<SelectListItem> GetFruits()
        {
            return new List<SelectListItem>
        {
            new SelectListItem {Text = "Apple", Value = "Apple"},
            new SelectListItem {Text = "Pear", Value = "Pear"},
            new SelectListItem {Text = "Banana", Value = "Banana"},
            new SelectListItem {Text = "Orange", Value = "Orange"},
        };
        }
        #endregion

        #region partial view https://forums.asp.net/t/2132585.aspx
        public class Store
        {
            public int StoreID { get; set; }
            public string StoreName { get; set; }

        }
        public ActionResult ValidateBothModel()
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult ValidateBothModel([Bind(Include = "StoreID,StoreName")] Store store)
        {
            if (ModelState.IsValid)
            {
                //db.Author(store);
                //db.SaveChanges();
                return View();
            }
            return View();
        }
        public class BuyItem
        {
            public int ItemID { get; set; }
            public int StoreID { get; set; }
            public string ItmeName { get; set; }

        }
        public ActionResult BuyItem2()
        {
          
            return PartialView();
        }

        [HttpPost]
        public ActionResult BuyItem2([Bind(Include = "ItemID,StoreID,ItmeName")] BuyItem item)
        {
            if (ModelState.IsValid)
            {
                //db.BuyItem.Add(item);
                //db.SaveChanges();
                return RedirectToAction("ValidateBothModel");
            }
            TempData["ViewData"] = ViewData;
            return RedirectToAction("ValidateBothModel");
        }
        #endregion


        // GET: /Assignment/
        public ViewResult Property_Index(string sortOrder, string searchString)
        {
            ViewBag.CharterID = db.Charters.Select(a => new SelectListItem
            {
                Value = a.CharterID.ToString(),
                Text = a.CharterDestinationLocation1 + " " + a.CharterGroup + " " + a.CharterGroupLevelString + " " + a.CharterGroupGenderString
            }
           ).ToList();

            //ViewBag.AssignmentSort = String.IsNullOrEmpty(sortOrder) ? "assignment_desc" : "";
            ////ViewBag.ResourceSort = sortOrder == "Shift" ? "shift_desc" : "Shift";

            ////_____________________________________________

            //var assignments = db.Assignments.Include(a => a.Calendar).Include(a => a.Charter).Include(a => a.Contact).Include(a => a.HistoryEmployee).Include(a => a.HistoryResource).Include(a => a.Resource).Include(a => a.ResourceDirection).Include(a => a.ResourceDocument).Include(a => a.ResourceOffice).Include(a => a.Route);

            ////_____________________________________________

            ////var assignments = from s in db.Assignments
            ////               select s;

            ////_____________________________________________

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    assignments = assignments.Where(s => s.AssignmentDesignatorString.Contains(searchString));
            //    //|| s.CharterDestinationLocation1.Contains(searchString)
            //    //|| s.CharterGroup.Contains(searchString));
            //}
            //switch (sortOrder)
            //{
            //    default:
            //        assignments = assignments.OrderBy(s => s.AssignmentDate);
            //        break;
            //    // .ThenBy(s => s.CharterTimeString)
            //    case "charter_desc":
            //        assignments = assignments.OrderByDescending(s => s.AssignmentDate);
            //        break;
            //        // .ThenBy(s => s.CharterTimeString)
            //        //case "Shift":
            //        //    resources = resources.OrderBy(s => s.DateShiftString);
            //        //    break;
            //        //case "shift_desc":
            //        //    resources = resources.OrderByDescending(s => s.DateShiftString);
            //        //    break;
            //}
            //return View(assignments);
            var assignments = db.Charters.ToList();
            return View(assignments);

        }

        public ActionResult Focus()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReturnArray()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}