using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TestApplication1.Models;

namespace TestApplication1.Controllers
{
    public class Home2Controller : Controller
    {
        private TestApplication1Context db = new TestApplication1Context();
        // GET: Home2
        public ActionResult Index()
        {
            return View();
        }

        #region  checkbox 
        // GET: Home/Create
        public ActionResult Create()
        {

            return View();
        }

        //POST: Home/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(List<expert> model)
        //{
        //    //  if (ModelState.IsValid)
        //    {

        //        //string strExpertise = string.Empty;

        //        //db.Entry(model).Property("preference").CurrentValue = preference;



        //        db.experts.Add(model);
        //        try
        //        {
        //            db.SaveChanges();
        //            return RedirectToAction("Confirmation");
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ToString();
        //            return View(model);
        //        }
        //    }


        //}
        public ActionResult Confirmation()

        {
            ViewData["Message"] = "Thank you for submitting the information form!";
            return View();
        }
        #endregion


        public class MessagesVM
        {
            public int RMAID { get; set; }
            public string MSG { get; set; }

            public string MSGType { get; set; }

        }

        public ActionResult Partial_Index()
        {
            ViewData["Message"] = "Thank you for submitting the information form!";
            return View();
        }

        //[ChildActionOnly]
        public ActionResult GetMessages()
        {

            List<MessagesVM> query = (from RB in db.Charters

                                      where RB.CharterID == 4

                                      select new MessagesVM
                                      {
                                          RMAID = RB.CharterID,
                                          MSG = RB.CharterSchoolDepartment,
                                          MSGType = RB.CharterIdentifierString


                                      }).ToList();

            return PartialView("GetMessages", query);
        }
        public JsonResult UpdateMSGStatus(int IDMSG, string ChangeStu)
        {
            var list = new List<MessagesVM>
            {
                new MessagesVM{MSG="Apple2",RMAID=1,MSGType="tApple2"},
                new MessagesVM{MSG="Banana",RMAID=2,MSGType="tBanana"},
                new MessagesVM{MSG="Orange",RMAID=3,MSGType="tOrange"},
                new MessagesVM{MSG="Banana",RMAID=4,MSGType="tBanana"},
                new MessagesVM{MSG="Orange",RMAID=5,MSGType="tOrange"},
                new MessagesVM{MSG="Banana",RMAID=2,MSGType="tBanana"},
                new MessagesVM{MSG="Banana",RMAID=4,MSGType="tBanana"},
                new MessagesVM{MSG="Banana",RMAID=5,MSGType="tBanana"}
            };
            var u = list.Where(a => a.RMAID == IDMSG).FirstOrDefault();
            if (u != null)
            {
                u.MSGType = ChangeStu;
                u.RMAID = IDMSG;
                db.SaveChanges();

            }
            return Json(u, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UiGrid()
        {

            return View();
        }

        #region Dynamically added table row not binding with Model Class

        public class PurchaseOrderWithDetails
        {
            public author2 po { get; set; }
            public List<book2> od { get; set; }

        }

        public ActionResult Create_Index()
        {
            //ViewBag.FiscalYear = new SelectList(db.FiscalYearTables.ToList(), "FiscalYear", "FiscalYear");
            //ViewBag.Vendorlist = new SelectList(db.VendorTables.ToList(), "VendorName", "VendorName");

            PurchaseOrderWithDetails pwod = new PurchaseOrderWithDetails();
            pwod.po = new author2();
            pwod.od = db.book2s.ToList();
            return View(pwod);
        }
        #endregion

        #region Microsoft Chart in MVC Application 
        public ActionResult CreateBar()
        {
            //Create bar chart
            var chart = new Chart(width: 300, height: 200)
            .AddSeries(chartType: "bar",
                            xValue: new[] { "10 ", "50", "30 ", "70" },
                            yValues: new[] { "50", "70", "90", "110" })
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult CreatePie()
        {
            //Create bar chart
            var chart = new Chart(width: 300, height: 200)
            .AddSeries(chartType: "pie",
                            xValue: new[] { "10 ", "50", "30 ", "70" },
                            yValues: new[] { "50", "70", "90", "110" })
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult CreateLine()
        {
            //Create bar chart
            var chart = new Chart(width: 600, height: 200)
            .AddSeries(chartType: "line",
                            xValue: new[] { "10 ", "50", "30 ", "70" },
                            yValues: new[] { "50", "70", "90", "110" }
                            )
            .AddSeries(chartType: "line",
                            xValue: new[] { "15 ", "34", "58 ", "78" },
                            yValues: new[] { "23", "45", "11", "68" }
                            )
             .AddSeries(chartType: "line",
                            xValue: new[] { "2 ", "12", "36 ", "70" },
                            yValues: new[] { "12", "6", "34", "78" }
                            )
             .AddSeries(chartType: "line",
                            xValue: new[] { "33 ", "23", "55 ", "9" },
                            yValues: new[] { "11", "77", "28", "55" }
                            )
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult Chart_Index() //https://www.codeproject.com/Tips/801587/Microsoft-Chart-in-MVC-Application
        {
            return View("Chart_Index");
        }
        #endregion

        #region Uploading an image file to a web server
        public class BOARD
        {
            public int BRD_ID { get; set; }
            public string CTGRY_CD { get; set; }
            public DateTime REG_DT { get; set; }
            public string STATUS { get; set; }
            public string USER_ID { get; set; }       

        }

        public ActionResult Gallery_Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Gallery_Create2(HttpPostedFileBase file2)
        {
            var isSuccess = "T";
            var message = "게시글을 등록했습니다.";

   
                var idChar = "NT";
                var today = DateTime.Now.ToString("yyyyMMdd");

        

                // Install_images 
                string strThumnail = Request.Form.Get("THUMNAIL");
                //var bytes = Convert.FromBase64String(strThumnail.Split('\\')[5]);
            var file = Request.Files[0];
            string filePath = "/images/";
                string fileName = 2 + "-00001.jpg";

            //Image image = Image.FromStream(new MemoryStream(bytes));
            file.SaveAs(Server.MapPath("~" + filePath + fileName));
  

            //db.INSTALL_IMG.Add(new INSTALL_IMG { BRD_ID = model.BRD_ID, FILE_NM = fileName, FILE_PATH = filePath, NO = 1, THUMNAIL_YN = "Y" });

            //// DB Save
            //db.SaveChanges();


            return Json(new { isSuccess = isSuccess, message = message });
        }
        #endregion
    }
}