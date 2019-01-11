using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TestApplication1.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.Entity.Infrastructure;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using PdfSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text;
using System.Globalization;
using MySql.Data.MySqlClient;
using Rotativa;
using LINQtoCSV;
using Microsoft.Security.Application;
using Aspose.Words;


namespace TestApplication1.Controllers
{
    public class Home2Controller : Controller
    {
        private TestApplication1Context db = new TestApplication1Context();
        // GET: Home2
        public ActionResult Index()
        {

            //var assignments = from s in db.book2s.Include(b => b.author2)
            //                  where s.Title == "t1"
            //                  select s;

            #region https://forums.asp.net/t/2149906.aspx
            ////string nowdate = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
            ////DateTime nowdate2 = Convert.ToDateTime(nowdate);
            //DateTime dt = Convert.ToDateTime("12/4/2018 13:00:00");
            ////DateTime dat = new DateTime(2015, 1, 6);
            //// dat.AddMonths(1).ToString("d");
            //DateTime oneMonthAgo = DateTime.Now.AddMonths(1);
            ////        int days = DateTime.DaysInMonth(oneMonthAgo.Year, oneMonthAgo.Month);
            ////        var list=Enumerable.Range(1, DateTime.DaysInMonth(oneMonthAgo.Year, oneMonthAgo.Month)).Select(day =>
            ////new DateTime(oneMonthAgo.Year, oneMonthAgo.Month, day)).ToList();

            //var selectedDates = new List<DateTime>();
            //var selectedmins = new List<DateTime>();

            ////for (var date = nowdate2; date <= oneMonthAgo; date = date.AddDays(1))
            ////{
            ////    selectedDates.Add(date);
            ////}

            //for (var date = dt; date <= oneMonthAgo; date = date.AddMinutes(15))
            //{
            //    if ((date.DayOfWeek == DayOfWeek.Monday && date.Hour >= 10 && date.Hour < 12) || (date.DayOfWeek == DayOfWeek.Tuesday && date.Hour >= 12 && date.Hour < 14) || (date.DayOfWeek == DayOfWeek.Thursday && date.Hour >= 10 && date.Hour < 14))
            //    {
            //        selectedmins.Add(date);
            //    }
            //    else
            //    {
            //        continue;

            //    }
            //}

            ////var listb = selectedDates.Where(_ => _.DayOfWeek == DayOfWeek.Monday || _.DayOfWeek == DayOfWeek.Tuesday || _.DayOfWeek == DayOfWeek.Thursday).ToList();

            ////TimeSpan timeSpan = Convert.ToDateTime("10:00") - Convert.ToDateTime("12:00");
            ////TimeSpan ts = oneMonthAgo.Subtract(nowdate2).Duration();

            #endregion

            return View();
        }

        #region  checkbox 
        public class Like
        {
            public int Id { get; set; }
            public string Info { get; set; }
            public DateTime PostedOn { get; set; }
        }
        public class Comment
        {
            public int Id { get; set; }
            public string Info { get; set; }
            public DateTime PostedOn { get; set; }
        }


