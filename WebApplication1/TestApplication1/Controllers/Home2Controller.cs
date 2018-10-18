using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var flag = 1;
            var MyKey = "TN";
            if (ConfigurationManager.AppSettings.AllKeys.Contains("PageSize"))
            {
                flag = 1;
            }          
            if (ConfigurationManager.AppSettings.AllKeys.Any(key => key == MyKey))
            {
                // Key exists
            }

            var MyReader = new System.Configuration.AppSettingsReader();
            string keyvalue = MyReader.GetValue("PageSize", typeof(string)).ToString();

            string[] repositoryUrls = ConfigurationManager.AppSettings.AllKeys
                             .Where(key => key.StartsWith("TS"))
                             .Select(key => ConfigurationManager.AppSettings[key])
                             .ToArray();

            foreach (var item in ConfigurationManager.AppSettings.AllKeys.ToList())//https://forums.asp.net/p/2147937/6233866.aspx?p=True&t=636751562067955347
            {
                if (ConfigurationManager.AppSettings[item] == "TS")
                {

                }
            }
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
            StudentAccount dbEntry = db.StudentAccounts.Where(x=>x.Username== uname &&x.Password== passwd).SingleOrDefault();
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
            Model model2 = JsonConvert.DeserializeObject<Model>(System.IO.File.ReadAllText(@"D:\model.json"));

            // deserialize JSON directly from a file
            //using (StreamReader file = System.IO.File.OpenText(@"D:\model.json"))
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
            return Json(new { flag = 1,list }, JsonRequestBehavior.AllowGet);


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

            return PartialView("DropAppliPopup");
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
            objcountrymodel.SelectedCountryId ="2";
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
    }
}
