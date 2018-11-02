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
            var path = System.IO.Directory.CreateDirectory(@"~\images\odoiproject\");
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

        #region
        public class Assignment
        {
            public int AssignmentID { get; set; }
            public string AssignmentDesignatorString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? AssignmentDate { get; set; }
            public string AssignmentDateString { get; set; }
            public bool? AssignmentShift { get; set; }
            public string AssignmentShiftString { get; set; }
            public bool? AssignmentType { get; set; }
            public string AssignmentTypeString { get; set; }
            public int? CalendarID { get; set; }
            public int? CharterID { get; set; }
            public int? ContactID { get; set; }
            public int? HistoryContactID { get; set; }
            public int? HistoryResourceID { get; set; }
            public int? ResourceID { get; set; }
            public int? ResourceDirectionID { get; set; }
            public int? ResourceDocumentID { get; set; }
            public int? ResourceOfficeID { get; set; }
            public int? RouteID { get; set; }
            public virtual Charter Charter { get; set; }
            public virtual Contact Contact { get; set; }
            public virtual Resource Resource { get; set; }
            public virtual Route Route { get; set; }
            public string AssignmentContact { get; set; } // <-
            public string AssignmentResource { get; set; } // <-
            public string AssignmentRoute { get; set; } // <-
            public int? AssignmentTheta { get; set; }
            public string AssignmentCategory1 { get; set; }
            public string AssignmentSubCategory1 { get; set; }
            public string AssignmentCategory2 { get; set; }
            public string AssignmentSubCategory2 { get; set; }
            public string AssignmentSubject { get; set; }
            public string AssignmentTitle { get; set; }
            public string AssignmentText { get; set; }
            public string AssignmentNote { get; set; }
            public string AssignmentAccess1 { get; set; }
            public string AssignmentAccess2 { get; set; }
            public string AssignmentTag { get; set; }
            public bool? AssignmentInactive { get; set; }
            public string AssignmentInactiveString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? AssignmentDateCreate { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? AssignmentDateUpdate { get; set; }
        }
        public class Contact
        {
            public int ContactID { get; set; }
            public string ContactDesignator1String { get; set; } // <-
            public string ContactDesignator2String { get; set; }
            public int? ContactDesignator1 { get; set; }
            public int? ContactDesignator2 { get; set; }
            public string ContactLocationName { get; set; }
            public string ContactAddressStreet1 { get; set; }
            public string ContactAddressStreet2 { get; set; }
            public string ContactAddressApartment { get; set; }
            public string ContactAddressCityTown { get; set; }
            public string ContactAddressZipCode { get; set; }
            public string ContactAddressMapAccess1 { get; set; }
            public string ContactAddressMapAccess2 { get; set; }
            public string ContactAddressMapAreaAccess1 { get; set; }
            public string ContactAddressMapAreaAccess2 { get; set; }
            public string ContactBOCES { get; set; }
            public string ContactPhone1 { get; set; }
            public string ContactPhone1Label { get; set; }
            public string ContactPhone2 { get; set; }
            public string ContactPhone2Label { get; set; }
            public string ContactPhone3 { get; set; }
            public string ContactPhone3Label { get; set; }
            public string ContactPhone4 { get; set; }
            public string ContactPhone4Label { get; set; }
            public string ContactNameFirst { get; set; }
            public string ContactNameLast { get; set; }
            public string ContactContact1 { get; set; }
            public string ContactContact1Carrier { get; set; }
            public bool? ContactResourceType { get; set; }
            public string ContactResourceTypeString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Seniority")]
            public DateTime? ContactSeniority { get; set; }
            public string ContactSeniorityString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
            public DateTime? ContactHireDate { get; set; }
            public string ContactHireDateString { get; set; }
            [DataType(DataType.Time)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
            public DateTime? ContactReportAM { get; set; }
            public string ContactReportAMString { get; set; }
            [DataType(DataType.Time)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
            public DateTime? ContactReturnAM { get; set; }
            public string ContactReturnAMString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
            public DateTime? ContactLeaveYardAM { get; set; }
            public string ContactLeaveYardAMString { get; set; }
            [DataType(DataType.Time)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
            public DateTime? ContactReportPM { get; set; }
            public string ContactReportPMString { get; set; }
            [DataType(DataType.Time)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
            public DateTime? ContactReturnPM { get; set; }
            public string ContactReturnPMString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
            public DateTime? ContactLeaveYardPM { get; set; }
            public string ContactLeaveYardPMString { get; set; }
            public int? ContactHoursGuaranteed { get; set; }
            public int? ContactHoursGuaranteedString { get; set; }
            public string ContactCategory1 { get; set; }
            public string ContactSubCategory1 { get; set; }
            public string ContactCategory2 { get; set; }
            public string ContactSubCategory2 { get; set; }
            public string ContactSubject { get; set; }
            public string ContactTitle { get; set; }
            public string ContactText { get; set; }
            public string ContactNote { get; set; }
            public string ContactAccess1 { get; set; }
            public string ContactAccess2 { get; set; }
            public string ContactTag { get; set; }
            public bool? ContactInactive { get; set; }
            public string ContactInactiveString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? ContactDateCreate { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? ContactDateUpdate { get; set; }
            public virtual ICollection<Assignment> Assignments { get; set; }
        }
        public class Resource
        {
            public int ResourceID { get; set; }
            public string ResourceDesignatorString { get; set; } // <-
            public int? ResourceDesignator { get; set; }
            public string ResourceTypeString { get; set; }
            public string ResourceLocation { get; set; }
            public string ResourceTransport { get; set; }
            public string ResourceBookString { get; set; }
            public string ResourceNoteRepair { get; set; }
            public string ResourceNoteDrivers { get; set; }
            public string ResourceVideoMN { get; set; }
            public string ResourceVideoSN { get; set; }
            public string ResourceRadioMN { get; set; }
            public string ResourceRadioSN { get; set; }
            public string ResourceMake { get; set; }
            public string ResourceModel { get; set; }
            public string ResourceYearString { get; set; }
            public string ResourceVIN { get; set; }
            public string ResourceLicensePlate { get; set; }
            public string ResourceCapacity1String { get; set; }
            public string ResourceCapacity2String { get; set; }
            public string ResourceDVRString { get; set; }
            public string ResourceGPSString { get; set; }
            public string ResourceRadioString { get; set; }
            // Filters
            public bool? ResourceBoard { get; set; }
            public bool? ResourceBook { get; set; }
            public bool? ResourceReturn { get; set; }
            public bool? ResourceType { get; set; }
            public bool? ResourceRadio { get; set; }
            public bool? ResourceGPS { get; set; }
            public bool? ResourceVideo { get; set; }
            public bool? ResourceFlag { get; set; }
            public bool? ResourceDVR { get; set; }
            public bool? ResourceDVRPending { get; set; }
            public bool? ResourceOOS { get; set; }
            public bool? ResourceExclude { get; set; }
            public bool? ResourceDOT { get; set; }
            public bool? ResourceVideoHD { get; set; }
            public bool? ResourceKeySpare { get; set; }
            public bool? ResourceKeyFuel { get; set; }
            public int? ResourceVideoCameras { get; set; }
            public int? ResourceWheelChair { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "DOT Date")]
            public DateTime? ResourceDOTDate { get; set; }
            public string ResourceDOTDateString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? ResourceOOSDate { get; set; }
            public string ResourceOOSDateString { get; set; }
            public string ResourceCategory1 { get; set; }
            public string ResourceSubCategory1 { get; set; }
            public string ResourceCategory2 { get; set; }
            public string ResourceSubCategory2 { get; set; }
            public string ResourceSubject { get; set; }
            public string ResourceTitle { get; set; }
            public string ResourceText { get; set; }
            public string ResourceNote { get; set; }
            public string ResourceAccess1 { get; set; }
            public string ResourceAccess2 { get; set; }
            public string ResourceTag { get; set; }
            public bool? ResourceInactive { get; set; }
            public string ResourceInactiveString { get; set; }
            [DataType(DataType.Date)]
            [Column(TypeName = "DateTime2")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? ResourceDateCreate { get; set; }
        }
        public class Route
        {
            public int RouteID { get; set; }
            public string RouteDesignatorString { get; set; } // <-
            public string RouteDesignatorAltString { get; set; }
            public bool? RouteResourceType { get; set; }
            public string RouteResourceTypeString { get; set; }
            public string RouteElementarySchool { get; set; }
            public string RouteSchool { get; set; }
            public string RouteAMArriveString { get; set; }
            public string RoutePMArriveString { get; set; }
            public string RouteReportAMString { get; set; }
            public string RouteReportPMString { get; set; }
            public string RouteArriveAMString { get; set; }
            public string RouteArrivePMString { get; set; }
            public string RouteCodesHardware { get; set; }
            public string RouteCodesSupervision { get; set; }
            public string RouteRunAM1School { get; set; }
            public string RouteRunAM1Designator { get; set; }
            public string RouteRunAM1CountString { get; set; }
            public string RouteRunAM1ArriveString { get; set; }
            public string RouteRunAM1CodesHardware { get; set; }
            public string RouteRunAM1CodesSupervision { get; set; }
            public string RouteRunAM2School { get; set; }
            public string RouteRunAM2Designator { get; set; }
            public string RouteRunAM2CountString { get; set; }
            public string RouteRunAM2ArriveString { get; set; }
            public string RouteRunAM2CodesHardware { get; set; }
            public string RouteRunAM2CodesSupervision { get; set; }
            public string RouteRunAM3School { get; set; }
            public string RouteRunAM3Designator { get; set; }
            public string RouteRunAM3CountString { get; set; }
            public string RouteRunAM3ArriveString { get; set; }
            public string RouteRunAM3CodesHardware { get; set; }
            public string RouteRunAM3CodesSupervision { get; set; }
            public string RouteRunPM1School { get; set; }
            public string RouteRunPM1Designator { get; set; }
            public string RouteRunPM1CountString { get; set; }
            public string RouteRunPM1ArriveString { get; set; }
            public string RouteRunPM1CodesHardware { get; set; }
            public string RouteRunPM1CodesSupervision { get; set; }
            public string RouteRunPM2School { get; set; }
            public string RouteRunPM2Designator { get; set; }
            public string RouteRunPM2CountString { get; set; }
            public string RouteRunPM2ArriveString { get; set; }
            public string RouteRunPM2CodesHardware { get; set; }
            public string RouteRunPM2CodesSupervision { get; set; }
            public string RouteRunPM3School { get; set; }
            public string RouteRunPM3Designator { get; set; }
            public string RouteRunPM3CountString { get; set; }
            public string RouteRunPM3ArriveString { get; set; }
            public string RouteRunPM3CodesHardware { get; set; }
            public string RouteRunPM3CodesSupervision { get; set; }
            public string RouteRunAM1aSchool { get; set; }
            public string RouteRunAM1aDesignator { get; set; }
            public int RouteRunAM1aCount { get; set; }
            public string RouteRunAM1aArriveString { get; set; }
            public string RouteRunAM1aCodesHardware { get; set; }
            public string RouteRunAM1aCodesSupervision { get; set; }
            public string RouteRunAM2aSchool { get; set; }
            public string RouteRunAM2aDesignator { get; set; }
            public int RouteRunAM2aCount { get; set; }
            public string RouteRunAM2aArriveString { get; set; }
            public string RouteRunAM2aCodesHardware { get; set; }
            public string RouteRunAM2aCodesSupervision { get; set; }
            public string RouteRunAM3aSchool { get; set; }
            public string RouteRunAM3aDesignator { get; set; }
            public int RouteRunAM3aCount { get; set; }
            public string RouteRunAM3aArriveString { get; set; }
            public string RouteRunAM3aCodesHardware { get; set; }
            public string RouteRunAM3aCodesSupervision { get; set; }
            public string RouteRunAM4aSchool { get; set; }
            public string RouteRunAM4aDesignator { get; set; }
            public int RouteRunAM4aCount { get; set; }
            public string RouteRunAM4aArriveString { get; set; }
            public string RouteRunAM4aCodesHardware { get; set; }
            public string RouteRunAM4aCodesSupervision { get; set; }
            public string RouteRunPM1aSchool { get; set; }
            public string RouteRunPM1aDesignator { get; set; }
            public int RouteRunPM1aCount { get; set; }
            public string RouteRunPM1aArriveString { get; set; }
            public string RouteRunPM1aCodesHardware { get; set; }
            public string RouteRunPM1aCodesSupervision { get; set; }
            public string RouteRunPM2aSchool { get; set; }
            public string RouteRunPM2aDesignator { get; set; }
            public int RouteRunPM2aCount { get; set; }
            public string RouteRunPM2aArriveString { get; set; }
            public string RouteRunPM2aCodesHardware { get; set; }
            public string RouteRunPM2aCodesSupervision { get; set; }
            public string RouteRunPM3aSchool { get; set; }
            public string RouteRunPM3aDesignator { get; set; }
            public int RouteRunPM3aCount { get; set; }
            public string RouteRunPM3aArriveString { get; set; }
            public string RouteRunPM3aCodesHardware { get; set; }
            public string RouteRunPM3aCodesSupervision { get; set; }
            public string RouteRunPM4aSchool { get; set; }
            public string RouteRunPM4aDesignator { get; set; }
            public int RouteRunPM4aCount { get; set; }
            public string RouteRunPM4aArriveString { get; set; }
            public string RouteRunPM4aCodesHardware { get; set; }
            public string RouteRunPM4aCodesSupervision { get; set; }
            public string RouteRunAM1bSchool { get; set; }
            public string RouteRunAM1bDesignator { get; set; }
            public int RouteRunAM1bCount { get; set; }
            public string RouteRunAM1bArriveString { get; set; }
            public string RouteRunAM1bCodesHardware { get; set; }
            public string RouteRunAM1bCodesSupervision { get; set; }
            public string RouteRunAM2bSchool { get; set; }
        }

        //// GET: /Assignment/
        //public ViewResult IndexTheta(string sortOrder, string searchString)
        //{
        //    ViewBag.AssignmentSort = String.IsNullOrEmpty(sortOrder) ? "assignment_desc" : "";
        //    IQueryable<Assignment> assignments = from s in db.Assignments
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
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            assignments = assignments.Where(s => s.Resource.ResourceDesignatorString.Contains(searchString)
        //            || s.Route.RouteDesignatorString.Contains(searchString)
        //           || s.Route.RouteRunAM1Designator.Contains(searchString)
        //           || s.Route.RouteRunAM2Designator.Contains(searchString)
        //           || s.Route.RouteRunAM3Designator.Contains(searchString)
        //           || s.Route.RouteRunPM1Designator.Contains(searchString)
        //           || s.Route.RouteRunPM2Designator.Contains(searchString)
        //           || s.Route.RouteRunPM3Designator.Contains(searchString)
        //           || s.Route.RouteRunAM1School.Contains(searchString)
        //           || s.Route.RouteRunAM2School.Contains(searchString)
        //           || s.Route.RouteRunAM3School.Contains(searchString)
        //           || s.Route.RouteRunPM1School.Contains(searchString)
        //           || s.Route.RouteRunPM2School.Contains(searchString)
        //           || s.Route.RouteRunPM3School.Contains(searchString));
        //        }
        //        switch (sortOrder)
        //        {
        //            default:
        //                assignments = assignments.OrderBy(s => s.Route.RouteResourceTypeString).ThenBy(s => s.Route.RouteDesignatorString);
        //                break;
        //            case "contact_desc":
        //                assignments = assignments.OrderByDescending(s => s.Route.RouteDesignatorString);
        //                break;
        //            case "route":
        //                assignments = assignments.OrderBy(s => s.Contact.ContactDesignator1String);
        //                break;
        //            case "route_desc":
        //                assignments = assignments.OrderByDescending(s => s.Contact.ContactDesignator1String);
        //                break;
        //        }
        //    }
        //    catch (DataException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return View(assignments);
        //}
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

        public void mMethod(int number) //xx://home2/mMethod?number=2
        {
            mCount = number;
        }

        public void method2()
        {
            var a = mCount;
            //Trying to access mCount from here always gives me 0

        }
        #endregion
        #region /"=>" quote
        // https://forums.asp.net/t/2148630.aspx
        //   https://stackoverflow.com/questions/9714759/put-quotes-around-a-variable-string-in-javascript
        #endregion

        #region
        public ActionResult SendEmail()
        {
            //try
            //{

            //    SmtpClient client = new SmtpClient("server host", 25);
            //    client.UseDefaultCredentials = false;
            //    client.EnableSsl = true;
            //    client.Credentials = new NetworkCredential("Server UserName", "Password");


            //    MailMessage mail = new MailMessage();

            //    mail.From = new MailAddress("925752959@qq.com");
            //    mail.To.Add("yukit123@outlook.com");

            //    mail.Subject = "subject";
            //    mail.Body = "body";
            //    mail.IsBodyHtml = true;



            //    client.Send(mail);

            //    ViewBag.Status = "success!";

            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Status = "false!";
            //}



            return View();

        }


        public void bindStep3()//https://www.jb51.net/article/83803.htm
        {
            MailAddress MessageFrom = new MailAddress("925752959@qq.com"); //发件人邮箱地址 
            string MessageTo ="v-yuktao@microsoft.com"; //收件人邮箱地址 
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
    }
}