        // GET: Home/Create
        public ActionResult Create()
        {
            #region Union
            //DateTime xx = DateTime.ParseExact("14/11/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime date = DateTime.ParseExact("14/11/2018", "dd/MM/yyyy", null);
            //List<Like> Likes = new List<Like>()
            // {
            //     new Like(){Id=1,Info="A", PostedOn=DateTime.ParseExact("14/11/2018", "dd/MM/yyyy", null) },
            //     new Like(){Id=2,Info="B", PostedOn=DateTime.ParseExact("17/11/2018", "dd/MM/yyyy", null) },
            //     new Like(){Id=1,Info="C", PostedOn=DateTime.ParseExact("18/11/2018", "dd/MM/yyyy", null) },
            // };

            //List<Comment> Comments = new List<Comment>()
            // {
            //     new Comment(){Id=1,Info="D", PostedOn=DateTime.ParseExact("15/11/2018", "dd/MM/yyyy", null) },
            //     new Comment(){Id=2,Info="E", PostedOn=DateTime.ParseExact("16/11/2018", "dd/MM/yyyy", null) },
            //     new Comment(){Id=1,Info="F", PostedOn=DateTime.ParseExact("19/11/2018", "dd/MM/yyyy", null) },
            // };
            //var unionlist = ((from like in Likes
            //                  select new Comment
            //                  {
            //                      Id = like.Id,
            //                      Info = like.Info,
            //                      PostedOn = like.PostedOn
            //                  })
            //                           .Union(from comment in Comments
            //                                  select comment)).OrderBy(_ => _.PostedOn).ToList();
            #endregion https://forums.asp.net/t/2150269.aspx
            var list = db.Student121s.Include(_ => _.Address).ToList();
            var list2 = db.StudentAddress121s.Include(_ => _.Student).ToList();

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
            #region XSS AntiXSS 从html中删除所有脚本和非标准元素，从而使用户键入的html安全。https://forums.asp.net/t/2150613.aspx
            //ViewBag.query = "<a href='#' id='site' class='btn' data-content='{&quot;RowId&quot;:714886,&quot;SequenceNumber&quot;:1,&quot;Order&quot;:0}' data-assettypeid='1' onclick='ECL.RequestButton(this); return false;'>Sample</a>";
            //ViewBag.query2 = "<a href='#' id='site' class='btn' data-content='111' data-assettypeid='1' onclick='ECL.RequestButton(this); return false;'>Sample</a>";
            //var url = "<a href=\"http://search.msn.com/results.aspx?q=[Untrusted-input]\">Click Here!</a>";
            //string safeHtml = Microsoft.Security.Application.Sanitizer.GetSafeHtml(ViewBag.query2);

            //var html = "<a href=\"#\" onclick=\"alert();\" data-content='111'>aaaaaaaaa</a>javascript<P><IMG SRC=javascript:alert('XSS')><javascript>alert('a')</javascript><IMG src=\"abc.jpg\"><IMG><P>Test</P>";

            //string safeHtml2 = Microsoft.Security.Application.Sanitizer.GetSafeHtml(html);
            //string Name = AntiXss.HtmlEncode(url);
            #endregion
            ViewData["Message"] = "Thank you for submitting the information form!";
            //Session["anoterText"] = "Going to abandon";//与Session_End有关，如果注释掉不能进入Session_End
            //Session.Abandon();
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

            return PartialView("_GetMessages", query);
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

        public ActionResult ElecMechLogs(string aa)
        {
            //Create bar chart
            var chart = new Chart(width: 1000, height: 700)


                        .AddTitle("Maintenance Graphs")

                           .AddSeries(
                            chartType: "Bar",
                           xValue: new[] { "15 ", "34", "58 ", "78" }, xField: "Readings",
                           yValues: new[] { "50", "70", "90", "110" }, yFields: "Datestaken")
                           .Write();
            chart.Save("~/Content/chart.bmp");
            var filepath = "~/Content/chart.bmp";
            return File(filepath, "image/bmp");

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

        #region System.Web.Mvc.HttpHandlerUtil+ServerExecuteHttpHandlerAsyncWrapper
        //public class AppMenuParam
        //{
        //    public int ApplicationID { get; set; }
        //    public string serverLoc { get; set; }

        //}
        public class ApplicationMenuDO
        {
            public int ApplicationID { get; set; }
            public string ApplicationStr { get; set; }

        }

        public ActionResult SideBar_Index()
        {

            #region Check if the value not key exists in app.config file
            //var flag = 1;
            //var MyKey = "TN";
            //if (ConfigurationManager.AppSettings.AllKeys.Contains("PageSize"))
            //{
            //    flag = 1;
            //}
            //if (ConfigurationManager.AppSettings.AllKeys.Any(key => key == MyKey))
            //{
            //    // Key exists
            //}

            //var MyReader = new System.Configuration.AppSettingsReader();
            //string keyvalue = MyReader.GetValue("PageSize", typeof(string)).ToString();

            //string[] repositoryUrls = ConfigurationManager.AppSettings.AllKeys
            //                 .Where(key => key.StartsWith("TS"))
            //                 .Select(key => ConfigurationManager.AppSettings[key])
            //                 .ToArray();

            //foreach (var item in ConfigurationManager.AppSettings.AllKeys.ToList())//https://forums.asp.net/p/2147937/6233866.aspx?p=True&t=636751562067955347
            //{
            //    if (ConfigurationManager.AppSettings[item] == "TS")
            //    {

            //    }
            //}
            #endregion
            return View();
        }

        public ActionResult SideBar()
        {
            List<ApplicationMenuDO> crresult = new List<ApplicationMenuDO>();

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("www.baidu.com");
                //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                //HttpResponseMessage response = client.GetAsync("/Services/Utilities.svc/GetApplicationMenu/1/5").Result;

                //var stringData = response.Content.ReadAsStringAsync().Result;

                //JObject result = JObject.Parse(stringData);

                //var clientarray = result["GetApplicationMenuResult"].Value<JArray>();
                //List<ApplicationMenuDO> clients = clientarray.ToObject<List<ApplicationMenuDO>>();

                var clients = new List<ApplicationMenuDO>
            {
                new ApplicationMenuDO{ApplicationID=1,ApplicationStr="f1"},
                new ApplicationMenuDO{ApplicationID=2,ApplicationStr="f2"},
                new ApplicationMenuDO{ApplicationID=3,ApplicationStr="f3"},
                new ApplicationMenuDO{ApplicationID=4,ApplicationStr="f4"}

            };

                return PartialView("_SideBar", clients);
            }
        }
        #endregion
        #region https://forums.asp.net/t/2146927.aspx .Find()

        public StudentAccount StudentLogin(string uname, string passwd)
        {
            StudentAccount dbEntry = db.StudentAccounts.Where(x => x.Username == uname && x.Password == passwd).SingleOrDefault();
            if (dbEntry != null)
            {

            }
            return dbEntry;
        }


        public ViewResult Login_Index(string username, string password)
        {
            StudentAccount studentAccount = new StudentAccount();
            if (ModelState.IsValid)
            {
                var login = StudentLogin(username, password);

                TempData["message"] = string.Format(" Login successful");
                return View("Login_Index");
            }
            else
            {             // there is something wrong with the data values               
                return View(studentAccount);
            }
        }
        #endregion
        #region Raw SQL Queries https://forums.asp.net/t/2146612.aspx
        public class tablevm
        {
            public int id { get; set; }
            public string product { get; set; }
            public int price { get; set; }
        }
        public class tablevm2
        {
            public int uid { get; set; }
            public string uname { get; set; }
            public string pwd { get; set; }
        }

        public ActionResult RawSQL()
        {

            #region CultureInfo.InvariantCulture https://forums.asp.net/p/2148118/6234395.aspx?p=True&t=636754152515878371
            //https://www.cnblogs.com/GreenLeaves/p/6757917.html
            //https://blog.csdn.net/gangzhucoll/article/details/52174023 主要
            string[] arr = { "Ab", "aB", "AB", "ab", "Abccccccc", "aBccccc", "Abd" };
            string[] arr2 = { "1/2/2018", "2/1/2018" };//mm/dd/yyyy "1/2/2018"<"2/1/2018"  "1/2/2018" >"2/1/2018"

            string[] arr3 = { "01/2/2018", "1/2/2018" }; //"01/2/2018">"1/2/2018"

            string[] arr4 = { "1/2/2018", "2/1/2018" };//dd/mm/yyyy "1/2/2018">"2/1/2018"  "1/2/2018" >"2/1/2018"
            Array.Sort<string>(arr, StringComparer.Ordinal);
            Debugger.Log(0, null, String.Join("\n", arr3));

            Array.Sort<string>(arr, StringComparer.InvariantCulture);
            Debugger.Log(0, null, "\n#################\n");
            Debugger.Log(0, null, String.Join("\n", arr3));

            #endregion
            #region Sum nested values with Linq （SelectMany）https://forums.asp.net/t/2147726.aspx
            var total = (from user in db.author2s
                         from order in user.book2
                         select (int?)order.Id).Sum() ?? 0;
            var total2 = db.author2s.SelectMany(user => user.book2).Sum(product => (int?)product.Id) ?? 0;
            #endregion
            #region Combine two columns into one column in linq（SelectMany） https://forums.asp.net/t/2147635.aspx
            var l = (from s in db.CountrySizes
                     where s.size.StartsWith("b") || s.country.StartsWith("F")
                     select new { Name = s.size }).Distinct().OrderBy(s => s.Name).ToList();
            var ls = (from s in db.CountrySizes
                      where s.size.StartsWith("b") || s.country.StartsWith("F")
                      select new { s.Id, s.country, s.size, s.value }).ToList();
            //var lss = (from s in db.CountrySizes
            //          where s.size.StartsWith("b") || s.country.StartsWith("F")
            //          select new {  Name=s.size.Union(s.country)}).ToList();
            var allItems = db.CountrySizes
                .Where(s => s.size.StartsWith("b") || s.country.StartsWith("F"))
                .Select(t => new[] { t.size, t.country })
                .SelectMany(i => i).Distinct().OrderBy(i => i)
                .ToList();

            var allItems2 = db.CountrySizes
               .Where(s => s.size.StartsWith("b") || s.country.StartsWith("F"))
               .SelectMany(c => new[] { c.country, c.size }).Distinct().OrderBy(i => i)
               .ToList();
            #endregion

            //显示explicitly添加主键https://forums.asp.net/p/2147073/6230529.aspx?p=True&t=636730908382274261 //SET IDENTITY_INSERT StudentAccounts ON;  
            db.Database.ExecuteSqlCommand("insert into StudentAccounts values('Conditioner', 'expense4');");
            var query = db.StudentAccounts.SqlQuery("select * from StudentAccounts").ToList<StudentAccount>();
            var query2 = db.Database.SqlQuery<StudentAccount>("select * from StudentAccounts").ToList<StudentAccount>();
            var query4 = db.Database.SqlQuery<tablevm2>("select Userid as uid,Username as uname,Password as pwd from StudentAccounts").ToList<tablevm2>();
            var query3 = db.Database.SqlQuery<tablevm>("select t1.Username, t1.Password, SUM(t1.Userid) as price from StudentAccounts as t1 group by t1.Password,t1.Username").ToList<tablevm>();


            ViewBag.Provlist = new SelectList(query2, "Userid", "Username");

            #region String Format
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
            //http://www.runoob.com/python/att-string-format.html
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.boundfield.dataformatstring?redirectedfrom=MSDN&view=netframework-4.7.2#System_Web_UI_WebControls_BoundField_DataFormatString
            //http://www.csharp-examples.net/string-format-double/
            var list = db.StudentAccounts.ToList().FirstOrDefault();
            #endregion
            return View(list);
        }

        #endregion

        #region Saving data to the json file(Newtonsoft,Json.NET) 
        //deserializes JSON into a collection(List<string>) by NewtonSoft https://www.newtonsoft.com/json/help/html/DeserializeCollection.htm
        //or by HttpClient extension methods https://stackoverflow.com/questions/24131067/deserialize-json-to-array-or-list-with-httpclient-readasasync-using-net-4-0-ta //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public ActionResult jsonFile()//https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
        {
            //https://stackoverflow.com/questions/50207714/save-data-to-json-file-use-angular-js-and-asp-net-mvc-actions
            //http://www.cnblogs.com/yanweidie/p/4605212.html
            //https://forums.asp.net/p/2147069/6230491.aspx?p=True&t=636730799151782689 CASE
            Model model = new Model
            {
                Id = 2,
                Name = "aaa111222"
            };

            #region This sample serializes JSON to a file.
            // serialize JSON to a string and then write string to a file
            System.IO.File.WriteAllText(@"D:\model3.json", JsonConvert.SerializeObject(model));

            // serialize JSON directly to a file
            //using (StreamWriter file = System.IO.File.CreateText(@"d:\model2.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, model);
            //}
            #endregion


            #region This sample deserializes JSON retrieved from a file.
            // read file into a string and deserialize JSON to a type
            Model model2 = JsonConvert.DeserializeObject<Model>(System.IO.File.ReadAllText(@"D:\model3.json"));

            // deserialize JSON directly from a file
            //using (StreamReader file = System.IO.File.OpenText(@"D:\model3.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Model model3 = (Model)serializer.Deserialize(file, typeof(Model));
            //}
            #endregion
            return View();
        }
        #endregion

        #region loading icon
        public ActionResult LoadingIcon()//https://forums.asp.net/p/2147203/6230964.aspx?p=True&t=636734159695481938
        {

            return View();
        }

        public JsonResult LoadingIcon_GetCurrentTime(/*string name*/) // public static string GetCurrentTime(string name)
        {
            System.Threading.Thread.Sleep(2000);
            //return "Hello " + name + Environment.NewLine + "The Current Time is: "
            //    + DateTime.Now.ToString();
            var list = db.CountrySizes.ToList();
            return Json(new { flag = 1, list }, JsonRequestBehavior.AllowGet);


        }
        #endregion
        #region  https://forums.asp.net/t/2147256.aspx
        public ActionResult RealTimeReports()
        {

            return View();
        }
        #endregion

        #region  File upload in ASP.NET MVC using Dropzone JS and HTML5
        public ActionResult SaveUploadedFile_Index()//https://www.codeproject.com/Articles/874215/File-upload-in-ASP-NET-MVC-using-Dropzone-JS-and-H fail
        {
            //https://forums.asp.net/t/2084302.aspx?File+upload+with+Dropzone+JS+in+MVC get
            //https://qawithexperts.com/article/asp.net/file-uploading-using-dropzone-js-html5-in-mvc/81 get
            //https://www.telerik.com/blogs/upload-large-files-asp-net-radasyncupload not DropzoneJS
            //https://forums.asp.net/p/2147323/6231492.aspx?p=True&t=636736918300808180
            return View();
        }
        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {

                        var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));//images-WallImages

                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                        var fileName1 = Path.GetFileName(file.FileName);

                        bool isExists = System.IO.Directory.Exists(pathString);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);

                    }

                }

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }
        #endregion
        #region 复杂模型 造假数据

        //public class StudentCourse_VM
        //{
        //    public List<ExamViewModel> ExamDetails { get; set; }
        //    public string Action { get; set; }

        //    public IEnumerable<SelectListItem> GradeItems { get; set; }

        //}
        public class StudentCourse_VM
        {
            public Student Student { get; set; }
            public List<Course> CourseList { get; set; }
            public IEnumerable<SelectListItem> GradeItems { get; set; }

        }
        public class Course
        {
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public string CourseCode { get; set; }
        }
        public class Student
        {
            public int StuID { get; set; }
            public string StuName { get; set; }
            public int Age { get; set; }
            public bool? ResourceDVR { get; set; }
        }
        public ActionResult ComplexModel_Data() // https://forums.asp.net/t/2146765.aspx
        {

            //https://forums.asp.net/t/2147638.aspx DropDownListFor inline
            var GradesList = new List<SelectListItem>();

            for (int i = 5; i <= 10; i++)
            {
                GradesList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() }); ;
            }

            //   ViewBag.GradesList1 = new SelectList(GradesList);

            StudentCourse_VM vm = new StudentCourse_VM();
            vm.Student = new Student() { StuID = 1001, StuName = "AA", Age = 22 };
            vm.CourseList = new List<Course>() {
                new Course(){ CourseID= 6, CourseName = "CA", CourseCode="C001"},
                new Course(){ CourseID= 7, CourseName = "CB", CourseCode="C002"},
                new Course(){ CourseID= 8, CourseName = "CC", CourseCode="C003"},
            };
            vm.GradeItems = GradesList;
            return View(vm);
        }
        //@Html.EditorFor(m => m.CourseList[i].CourseID, new { htmlAttributes = new { @class = "text-center" } })

        #endregion
        #region bootstrap tab
        public ActionResult bootstrapTab()
        {

            return View();
        }
        #endregion

        #region https://forums.asp.net/t/2147685.aspx#
        public ActionResult Details()
        {
            //var qry = (from a in db.book2s

            //           where a.Author_id == new Guid("fa7a3719-6568-e811-b856-8cec4b594df1")

            //           select a).ToList();
            book2 book2 = db.book2s.Find(1);
            return View(book2);
        }
        [HttpGet]
        public ActionResult Publications(/*Guid id*/)
        {

            var qry = (from a in db.book2s

                       where a.Author_id == new Guid("fa7a3719-6568-e811-b856-8cec4b594df1")

                       select a).FirstOrDefault();




            if (qry == null)
            {
                return HttpNotFound();
            }
            // return PartialView("_PartialDialog", qry);
            return PartialView(qry);

        }
        #endregion
        #region
        public ActionResult DropAppliPopup_Index()
        {

            return View();
        }
        public ActionResult DropAppliPopup(string Objid, string Petname, string Petaddress, string opname, string opmotor)
        {
            //ViewBag.Year = new SelectList(db.tbl_Year.OrderByDescending(x => x.year), "year", "year");
            //ViewBag.DrpReason = new SelectList(db.tbl_DroppingReason, "id", "Reason");
            //ViewBag.Petname = Petname;
            //ViewBag.Petaddress = Petaddress;
            //ViewBag.Petid = Objid;
            //ViewBag.OName = opname;
            //ViewBag.OMotor = opmotor;

            return PartialView();
        }
        #endregion
        public class CountryModel
        {
            public List<Country> CountryList { get; set; }
            public string SelectedCountryId { get; set; }
        }
        public class Country
        {
            public string CountryName { get; set; }
        }
        public ActionResult GetCountry_Index()
        {
            CountryModel objcountrymodel = new CountryModel();
            objcountrymodel.CountryList = CountryDate();
            objcountrymodel.SelectedCountryId = "2";
            return View(objcountrymodel);
        }

        public List<Country> CountryDate()
        {
            List<Country> objcountry = new List<Country>();
            objcountry.Add(new Country { CountryName = "America" });
            objcountry.Add(new Country { CountryName = "Canada" });
            objcountry.Add(new Country { CountryName = "France" });
            objcountry.Add(new Country { CountryName = "China" });
            objcountry.Add(new Country { CountryName = "India" });
            return objcountry;
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult GetCountry(List<String> SelectedCountryId, CountryModel model2)
        {

            List<Country> model = CountryDate();

            foreach (var item in SelectedCountryId)
            {
                model.Add(new Country { CountryName = item });
            }


            return View(model);
        }

        #region Angular Js: two apps, controller

        public ActionResult Angular_Index()//https://forums.asp.net/p/2148004/6234048.aspx?p=True&t=636752434424073500  多控制器要用angular.bootstrap，注意加载顺序
        {

            return View();
        }

        #endregion
        #region dropdownlist to search
        public class TpSchoolSubject
        {
            [Key]
            public int SubjectID { get; set; }
            public string Subject { get; set; }
            public Int64 Userid { get; set; }
        }
        public class TpStudentSchoolSubject
        {
            [Key]
            public Int64 Id { get; set; }
            public Int64 AllocationID { get; set; }
            public int SubjectID { get; set; }
            public int StudentID { get; set; }
            // public string Subject { get; set; }//-Field not in TpStudentSchoolSubject. 
            public Int64 Userid { get; set; }
            [NotMapped]
            public virtual List<TpSchoolSubject> SubjectList { get; set; }
        }

        public ActionResult dropdownlist_search()
        {
            //var list = db.author2s.Find("fa7a3719-6568-e811-b856-8cec4b594df1");
            //var book2s2 = db.book2s.Include(b => b.author2).ToList();//using System.Data.Entity;

            //var book2s = db.author2s.ToList();
            //var list2 = db.author2s.Where(x=>x.Author_id==new Guid("fa7a3719-6568-e811-b856-8cec4b594df1")).ToList();
            //var nameCol = db.author2s­.First().GetTy­pe().GetProper­ties().Select(n => n.Name);反射

            //var list = db.CountrySizes.ToList();
            List<TpStudentSchoolSubject> vm = new List<TpStudentSchoolSubject>();
            vm.Add(new TpStudentSchoolSubject
            {
                Id = 1,
                AllocationID = 1,
                SubjectID = 2,
                StudentID = 1,
                Userid = 1,
                SubjectList = new List<TpSchoolSubject>() {
                new TpSchoolSubject(){ SubjectID= 2, Subject = "Maths",   Userid=3}
            }

            });

            vm.Add(new TpStudentSchoolSubject
            {
                Id = 2,
                AllocationID = 2,
                SubjectID = 3,
                StudentID = 2,
                Userid = 2,
                SubjectList = new List<TpSchoolSubject>() {
                new TpSchoolSubject(){ SubjectID= 3, Subject = "English",   Userid=3}
            }

            });
            return View(vm);
            // return View(list);
        }
        #endregion

        #region row autocomplete
        public ActionResult autocomplete_Index()
        {

            return View();
        }
        #endregion

        #region Core data-target
        public ActionResult Index_AddRoom()
        {
            string zFileu = Server.MapPath(@"~/images/") + "test.pdf";
           // var path = System.IO.Directory.CreateDirectory(@"~\images\odoiproject\");
            return View();

        }
        public ActionResult AddRoom()
        {

            return PartialView();

        }

        #endregion

        #region Passing a parameter to javascript function in MVC https://forums.asp.net/t/2148408.aspx
        //public class GetirCalisanOzetYanitViewModel
        //{
        //    public List<SelectListItem> List1 { get; set; }

        //    public List<OtherItem> List2 { get; set; }

        //    public GetirCalisanOzetYanitViewModel() : base()
        //    {
        //        this.List1 = new List<SelectListItem>();
        //        this.List2 = new List<OtherItem>();
        //    }
        //}
        //public class OtherItem
        //{
        //    public int QueryString { get; set; }
        //    public string OtherItemStr { get; set; }
        //}

        //public class Assignments
        //{
        //    public int QueryString { get; set; }
        //    public string OtherItemStr { get; set; }
        //}
        //public ActionResult Pass_parameter()
        //{

        //    var assignments = db.book2s.Include(b => b.author2);
        //    IQueryable<Assignments> assignments = from s in db.Assignments
        //                                          where Assignment.AssignmentContact != Contact.ContactDesignator1String
        //                                          || Assignment.AssignmentRoute != Route.RouteDesignatorString
        //                                          || Assignment.AssignmentVehicle != Resource.ResourceDesignatorString
        //                                          select s;
        //    assignments.Include(a => a.Calendar)
        //    .Include(a => a.Charter)
        //    .Include(a => a.Contact)
        //    .Include(a => a.HistoryEmployee)
        //    .Include(a => a.HistoryResource)
        //    .Include(a => a.Resource)
        //    .Include(a => a.ResourceDirection)
        //    .Include(a => a.ResourceDocument)
        //    .Include(a => a.ResourceOffice)
        //    .Include(a => a.Route);

        //    GetirCalisanOzetYanitViewModel vm = new GetirCalisanOzetYanitViewModel();
        //    vm.List1 = new List<SelectListItem>() {
        //        new SelectListItem(){Text="11",Value="11" },
        //        new SelectListItem(){Text="22",Value="22" }

        //    };
        //    vm.List2 = new List<OtherItem>() {
        //        new OtherItem(){QueryString=1,OtherItemStr="111" },
        //        new OtherItem(){QueryString=2,OtherItemStr="222" }

        //    };

        //    return View(vm);

        //}
        #endregion

        #region tree node string json
        class Node
        {
            public Node()
            {
                Children = new List<Node>();
            }

            public string Name { get; set; }
            public List<Node> Children { get; set; }
        }

        class NodeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Node));
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                Node node = (Node)value;
                JObject jo = new JObject();
                jo.Add("name", node.Name);
                if (node.Children.Count == 0)
                {
                    jo.Add("leaf", true);
                }
                else
                {
                    jo.Add("children", JArray.FromObject(node.Children, serializer));
                }
                jo.WriteTo(writer);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        public void Dictionary_Node()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Kitchen supplies", "Shopping / Housewares");
            dict.Add("Groceries", "Shopping / Housewares");
            dict.Add("Cleaning supplies", "Shopping / Housewares");
            dict.Add("Office supplies", "Shopping / Housewares");
            dict.Add("Retile kitchen", "Shopping / Remodeling");
            dict.Add("Ceiling", "Shopping / Remodeling / Paint bedroom");
            dict.Add("Walls", "Shopping / Remodeling / Paint bedroom");
            dict.Add("Misc", null);
            dict.Add("Other", "Shopping / Remodeling");

            Node root = new Node();
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Node parent = root;
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    Node child = null;
                    foreach (string part in kvp.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string name = part.Trim();
                        child = parent.Children.Find(n => n.Name == name);
                        if (child == null)
                        {
                            child = new Node { Name = name };
                            parent.Children.Add(child);
                        }
                        parent = child;
                    }
                }
                parent.Children.Add(new Node { Name = kvp.Key });
            }

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new NodeConverter() },
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(root, settings);

        }
        #endregion


        #region FullCalendar1

        public ActionResult GetEvents_Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetEvents()
        {

            var events = await db.CountrySizes.ToListAsync();
            //return Json(events, JsonRequestBehavior.AllowGet);
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        #endregion

        #region FullCalendar2
        public class PublicHoliday
        {
            public int Sr { get; set; }
            public string Title { get; set; }
            public string Desc { get; set; }
            public string Start_Date { get; set; }
            public string End_Date { get; set; }
        }

        public ActionResult FullCalendar_Index() //https://www.c-sharpcorner.com/article/asp-net-mvc5-full-calendar-jquery-plugin/
        {
            // Info.  
            return this.View();
        }

        public ActionResult GetCalendarData()
        {
            // Initialization.  
            JsonResult result = new JsonResult();

            //try
            //{
            //    // Loading.  
            //    List<PublicHoliday> data = this.LoadData();

            //    // Processing.  
            //    result = this.Json(data, JsonRequestBehavior.AllowGet);


            //}
            //catch (Exception ex)
            //{
            //    // Info  
            //    Console.Write(ex);
            //}

            // Return info.  
            //  return result;
            //List<PublicHoliday> data = this.LoadData();
            //return result = this.Json(data, JsonRequestBehavior.AllowGet);
            return new JsonResult { Data = this.LoadData(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private List<PublicHoliday> LoadData()
        {
            // Initialization.  
            List<PublicHoliday> lst = new List<PublicHoliday>();
            lst.Add(new PublicHoliday { Sr = 1, Title = "America", Desc = "Desc", Start_Date = "2018-10-01", End_Date = "2018-10-02" });
            lst.Add(new PublicHoliday { Sr = 2, Title = "Canada", Desc = "Desc", Start_Date = "2018-10-01", End_Date = "2018-10-02" });
            lst.Add(new PublicHoliday { Sr = 3, Title = "France", Desc = "Desc", Start_Date = "2018-10-01", End_Date = "2018-10-02" });
            lst.Add(new PublicHoliday { Sr = 4, Title = "China", Desc = "Desc", Start_Date = "2018-10-01", End_Date = "2018-10-02" });
            lst.Add(new PublicHoliday { Sr = 5, Title = "India", Desc = "Desc", Start_Date = "2018-10-01", End_Date = "2018-10-02" });
            //try
            //{
            //    // Initialization.  
            //    string line = string.Empty;
            //    string srcFilePath = "Content/files/PublicHoliday.txt";
            //    var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            //    var fullPath = Path.Combine(rootPath, srcFilePath);
            //    string filePath = new Uri(fullPath).LocalPath;
            //    StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

            //    // Read file.  
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        // Initialization.  
            //        PublicHoliday infoObj = new PublicHoliday();
            //        string[] info = line.Split(',');

            //        // Setting.  
            //        infoObj.Sr = Convert.ToInt32(info[0].ToString());
            //        infoObj.Title = info[1].ToString();
            //        infoObj.Desc = info[2].ToString();
            //        infoObj.Start_Date = info[3].ToString();
            //        infoObj.End_Date = info[4].ToString();

            //        // Adding.  
            //        lst.Add(infoObj);
            //    }

            //    // Closing.  
            //    sr.Dispose();
            //    sr.Close();
            //}
            //catch (Exception ex)
            //{
            //    // info.  
            //    Console.Write(ex);
            //}

            // info.  
            return lst;
        }

        #endregion

        #region static可以累计 https://forums.asp.net/t/2148585.aspx

        private static int mCount { get; set; }
        private static bool forced = false;

        public void mMethod(int number) //xx://home2/mMethod?number=2
        {
            mCount = number;
        }

        public void method2()
        {
            forced = true;
            var a = mCount;
            //Trying to access mCount from here always gives me 0

        }
        #endregion
        #region /"=>" quote
        // https://forums.asp.net/t/2148630.aspx
        //   https://stackoverflow.com/questions/9714759/put-quotes-around-a-variable-string-in-javascript
        #endregion

        #region send email
        public void bindStep3()//https://www.jb51.net/article/83803.htm
        {
            MailAddress MessageFrom = new MailAddress("925752959@qq.com"); //发件人邮箱地址 
            string MessageTo = "v-yuktao@microsoft.com"; //收件人邮箱地址 
            string MessageSubject = "激活验证"; //邮件主题 
            string MessageBody = "请进行邮箱验证来完成您注册的最后一步,点击下面的链接激活您的帐号：<br><a target='_blank' rel='nofollow' style='color: #0041D3; text-decoration: underline' href=''>激活</a>"; //邮件内容 （一般是一个网址链接，生成随机数加验证id参数，点击去网站验证。）

            if (SendMail(MessageFrom, MessageTo, MessageSubject, MessageBody))
            {
                Response.Write("<script type='text/javascript'>alert('发送邮件cg');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('发送邮件失败');</script>");
            }
            //  TempData["CompanyBind3"] = company;
            // return View("bindStep3");
        }

        public bool SendMail(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody)  //发送验证邮件
        {
            MailMessage message = new MailMessage();

            //message.To.Add(MessageTo);
            //message.From = MessageFrom;
            //message.Subject = MessageSubject;
            //message.SubjectEncoding = System.Text.Encoding.UTF8;
            //message.Body = MessageBody;
            //message.BodyEncoding = System.Text.Encoding.UTF8;
            //message.IsBodyHtml = true; //是否为html格式 
            //message.Priority = MailPriority.High; //发送邮件的优先等级 


            message.To.Add(MessageTo);
            message.From = new MailAddress(MessageFrom.ToString()); ;
            message.Subject = "subject";
            message.Body = "body";
            message.IsBodyHtml = true;


            //SmtpClient sc = new SmtpClient();
            //sc.EnableSsl = true;//是否SSL加密
            //sc.Host = "smtp.qq.com"; //指定发送邮件的服务器地址或IP 
            //sc.Port = 587; //指定发送邮件端口 
            //sc.Credentials = new System.Net.NetworkCredential("925752959@qq.com", "mzxmmnoxxsjxbfbf"); //指定登录服务器的用户名和密码(注意：这里的密码是开通上面的pop3/smtp服务提供给你的授权密码，不是你的qq密码)

            SmtpClient sc = new SmtpClient();
            sc.EnableSsl = true;//??SSL??
            sc.Host = "smtp.qq.com"; //?????????????IP 
            //sc.Port = 587; //???????? 
            sc.UseDefaultCredentials = false;
            //sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("925752959@qq.com", "mzxmmnoxxsjxbfbf");//https://service.mail.qq.com/cgi-bin/help?subtype=1&&no=1001256&&id=28


            try
            {
                sc.Send(message); //发送邮件 
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                return false;
            }
            return true;

        }
        #endregion

        #region Google maps polygon 多边形
        public class polygon
        {
            public int ID { get; set; }
            public string lat { get; set; }
            public string lng { get; set; }

        }
        public ActionResult GoogleMaps()//https://forums.asp.net/p/2148921/6237180.aspx?p=True&t=636773130468130348
        {

            List<polygon> model = new List<polygon>();
            model.Add(new polygon { ID = 1, lat = "25.774", lng = "-80.190" });
            model.Add(new polygon { ID = 2, lat = "18.466", lng = "-66.118" });
            model.Add(new polygon { ID = 3, lat = "32.321", lng = "-64.757" });

            return View(model);
        }
        #endregion

        #region 上传多个文件
        public class ProductImage
        {
            public int ID { get; set; }
            [Display(Name = "File")]
            [StringLength(100)]
            [Index(IsUnique = true)]
            public string FileName { get; set; }
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase[] files)
        {
            bool allValid = true;
            string inValidFiles = "";
            //check the user has entered a file
            if (files[0] != null)
            {
                //if the user has entered less than ten files
                if (files.Length <= 10)
                {
                    //check they are all valid
                    foreach (var file in files)
                    {
                        if (!ValidateFile(file))
                        {
                            allValid = false;
                            inValidFiles += ", " + file.FileName;
                        }

                    }
                    //if they are all valid then try to save them to disk
                    if (allValid)
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                SaveFileToDisk(file);
                            }
                            catch (Exception e)
                            {
                                ModelState.AddModelError("FileName", "Sorry ,and error has occured saving the file to disk,please try again.");
                            }

                        }
                    }
                    //else add an error listing out the invalid files
                    else
                    {
                        ModelState.AddModelError("FileName", "All files must be gif,png,jpeg or jpg and less than 2mb in size.The following files" + inValidFiles + "are not valid");
                    }

                }
                //the user has entered more than 10 files
                else
                {
                    ModelState.AddModelError("FileName", "Please only upload up to ten files at a time");
                }

            }
            //if the user has not entered a file return an error message
            else
            {
                ModelState.AddModelError("FileName", "Please choose a file");
            }

            if (ModelState.IsValid)
            {
                bool duplicates = false;
                bool otheDbError = false;
                string dublicatesFiles = "";
                foreach (var file in files)
                {
                    //try and save each file
                    var productToAdd = new ProductImage { FileName = file.FileName };
                    try
                    {
                        //db.ProductImages.Add(productToAdd);
                        db.SaveChanges();
                    }
                    //if there is an exception check if it is caused by a duplicate file
                    catch (DbUpdateException ex)
                    {
                        SqlException innException = ex.InnerException.InnerException as SqlException;
                        if (innException != null && innException.Number == 2601)
                        {
                            dublicatesFiles += ", " + file.FileName;
                            duplicates = true;
                        }
                        else
                        {
                            otheDbError = true;
                        }
                    }
                }
                //add a list of duplicate files to the error message
                if (duplicates)
                {

                    ModelState.AddModelError("FileName", "All files uploaded except the files" + dublicatesFiles + "which already exist in the system." + "please delete them and try again if you wish to re-add them");
                    return View();
                }
                else if (otheDbError)
                {
                    ModelState.AddModelError("FileName", "Sorry an error has occurred saving to the database ,please try again ");
                    return View();
                }

            }

            return RedirectToAction("Index");
        }

        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();//获取文件后缀
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097152) && allowedFileTypes.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }

        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            img.Save(@"D:\image\" + Path.GetFileName(file.FileName));
            if (img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            img.Save(@"D:\image\" + Path.GetFileName(file.FileName));
        }
        #endregion

        #region upload img from db and display  //case：https://forums.asp.net/t/2149144.aspx
        public class Inbox
        {
            [Key]
            public int Id { get; set; }
            public IEnumerable<HttpPostedFileBase> Files { get; set; }
            public object UserId { get; internal set; }
        }

        public class AllFiles
        {
            public int Id { get; set; }
            public string ContentType { get; set; }
            public byte[] Imagebytes { get; set; }
            public string FileName { get; set; }

        }

        public ActionResult Create_img()
        {
            //List<Inbox> Inbox = new List<Inbox>();
            //Inbox.Add(new Inbox { Id=1, });
            //Inbox.Add(new Inbox { Id=0, });



            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create_img(Inbox model)
        {

            if (ModelState.IsValid)
            {

                foreach (var item in model.Files)
                {
                    saveFileDetails(item);

                }

                var max = new Inbox();

                //db.Inboxs.Add(model);
                //db.SaveChanges();
                string url = Url.Action("List");
                return Json(new { success = true, url = url });
            }
            return View(model);
        }


        // GET: AllFiles
        public void saveFileDetails(HttpPostedFileBase file)
        {


            AllFiles newfile = new AllFiles();
            newfile.ContentType = file.ContentType;
            newfile.Imagebytes = ConvertToBytes(file);

            var fileName = Path.GetFileName(file.FileName);
            newfile.FileName = "~/images/" + fileName;
            var path = Path.Combine(Server.MapPath("/images/"), fileName);

            file.SaveAs(path);


            //db.AllFiless.Add(newfile);//         img.LabelName = "~/images/" + file.FileName;
            //db.author2s.Add(newfile);
            //db.SaveChanges();

        }
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            byte[] imagebytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            imagebytes = reader.ReadBytes((int)file.ContentLength);
            return imagebytes;
        }

        #endregion
        #region Blob to Image  https://forums.asp.net/t/2148946.aspx
        public ActionResult UploadIm_Index()
        {

            return View();
        }

        public JsonResult UploadIm()
        {

            try
            {
                string Pic_Path = System.Web.HttpContext.Current.Server.MapPath("~/Images/t.jpg");

                HttpPostedFileBase file = Request.Files[0]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                                                            //System.IO.Stream fileContent = file.InputStream;
                file.SaveAs(Pic_Path); //File will be saved in application root

                return this.Json(1);
            }
            catch (Exception ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                throw;
            }
        }
        #endregion

        #region checkbox JQselector Bootstrap Accordion  //https://forums.asp.net/t/2149202.aspx
        public class ChannelModel
        {
            public int ID { get; set; }
            public string Channel { get; set; }
            public string Program { get; set; }
            public DateTime Date { get; set; }
            public string Time { get; set; }

        }
        public ActionResult channel_Index()
        {
            List<ChannelModel> model = new List<ChannelModel>();
            model.Add(new ChannelModel { ID = 1, Channel = "One", Program = "News", Date = DateTime.Now, Time = "18:00" });
            model.Add(new ChannelModel { ID = 2, Channel = "One", Program = "Sport", Date = DateTime.Now, Time = "20:00" });
            model.Add(new ChannelModel { ID = 3, Channel = "Two", Program = "Inception", Date = DateTime.Now, Time = "09:50" });
            model.Add(new ChannelModel { ID = 4, Channel = "Three", Program = "Seinfeldt", Date = DateTime.Now, Time = "11:00" });
            model.Add(new ChannelModel { ID = 5, Channel = "Four", Program = "Alf", Date = DateTime.Now, Time = "15:30" });
            model.Add(new ChannelModel { ID = 6, Channel = "Four", Program = "News ", Date = DateTime.Now, Time = "19:00" });

            return View(model);
        }
        #endregion

        #region Tree Node Recursive Except https://forums.asp.net/p/2149194/6238089.aspx?p=True&t=636779276787443946
        public class TreeViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }

            //represnts Parent ID and it's nullable  
            public int Pid { get; set; }
            public virtual TreeViewModel Parent { get; set; }
            public virtual ICollection<TreeViewModel> Childs { get; set; }
        }
        private static List<TreeViewModel> FillRecursive(List<TreeViewModel> flatObjects, int? parentId = null)
        {
            return flatObjects.Where(x => x.Pid.Equals(parentId)).Select(item => new TreeViewModel
            {
                Name = item.Name,
                ID = item.ID,
                Level = item.Level,
                Pid = item.Pid,
                Childs = FillRecursive(flatObjects, item.ID)
            }).ToList();
        }

        public ActionResult TreeViewDemo2()
        {
            #region tree model
            List<TreeViewModel> list = GetAllCategoriesForTree();
            //list.SelectMany(x => x);
            //return View(list);
            #endregion

            #region tree model
            List<TreeViewModel> model = new List<TreeViewModel>();
            model.Add(new TreeViewModel { ID = 1, Name = "6", Level = 1 });
            model.Add(new TreeViewModel { ID = 2, Name = "60", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 3, Name = "601", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 4, Name = "602", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 5, Name = "61", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 6, Name = "610", Level = 3, Pid = 5 });
            model.Add(new TreeViewModel { ID = 7, Name = "6100", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 8, Name = "6101", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 9, Name = "7", Level = 1 });


            var difflist = model.Select(x => x.ID).ToList().Except(model.Select(x => x.Pid).ToList()).ToList();

            List<TreeViewModel> list2 = ChildrenOf(model[1]);

            return View(list2);
            #endregion
        }
        #region tree model
        public List<TreeViewModel> GetAllCategoriesForTree()
        {
            List<TreeViewModel> model = new List<TreeViewModel>();
            model.Add(new TreeViewModel { ID = 1, Name = "6", Level = 1 });
            model.Add(new TreeViewModel { ID = 2, Name = "60", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 3, Name = "601", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 4, Name = "602", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 5, Name = "61", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 6, Name = "610", Level = 3, Pid = 5 });
            model.Add(new TreeViewModel { ID = 7, Name = "6100", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 8, Name = "6101", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 9, Name = "7", Level = 1 });

            List<TreeViewModel> headerTree = FillRecursive(model, null);




            return headerTree.ToList();
        }
        #endregion


        #region tree Children
        public List<TreeViewModel> ChildrenOf(TreeViewModel startingTree)
        {
            List<TreeViewModel> result = new List<TreeViewModel>();
            AddChildren(startingTree, result);
            return result;
        }

        private void AddChildren(TreeViewModel tree, List<TreeViewModel> list)
        {

            List<TreeViewModel> model = new List<TreeViewModel>();
            model.Add(new TreeViewModel { ID = 1, Name = "6", Level = 1 });
            model.Add(new TreeViewModel { ID = 2, Name = "60", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 3, Name = "601", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 4, Name = "602", Level = 3, Pid = 2 });
            model.Add(new TreeViewModel { ID = 5, Name = "61", Level = 2, Pid = 1 });
            model.Add(new TreeViewModel { ID = 6, Name = "610", Level = 3, Pid = 5 });
            model.Add(new TreeViewModel { ID = 7, Name = "6100", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 8, Name = "6101", Level = 4, Pid = 6 });
            model.Add(new TreeViewModel { ID = 9, Name = "7", Level = 1 });

            foreach (var myTree in model)
            {
                if (myTree.Pid == tree.ID)
                {
                    list.Add(myTree);
                    AddChildren(myTree, list);
                }
                continue;
                //else
                //{

                //    AddChildren(myTree, list);
                //}
            }

        }
        #endregion
        #endregion

        #region BeginRouteForm AjaxOptions OnSuccess
        public ActionResult BeginRouteForm_Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BeginRouteForm_Index(string aa)
        {

            //return Json("1111", JsonRequestBehavior.AllowGet);
            return View();
        }

        #endregion

        #region LINQ to XML //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-join-two-collections-linq-to-xml

        public void LINQtoXML() //https://forums.asp.net/p/2149320/6238428.aspx?p=True&t=636781894580854435
        {//https://www.c-sharpcorner.com/blogs/joins-using-linqtoxml1
            //https://forums.asp.net/t/2149484.aspx

            //https://stackoverflow.com/questions/39893076/how-to-read-data-with-pagination-from-large-xml-file-using-c-sharp//How to read data with pagination from large xml file using c# 流
            var path1 = Server.MapPath("~/CustomersOrders.xsd");

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", path1);

            var path2 = Server.MapPath("~/CustomersOrders.xml");


            Console.Write("Attempting to validate, ");
            XDocument custOrdDoc = XDocument.Load(path2);

            bool errors = false;
            custOrdDoc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            Console.WriteLine("custOrdDoc {0}", errors ? "did not validate" : "validated");

            if (!errors)
            {
                // Join customers and orders, and create a new XML document with  
                // a different shape.  

                // The new document contains orders only for customers with a  
                // CustomerID > 'K'  
                XElement custOrd = custOrdDoc.Element("Root");
                XElement newCustOrd = new XElement("Root",
                    from c in custOrd.Element("Customers").Elements("Customer")
                    join o in custOrd.Element("Orders").Elements("Order")
                               on (string)c.Attribute("CustomerID") equals
                                  (string)o.Element("CustomerID")
                    where ((string)c.Attribute("CustomerID")).CompareTo("K") > 0
                    select new XElement("Order",
                        new XElement("CustomerID", (string)c.Attribute("CustomerID")),
                        new XElement("CompanyName", (string)c.Element("CompanyName")),
                        new XElement("ContactName", (string)c.Element("ContactName")),
                        new XElement("EmployeeID", (string)o.Element("EmployeeID")),
                        new XElement("OrderDate", (DateTime)o.Element("OrderDate"))
                    )
                );
                Console.WriteLine(newCustOrd);
            }
        }

        #endregion
        #region checkbox list 见note  验证https://forums.asp.net/t/2150061.aspx
        public class IsVaild : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var model = (TestApplication1.Controllers.Home2Controller.response)validationContext.ObjectInstance;
                // DateTime EndDate = Convert.ToDateTime(model.Compare2);
                // DateTime StartDate = Convert.ToDateTime(value);

                if (model.resval == false)
                {
                    return new ValidationResult
                    ("it must be selected;");
                }
                return ValidationResult.Success;
            }
        }

        public class response

        {
            public int resid { get; set; }
            public string resname { get; set; }
            [IsVaild]
            public bool resval { get; set; }

        }

        private ObjectSet<response> _Employees;

        public class viewmodel
        {
            public List<response> Reslist { get; set; }
            //public string rbGrp { get; set; }
        }

        public ActionResult checkbox_Index()
        {

            viewmodel vm = new viewmodel();
            vm.Reslist = new List<response>()
            {
                new response() { resid=1 , resname="1001",resval=false},
                new response() { resid=2 , resname="1002",resval=true },
                new response() { resid=3 , resname="1003",resval=false },
                new response() { resid=4 , resname="1004",resval=false},
                new response() { resid=5 ,  resname="1005",resval=false},
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult checkbox_Index(viewmodel vm)
        {
            if (ModelState.IsValid)
            {

                return View(vm);
            }
            else {
                var msg = string.Empty;
                foreach (var value in ModelState.Values)
                {
                    if (value.Errors.Count > 0)
                    {
                        foreach (var error in value.Errors)
                        {
                            msg = msg + error.ErrorMessage;
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, msg);//@Html.ValidationSummary//https://forums.asp.net/t/2150061.aspx
                return View(vm);
            }
        }
        #endregion

        #region
        public class MatriceViewModel
        {
            public string DateDebForm { get; set; }
            public long ID_PNT { get; set; }
            public string NomPn { get; set; }
            public string TypeForm { get; set; }

            public string DateFinForm { get; set; }
        }
        public ActionResult Matrice()
        {
            //List<MatriceViewModel> mylist = new List<MatriceViewModel>();

            //ViewBag.forma = (from s in db.CountrySizes.ToList() select s.country).Distinct().ToList();
            //  ViewBag.forma = (from s in db.GetListAllStatDT().ToList() select s.TypeQuestionExam).Distinct();

            //mylist = db.GetListAllStatDT().Select(c => new MatriceViewModel
            //{
            //    DateDebForm = c.DateDebutExam,
            //    ID_PNT = c.ID_PNT ?? 0,
            //    NomPn = c.Nom,
            //    TypeForm = c.TypeQuestionExam,
            //    DateFinForm = c.DateExpirer
            //}).ToList();

            List<MatriceViewModel> mylist = new List<MatriceViewModel>();
            mylist.Add(new MatriceViewModel { ID_PNT = 1, DateDebForm = "1", NomPn = "A", DateFinForm = "18:00" });
            mylist.Add(new MatriceViewModel { ID_PNT = 2, NomPn = "B", DateFinForm = "20:00" });
            mylist.Add(new MatriceViewModel { ID_PNT = 3, DateDebForm = "3", NomPn = "B", DateFinForm = "09:50" });
            mylist.Add(new MatriceViewModel { ID_PNT = 4, DateDebForm = "4", NomPn = "C", DateFinForm = "11:00" });
            ViewBag.forma = mylist.Select(_ => _.NomPn).ToList().Distinct();

            List<System.Linq.IGrouping<string, MatriceViewModel>> model = (from a in mylist group a by a.NomPn into g select g).ToList();

            return View(model);
        }
        #endregion

        #region
        public static class Globals
        {
            public static double Variable1 { get; set; }
            public static double Variable2 { get; set; }
            public static double Variable3 { get; set; }
        }

        [OutputCache(Duration = 10)]
        public ActionResult OutputCache1()
        {

            try
            {
                Random rnd = new Random();
                Globals.Variable1 = rnd.Next(1, 100); ;
                Globals.Variable2 = rnd.Next(1, 200); ;
                Globals.Variable3 = rnd.Next(1, 300); ;
            }
            catch (Exception ex) { string errormsg = ex.ToString(); }

            //var UserList = "11" + System.DateTime.Now; ;
            //TempData["User"] = UserList;
            //TempData.Keep("User");

            //ViewBag.CurrentTime = System.DateTime.Now;
            return View();
            #region redirect to another controller in void action in mvc //https://forums.asp.net/p/2149674/6239881.aspx?p=True&t=636789578413290299

            // Response.Redirect(Url.Action("Index", "Home", new { id = 33}));
            #endregion

        }

        public ActionResult OutputCache2(int? id)
        {
            var aa = TempData["User"];
            ViewBag.CurrentTime = System.DateTime.Now;
            return View();
        }
        #endregion
        #region create pdf from predefined word template //https://csharp.hotexamples.com/examples/iTextSharp.text/Document/SetPageSize/php-document-setpagesize-method-examples.html
        public ActionResult WordToPdf()
        {
            string Body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/images/yuki_link.docx")))
            {
                Body = reader.ReadToEnd();
            }
            //Body = Body.Replace("[PackageCost]", model.TotalAmmount);
            //Body = Body.Replace("[Name]", model.FName);
            //Body = Body.Replace("[Address]", model.Address);
            //Body = Body.Replace("[Phoneno]", model.PhoneNumber);
            //Body = Body.Replace("[Email]", model.Email);
            //Body = Body.Replace("[HoursOfWork]", " ");
            //Body = Body.Replace("[CategoryOfWork]", model.categoryname);
            //Body = Body.Replace("[ScopeOfWork]", model.expertisename);
            //Body = Body.Replace("[IssueDate]", model.Email1);
            ////
            //Body = Body.Replace("[Time]", Time);

            //

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(Body);
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 10f);//itextsharp
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(new iTextSharp.text.Paragraph("Hello World"));
                pdfDoc.NewPage();
                // XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);//itextsharp.xmlworker
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Certificate.pdf");
            }
        }
        //return View();

        #endregion
        #region https://forums.asp.net/t/2150050.aspx

        public class DepotUserLink
        {
            public List<int> DepotsID { get; set; }
            [NotMapped]
            public bool checkboxDepotLink { get; set; }
            public bool checkboxDefaultDepot { get; set; }

        }

        public ActionResult checkbox_string()
        {
            return View();
        }

        [HttpPost]
        public ActionResult checkbox_string(string[] DepotLink)
        {
            return View();
        }

        public async Task Like2(string postId)
        {
            //var post = await postRepository.GetAsync(postId);

            ////if(post == null)
            ////    return HttpNotFound();

            //var user = await GetLoggedInUser();

            //var model = new Voting();

            //model.UserId = user.Id;
            //model.PostId = post.Id;

            await LikedAsync(/*model*/);

            //return RedirectToAction("Post","HomeBlog",new { postId=postId});
        }



        public async Task LikedAsync(/*Voting model*/)
        {
            //var vote = await UserHasVoted(model.PostId, model.UserId);

            //if (vote != null)
            //{
            //    vote.LikeCount = !vote.LikeCount;
            //    model.PostedOn = DateTime.Now;
            //}
            //if (vote == null)
            //{
            //    model.LikeCount = true;
            //    model.PostedOn = DateTime.Now;
            //    this.db.Voting.Add(model);
            //}

            await this.db.SaveChangesAsync();

        }
        #endregion
        #region
        public class StdAcademicQualifModel
        {
            public string ProgramName { get; set; }
            public int ID { get; set; }
            public int Std_ref_id { get; set; }
            public int Program_ref_id { get; set; }
            public string Subject { get; set; }
            public string YOP { get; set; }
            public Nullable<decimal> Mark { get; set; }
        }
        public ActionResult ConfirmEditStdQualif()
        {
            List<StdAcademicQualifModel> model = new List<StdAcademicQualifModel>();
            model.Add(new StdAcademicQualifModel() { ID = 1, ProgramName = "AA", Std_ref_id = 1, Subject = "AA", YOP = "AA" });
            model.Add(new StdAcademicQualifModel() { ID = 2, ProgramName = "BB", Std_ref_id = 1, Subject = "BB", YOP = "BB" });
            model.Add(new StdAcademicQualifModel() { ID = 3, ProgramName = "CC", Std_ref_id = 1, Subject = "CC", YOP = "CC" });

            return View(model);
        }
        [HttpPost]
        public ActionResult ConfirmEditStdQualif(StdAcademicQualifModel model)
        {
            //Service_Std service_ = new Service_Std();
            //TempData["Page"] = 3;
            //TempData["StdId"] = model.Std_ref_id;
            //if (ModelState.IsValid && model.Std_ref_id > 0)
            //{
            //    service_.UpdateStdAcademicQualif(model);
            //}
            return RedirectToAction("UploadFiles", "Home2");
        }
        #endregion
        #region upload and save file https://www.c-sharpcorner.com/UploadFile/manas1/upload-files-through-jquery-ajax-in-Asp-Net-mvc/
        [HttpGet]
        public ActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(string username)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/images/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        #endregion


        #region Mysql
        public class Studentmodel
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }    
        public void MysqlIndex()
        {
            #region sql
            DataSet ds = new DataSet();
            //string connectionString =
            //@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
            string connectionString = ConfigurationManager.ConnectionStrings["sql_textConnectionString"].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["mysql_textConnectionString"].ConnectionString;
            SqlDependency.Start(connectionString);//传入连接字符串,启动基于数据库的监听
            Update();

            //SqlConnection con = new SqlConnection(connectionString);
            //con.Open();
            #region sql select
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "select * from Student";
            //// cmd.Connection = con;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //var stulist = new List<Studentmodel>();

            //// var re = from a in stulist select a;

            //foreach (System.Data.DataRow row in ds.Tables[0].Rows)
            //{
            //    stulist.Add(new Studentmodel
            //    {
            //        Id = Convert.ToInt32(row["Id"]),
            //        Name = row["Name"].ToString()
            //    });
            //}

            //ViewData["Message"] = stulist;
            #endregion


            //{
            //    con.Open();

            //    using (var cnd2 = new SqlCommand(@"select Id,Name from [dbo].[Student]", con))
            //    {
            //        cnd2.ExecuteNonQuery();
            //    }
            //    cmd.Notification = null;
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    SqlDependency dependency = new SqlDependency(cmd);
            //    //dependency.AddCommandDependency(cmd);
            //    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

            //}

            #endregion
            #region mysql  
            #region Read() SELECT
            //List<Studentmodel> customers = new List<Studentmodel>();
            //string constr = ConfigurationManager.ConnectionStrings["mysql_textConnectionString"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    string query = "SELECT * FROM mysqlstudent";
            //    using (MySqlCommand cmd = new MySqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        using (MySqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                customers.Add(new Studentmodel
            //                {
            //                    Id = Convert.ToInt32(sdr["Id"]),
            //                    Name = sdr["Name"].ToString()
            //                });
            //            }
            //        }
            //        con.Close();
            //    }
            //}
            //ViewData["Message"] = customers;

            #endregion

            #region DataSet() select and insert
            //DataSet ds = new DataSet();
            //string connectionString = ConfigurationManager.ConnectionStrings["mysql_textConnectionString"].ConnectionString;


            //MySqlConnection con = new MySqlConnection(connectionString);
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "select * from mysqlstudent";
            //// cmd.Connection = con;
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(ds);

            ////List<Studentmodel> treelist = new List<Studentmodel>();
            ////for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            ////{
            ////    Studentmodel tre = new Studentmodel();
            ////    tre.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
            ////    tre.Name = ds.Tables[0].Rows[i]["Name"].ToString();

            ////    treelist.Add(tre);
            ////}
            ////ViewData["Message"] = treelist;

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{

            //    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            //    {
            //        string max1 = "Select Name From mysqlstudent";
            //        MySqlDataAdapter da1 = new MySqlDataAdapter(max1, con);
            //        DataTable dt1 = new DataTable();
            //        da1.Fill(dt1);
            //        var id1 = dt1.Rows[0]["Name"].ToString();
            //        if (id1 != "")
            //        {
            //            //int ids = Convert.ToInt32(id1) + 1;


            //            string query1 = "Insert into mysqlstudent(Name) Values ('" + ds.Tables[0].Rows[i][j] + "')";

            //            //con.Open();
            //            MySqlCommand cmd2 = new MySqlCommand(query1, con);
            //            cmd2.ExecuteNonQuery();

            //        }
            //        else
            //        {

            //            string query1 = "Insert into mysqlstudent('Name') Values ('" + ds.Tables[0].Rows[i][j] + "')";

            //            con.Open();
            //            MySqlCommand cmd2 = new MySqlCommand(query1, con);
            //            cmd2.ExecuteNonQuery();
            //            // con.Close();

            //        }

            //    }

            //}
            //con.Close();
            #endregion
            #endregion
        }

        private static void Update()
        {
            using (
                   SqlConnection con =
                       new SqlConnection(ConfigurationManager.ConnectionStrings["sql_textConnectionString"].ConnectionString))
            {

                string sql = "select Id,Name from [dbo].[Student]";

                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    command.CommandType = CommandType.Text;
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    //必须要执行一下command
                    //command.ExecuteNonQuery();        
                   var re =  command.ExecuteReader();
                    Debug.WriteLine(dependency.HasChanges);
                }
            }
        }



        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //Debug.WriteLine("onchange方法中：" + dependency.HasChanges);
            Debug.WriteLine("数据库数据发生变化" + DateTime.Now);
            //这里要再次调用
            Update();
        }
        #endregion
        #region DataTable 填充 DataSet 动态插入//https://forums.asp.net/p/2150364/6242229.aspx?p=True&t=636807793294045056
        public void insert_dynamic()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Country",typeof(string)) });
            dt.Rows.Add(101, "AA", "US");
            dt.Rows.Add(102, "BB", "UA");
            dt.Rows.Add(103, "CC", "US");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            //to store the columns.
            List<string> strlist = new List<string>();

            //loop through the columns
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                strlist.Add(ds.Tables[0].Columns[j].ToString());
            }
            string template = string.Join(",", strlist);//list转 string （逗号隔开）

            //used to store the insert command
            List<string> ouput = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //used to store the values.
                List<string> valuelist = new List<string>();
                //get each cell value.
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    valuelist.Add("'" + ds.Tables[0].Rows[i][j].ToString() + "'");// 双引号 单引号 '101' 'AA'
                }

                ouput.Add(string.Format("Insert into tbl_sample({0}) values({1})", template, string.Join(",", valuelist)));
                //using these command to insert data into database.
            }
        }

        #endregion

        #region 动态添加 删除 List model bind [form].serialize() :针对 input等填入式tag, 对tr无效, 获取表单中的 name值 //submit form with model bind(也是):针对 input等填入式tag, 对tr无效
        public class CreateRMAVM
        {
            public string Varenummer { get; set; }
            public string Serienummer { get; set; }
        }

        public ActionResult ProcessCreateRMA()
        {
            List<CreateRMAVM> vm = new List<CreateRMAVM>();
            vm.Add(new CreateRMAVM { Varenummer = "11", Serienummer = "11" });
            vm.Add(new CreateRMAVM { Varenummer = "22", Serienummer = "22" });

            return View(vm);
        }

        [HttpPost]
        public JsonResult ProcessCreateRMA(List<CreateRMAVM> vm) //如果没值，可能换单模型（非List<model>）试试,或者把CreateRMAVM[0].Varenummer 换model[0].Varenummer
        {
            //List<CreateRMAVM> vm = new List<CreateRMAVM>();
            //RMA_History model = new RMA_History();
            //foreach (var item in vm)
            //{
            //    vm.Varenummer = item.Varenummer;
            //    model.Serienummer = item.Serienummer;
            //    db.RMA_History.Add(model);
            //    db.SaveChanges();
            //}

            return Json(111, JsonRequestBehavior.AllowGet);
        }


        #endregion
        #region Rotativa： html to pdf 分页
        public ActionResult Rotativa_Index()//html to pdf 分页
        {
            return View();
        }

        public ActionResult ExportPDF()//https://forums.asp.net/t/2150497.aspx //https://www.codeproject.com/Tips/818197/Generate-PDF-in-ASP-NET-MVC-Using-Rotativa
        {
            return new ActionAsPdf("Rotativa_Index")
            {
                FileName = Server.MapPath("~/Content/Relato.pdf"),
                //PageOrientation = Rotativa.Options.Orientation.Landscape,
                //PageSize = Rotativa.Options.Size.A4
            };
        }
        #endregion

        #region linqToCsv 将数据导出文件
        class Product
        {
            [CsvColumn(Name = "Product Name", FieldIndex = 1)]
            public string Name { get; set; }
            [CsvColumn(FieldIndex = 2, OutputFormat = "dd MMM HH:mm:ss")]
            public DateTime LaunchDate { get; set; }
            [CsvColumn(FieldIndex = 3, CanBeNull = false, OutputFormat = "C")]
            public decimal Price { get; set; }
            [CsvColumn(FieldIndex = 4)]
            public string Country { get; set; }
            [CsvColumn(FieldIndex = 5)]
            public string Description { get; set; }
        }
        public void linqToCsv()//library https://www.codeproject.com/Articles/25133/LINQ-to-CSV-library
        {
            //github https://github.com/mperdeck/LINQtoCSV
            //case https://forums.asp.net/t/2148655.aspx
            List<Product> products2 = new List<Product>()
            {
                new Product(){ Name="product A", Country="US"},
                new Product(){ Name="product A", Country="US"},
                new Product(){ Name="product A", Country="US"},
            };

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = '\t', // tab delimited
                FirstLineHasColumnNames = true, // no column names in first record
                FileCultureName = "nl-NL" // use formats used in The Netherlands
            };
            var path = Server.MapPath(@"~/images/products2.csv");//您需要使用HttpServerUtility.MapPath它将~/路径的一部分转换到它在硬盘驱动器上弹回的实际位置。

            CsvContext cc = new CsvContext();
            cc.Write(
                products2,
                      path,
                  outputFileDescription);


        }
        #endregion
        #region
        public class afishstudio
       {
            //public int id { get; set; }
            //public string name { get; set; }
            //public string family { get; set; }

            public string modiran_semat { get; set; }


        }
        //public ActionResult PassValue_Index()
        //{
        //    // resualt="id"+id,"name:"+name,"family:"+family,"date:"+date,"time:"+time;
        //    afishstudio model = new afishstudio();
        //    //model.id = 2;
        //    //model.name = "Ben";
        //    //model.family = "Ben's family";

        //    return View(model);

        //}
        public ActionResult PassValue_Indexxx()
            {

            afishstudio model = new afishstudio();

            return View(model);
        }

        [HttpPost]
        public ActionResult PassValue_Indexxx(string modiran_semat, afishstudio modiran)
        {
            TryUpdateModel(modiran, modiran_semat);


            return RedirectToAction("PassValue_Index","Home2");
        }

        //[HttpPost]
        public ActionResult PassValue_Index(/*FormCollection collection,*/string modiran_semat)
        {
            // resualt="id"+id,"name:"+name,"family:"+family,"date:"+date,"time:"+time;
            var model = new afishstudio();
            //TryUpdateModel(model, collection);
                

            TempData["id"] = model.modiran_semat;

            return RedirectToAction("PassValue_Index2", "Home2");
        }

        public ActionResult PassValue_Index2()
        {
            // resualt="id"+id,"name:"+name,"family:"+family,"date:"+date,"time:"+time;
            ViewBag.id = TempData["id"];

            return View();

        }
        #endregion
        #region Aspose.Words 查找指定文件夹中所有PDF，并复制到一个新的doc中
        public void GetFile()//https://forums.asp.net/t/2150255.aspx 
        {
            var path2 = Server.MapPath(@"~/images/");
            string[] filePathes = Directory.GetFiles(path2, "*.pdf");//get all the .pdf file in the directory
            string str = "";
            foreach (string path in filePathes)//get all the content
            {
                str += ReadPdfContent(path);
            }
            //string target = "";
            //MatchCollection col = Regex.Matches(str, @"\d+"); //use regular expresssion to get all the numbers
            //foreach (Match item in col)
            //{
            //    target += item.Value;  //connect all the numbers
            //}
            Aspose.Words.Document doc = new Aspose.Words.Document();  //write the cotent to a doc
            DocumentBuilder builder = new DocumentBuilder(doc); //install Aspose.Words in NuGet
            builder.Write(str);
            doc.Save(@"C:\Users\yukit\Desktop\test.doc");
            //doc.Save(path2);

        }

        public static string ReadPdfContent(string filepath)
        {
            try
            {
                string pdffilename = filepath;
                PdfReader pdfReader = new PdfReader(pdffilename);
                int numberOfPages = pdfReader.NumberOfPages;
                StringBuilder text = new StringBuilder();
                for (int i = 1; i <= numberOfPages; ++i)
                {
                    text.Append(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(pdfReader, i));
                }
                pdfReader.Close();
                return text.ToString();
            }
            catch (Exception ex)
            {
                return "cause：" + ex.ToString();
            }
        }


        #endregion

        #region Export table to Excel file using Angularjs in asp.net MVC
        public partial class ExportExcel_Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Nullable<int> Phone { get; set; }
            public Nullable<int> Salary { get; set; }
            public string Department { get; set; }
            public string ImagePath { get; set; }
            public string EmailId { get; set; }
        }

        public ActionResult ExportExcel()//https://forums.asp.net/p/2150721/6243437.aspx?p=True&t=636812897802421564
        {
            return View();
        }

        public JsonResult GetEmployee()
        {
            //var emp = db.Employees.ToList();
            List<ExportExcel_Employee> model = new List<ExportExcel_Employee>();
            model.Add(new ExportExcel_Employee { Id=1,Name="aa",Phone=123123,Salary=100,Department="de1"});
            model.Add(new ExportExcel_Employee { Id = 1, Name = "bb", Phone = 123124, Salary = 200, Department = "de2" });
            model.Add(new ExportExcel_Employee { Id = 1, Name = "cc", Phone = 123125, Salary = 300, Department = "de3" });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  Include加载不了viewmodel的数据，只能建库测试数据 https://forums.asp.net/t/2150733.aspx
        //public class Type_Service
        //{
        //    public Type_Service()
        //    {
        //        Pations = new List<Pation>();
        //    }

        //    [Key]
        //    public int Type_ServiceId { get; set; }
        //    public string NameService { get; set; }
        //    public virtual ICollection<Pation> Pations { get; set; }

        //}

        //public class Pation
        //{
        //    [Key]
        //    public int Id { get; set; }
        //    public string PationName { get; set; }
        //    public int Age { get; set; }
        //    public int Sex { get; set; }
        //   // public DateTime DateWared { get; set; } = DateTime.UtcNow.AddHours(3);
        //    public int Type_ServiceId { get; set; }
        //    [ForeignKey("Type_ServiceId")]
        //    public virtual Type_Service Type_Services { get; set; }
        //    //public ApplicationUser User { get; set; }

        //}

        public class UserRange
        {
            public string AgeRange { get; set; }
            public int Count { get; set; }
            public string Gender { get; internal set; }
            public string grilsTotal { get; internal set; }
            public string boysTotal { get; internal set; }
            public string Type_S { get; internal set; }
            
        }


        public ActionResult Mster()
        {
            //List<Pation> pa = new List<Pation>();
            //pa.Add(new Pation { Id=1,PationName="pan",Age=1,Sex= 0 });
            //pa.Add(new Pation { Id = 1, PationName = "pan", Age = 3,  Sex = 1,Type_ServiceId=1});
            //pa.Add(new Pation { Id = 2, PationName = "pan", Age = 10, Sex = 0,Type_ServiceId=2});
            //pa.Add(new Pation { Id = 3, PationName = "pan", Age = 16, Sex = 0,Type_ServiceId=2});
            //pa.Add(new Pation { Id = 4, PationName = "pan", Age = 26, Sex = 1,Type_ServiceId=2});

            //List<Type_Service> ts = new List<Type_Service>();
            //ts.Add(new Type_Service { Type_ServiceId = 1, NameService = "NameService1"});
            //ts.Add(new Type_Service { Type_ServiceId = 2, NameService = "NameService2"});

            //var list = pa.AsQueryable().Include(b=>b.Type_Services).ToList();
            var query = (from t in db.Pations.Include(b=>b.Type_Services).ToList()
                         let Agerange =
                         (
                         t.Age >= 0 && t.Age < 1 ? "Age Under 1 year" :
                         t.Age >= 1 && t.Age < 5 ? "Age from 1 to 4" :
                         t.Age >= 5 && t.Age < 15 ? "Age from 5 to 14" :
                         t.Age >= 15 && t.Age < 25 ? "Age from 15 to 24" :
                         t.Age >= 25 && t.Age < 45 ? "Age from 25 to 46" :
                         "age over 47+"
                         )
                         let Sex = (t.Sex == 0 ? "boys" : "girls")
                         let Type_S=t.Type_Services.NameService
                         group t by new { Agerange, Sex, Type_S } into g
                         select new UserRange { AgeRange = g.Key.Agerange, Gender = g.Key.Sex, Type_S = g.Key.Type_S, Count = g.Count() }).ToList();
            //var boysTotal = new UserRange() { Gender = "boys", AgeRange = "boys sum", Count = query.Where(c => c.Gender == "boys").Sum(c => c.Count) };
            //var grilsTotal = new UserRange() { Gender = "girls", AgeRange = "girls sum", Count = query.Where(c => c.Gender == "girls").Sum(c => c.Count) };
            //query.Add(boysTotal);
            //query.Add(grilsTotal);
            var boysTotal = query.GroupBy(_ => _.Type_S, (key, group) => new { TypeServiceName = key, Count = group.Where(_ => _.Gender == "boys").Sum(_ => _.Count) }).ToList();
            var grilsTotal = query.GroupBy(_ => _.Type_S, (key, group) => new { TypeServiceName = key, Count = group.Where(_ => _.Gender == "girls").Sum(_ => _.Count) }).ToList();
            //group 嵌套 group
            var list = query.GroupBy(s => s.Type_S, (key, group) => new { TypeSviceName = key, Group = group.ToList().GroupBy(b => b.AgeRange).ToList() });
            ViewBag.UserData = list;
            return View();
        }
        #endregion
    }

}


