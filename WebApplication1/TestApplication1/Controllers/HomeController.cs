using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }
    
        public ActionResult Test()
        {
            //string subject = @"Allowed characters for item description: space, numbers, English letters and following special characters: ! "" # $ % & ' ( ) * + , - . / : ; < = > ? @ ` [ \ ~ ] ^ _ {{ | }}";
            //var results = Regex.Match(subject, @"^[ -~]+$", RegexOptions.Multiline);

            //string subject2 = @"Allowed characters for item description: space, numbers, English letters and following special characters: ! "" # $ % & ' ( ) * + , - . / : ; < = > ? @ ` [ \ ~ ] ^ _ {{ | }}";
            //var results2 = Regex.Match(subject2, @"^[ -~]+$");
            ////var list = db.Charters.ToList().FirstOrDefault();
            //var qq = "au1";
            //var opportunities = (from c in db.author2s
            //                     join d in db.book2s on c.Author_id equals d.Author_id
            //                     group c by new { d.author2.Author_id, d.Title, c.Name }
            //     into grp
            //                     select new { product_name = grp.Key.Name, product_tonnage = grp.Key.Title }).Where(_ => _.product_name == qq).ToList();

            List<SelectListItem> country = db.CountrySizes.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.country, Selected = false }).DistinctBy(p => p.Text).ToList();
            //var GenreLst = new List<string>();

            //var GenreQry = (from d in db.author2s

            //                select new { Name = d.Name, linkkey = d.Author_id }).ToList();
            //var GenreQry2 = db.author2s.Select(p => new { p.Name, p.Author_id }).GroupBy(p=>p.Name).DistinctBy(p=>p.);
            //GenreLst.AddRange(GenreQry2.DistinctBy(_=>_.));

            ViewBag.country = new SelectList(country, "Value", "Text");

            #region join tables left join

            //var opportunities = (from c in db.CountrySizes
            //                     join d in db.AuthorModels on c.Id equals d.Id
            //                     group c by  new { c.country }
            //                     into grp
            //                     select new { product_name = grp.Key., product_tonnage = grp.Key.Title }).ToList();

            //var qry = db.CountrySizes.Join(db.AuthorModels,req => req.Id,spon => spon.Id,(req, spon) => new { CountrySizes = req, AuthorModels = spon })
            //.GroupBy(both => both.CountrySizes.country)
            //.Select (p=>new { aaa=p});



            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);


            //Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            //Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            //Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            //Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            //Pet barley = new Pet { Name = "Barley", Owner = terry };
            //Pet boots = new Pet { Name = "Boots", Owner = terry };
            //Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            //Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            //Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            //// Create two lists.
            //List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            //List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            //var query = from person in people
            //            join pet in pets on person equals pet.Owner into gj
            //            from subpet22 in gj.DefaultIfEmpty()
            //            select new { person.FirstName, PetName = subpet22?.Name ?? String.Empty };



            //var partialResult = (from c in db.CountrySizes
            //                     join o in db.AuthorModels
            //                     on c.Id equals o.Id into gj
            //                     from subpet in gj.DefaultIfEmpty()
            //                     select new
            //                     {
            //                         c.Id,
            //                         c.country
            //                     }).DistinctBy(m => m.country).ToList();


            //partialResult2和partialResult2 表倒个位置，左右连接是相对地
            //var partialResult2 = (from countr in db.CountrySizes
            //                     join auth in db.AuthorModels
            //                     on countr.Id equals auth.Id into gj
            //                     from j in gj.DefaultIfEmpty()
            //                     select new
            //                     {
            //                         //o.Id,
            //                         //o.Name
            //                         ID=j.Id.ToString(),
            //                         strName=j.Name
            //                     }).ToList();

            //var partialResult3 = (

            //                      from auth in db.AuthorModels
            //                      join countr in db.CountrySizes

            //                      on auth.Id equals countr.Id into gj
            //                      from j in gj.DefaultIfEmpty()
            //                      select new
            //                      {
            //                          ID = j.Id.ToString(),
            //                          strName = j.country
            //                      }).ToList();


            //partialResult4 内连接
            //var partialResult4 = (from countr in db.CountrySizes
            //                      join auth in db.AuthorModels
            //                      on countr.Id equals auth.Id 

            //                      select new
            //                      {
            //                          auth.Id,
            //                          countr.size                                  

            //                      }).ToList();

           //// partialResult5 内连接嵌套右连接 nest
           // var partialResult5 = (from Table2 in db.CountrySizes
           //                       join InnerJoin in (
           //                        from Table3 in db.AuthorModels
           //                        join Table1 in db.CountrySizes
           //                        on Table3.Id equals Table1.Id into leftJoin
           //                        from j in leftJoin.DefaultIfEmpty()
           //                        select new
           //                        {
           //                            CID = j.Id,
           //                            AID = Table3.Id,
           //                            ACC = Table3.Name,
           //                            SIZE = j.size,
           //                            NAME = j.country
           //                        }
           //                       )
           //                       on Table2.Id equals InnerJoin.AID
           //                       //where InnerJoin.AID > 1 && InnerJoin.ACC == "aaa"
           //                       where InnerJoin.CID>1 && InnerJoin.SIZE=="aaa"
           //                       orderby Table2.Id, InnerJoin.AID
           //                       select new
           //                       {
           //                           Table2.Id,
           //                           InnerJoin.NAME,
           //                           InnerJoin.AID

           //                       }).ToList();


            //var query = (from t2 in db.Table2
            //             join innerlist in (
            //              //db.CountrySizes
            //              from t3 in db.Table3
            //              join t1 in db.Table1
            //              on t3.Id equals t1.Id into leftlist
            //              from j in leftlist.DefaultIfEmpty()

            //              select new
            //              {
            //                  t1ID = j.Id,
            //                  t3ID = t3.Id,
            //                  AIG_ID = j.AIG_ID,
            //                  Department_ID = j.Department_ID,
            //                  Distribution_Code = j.Distribution_Code,
            //                  D_ID = t3.D_ID,
            //                  PLA_ID = t3.PLA_ID
            //              }
            //             )
            //             on t2.Id equals innerlist.t1ID
            //             where innerlist.AIG_ID == 431 && innerlist.Distribution_Code == 'A'
            //             orderby t2.PLA_NAME, innerlist.D_ID
            //             select new
            //             {
            //                 innerlist.PLA_ID,
            //                 innerlist.Department_ID,
            //                 t2.PLA_NAME,
            //                 innerlist.D_ID,
            //                 innerlist.Section_ID

            //             }).ToList();





            ////var list2 = db.CountrySizes.Select(p => new { p.country, p.Id, p.size }).DistinctBy(p => p.country).ToList();
            #endregion
            return View();
        }

        public class TRACK_NMBR_ViewModel
        {
            public string TRACK_NMBR { get; set; }
        }
        public ActionResult GetNextView(string keyword)
        {
            // ViewBag.Message = "Your contact page.";
            TRACK_NMBR_ViewModel vm = new TRACK_NMBR_ViewModel();
            vm.TRACK_NMBR = keyword;
            return View(vm);
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

        #region partial view https://forums.asp.net/t/2132585.aspx  https://forums.asp.net/t/2132850.aspx
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
        public ActionResult BuyItem2(int Id)
        {
            BuyItem employee = new BuyItem();
            employee.ItemID = 9;
            employee.ItmeName = "999";
            employee.StoreID = 99;
            return PartialView(employee);
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

            //for(int i=0;i< db.Charters.ToList().Count;i++)
            //{
            //   db.Charters.Select(_ => string.Format("{0:yyy/MM/dd}", _.CharterDate));
            //}
            ViewBag.CharterID = db.Charters.Select(a => new SelectListItem
            {

                Value = a.CharterID.ToString(),
                Text = SqlFunctions.DatePart("yyyy", a.CharterDate) + "/" + SqlFunctions.DatePart("MM", a.CharterDate) + "/" + SqlFunctions.DatePart("dd", a.CharterDate) + " " + a.CharterDestinationLocation1 + " " + a.CharterGroup + " " + a.CharterGroupLevelString + " " + a.CharterGroupGenderString
                //Text = a.CharterDate + " " + a.CharterDestinationLocation1 + " " + a.CharterGroup + " " + a.CharterGroupLevelString + " " + a.CharterGroupGenderString

            }
           ).ToList();


            //foreach (var item in ViewBag.CharterID)
            //{
            //    item=string.Format("{0:yyy/MM/dd}", item);
            //}
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
        # region ExportExcel
        public ActionResult ExportExcel_Index()
        {
            var products = new System.Data.DataTable("teste");
            products.Columns.Add("col1", typeof(int));
            products.Columns.Add("col2", typeof(string));

            for (int i = 0; i < 100000; i++)
            {
                products.Rows.Add(i, "product 1");
            }

            Session["SearchLists"] = products;
            return View();
        }


        public ActionResult ExportExcel()
        {
            var grid = new GridView();
            grid.DataSource = Session["SearchLists"];
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View();
        }
        #endregion


        public ActionResult DropDown()
        {
            List<SelectListItem> country = db.CountrySizes.Select(x => new SelectListItem { Value = x.country, Text = x.country, Selected = false }).DistinctBy(p => p.Value).ToList();
            List<SelectListItem> size = db.CountrySizes.Select(x => new SelectListItem { Value = x.size, Text = x.size, Selected = false }).DistinctBy(p => p.Value).ToList();
            ViewBag.country = new SelectList(country, "Text", "Value");
            ViewBag.size = new SelectList(size, "Text", "Value");
            return View();
        }

        [HttpGet]
        public JsonResult GetData(string country, string size)
        {
            var list = db.CountrySizes.Where(_ => _.country == country && _.size == size).ToList();
            return Json(new { showlist = list, msg = true }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult progress()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult progress2()//http://jsfiddle.net/6m9gf2a2/
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpGet]
        public JsonResult GetResponses()
        {
            var list = db.CountrySizes.ToList();
            return Json(new { showlist = list, msg = true }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ModelBind_Index()
        {
            var model = new AuthorModel();
            return View(model);
        }

        [HttpPost]
        public string ModelBind_Index(AuthorModel author)
        {
            var sb = new StringBuilder();
            try
            {
                sb.AppendFormat("Author : {0}", author.Name);
                sb.AppendLine("<br />");
                sb.AppendLine("--------------------------------");
                sb.AppendLine("<br />");
                foreach (var book in author.Books)
                {
                    sb.AppendFormat("Title : {0} | Published Date : {1}|Radio:{2}", book.Title, book.PublishedDate, book.Radiobutton);
                    sb.AppendLine("<br />");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }

        //public class Dynamicalgenerate
        //{
        //    public int Id { get; set; }
        //    public string DynamicTextBox { get; set; }

        //    public string rbtnCount { get; set; }


        //}

        public ActionResult Dynamicalgenerate()
        {
            var model = new AuthorModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Dynamicalgenerate_Create(string[] DynamicTextBox, string[] rbtnCount)
        {

            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            //string message = "";
            //foreach (string textboxValue in DynamicTextBox)
            //{
            //    message += textboxValue + "\\n";
            //}

            //T1.Quantity = message;
            return View();
        }


        public class ManageAIGViewModel

        {


            public int ID { get; set; }

            public int? AigNumber { get; set; }

            public string AigType { get; set; }
        }
        public ActionResult GetEnumeriator_Index()
        {
            var list = new List<ManageAIGViewModel>();

            list.Add(new ManageAIGViewModel() { ID = 1, AigNumber = 11, AigType = "aaaaaAigType" });

            list.Add(new ManageAIGViewModel() { ID = 2, AigNumber = 22, AigType = "bbbbbAigType" });

            list.Add(new ManageAIGViewModel() { ID = 3, AigNumber = 33, AigType = "cccccAigType" });
            return View(list);

        }

        //public void ConvertHtmlToImage()
        //{
        //    Bitmap m_Bitmap = new Bitmap(400, 600);
        //    PointF point = new PointF(0, 0);
        //    SizeF maxSize = new System.Drawing.SizeF(500, 500);
        //    HtmlRenderer.HtmlRender.Render(Graphics.FromImage(m_Bitmap),
        //                                            "<html><body><p>This is a shitty html code</p>"
        //                                            + "<p>This is another html line</p></body>",
        //                                             point, maxSize);

        //    m_Bitmap.Save(@"C:\Test.png", ImageFormat.Png);
        //}

        private readonly List<Client> clients = new List<Client>()
    {
        new Client { Id = 1, Name = "Julio Avellaneda", Email = "julito_gtu@hotmail.com" },
        new Client { Id = 2, Name = "Juan Torres", Email = "jtorres@hotmail.com" },
        new Client { Id = 3, Name = "Oscar Camacho", Email = "oscar@hotmail.com" },
        new Client { Id = 4, Name = "Gina Urrego", Email = "ginna@hotmail.com" },
        new Client { Id = 5, Name = "Nathalia Ramirez", Email = "natha@hotmail.com" },
        new Client { Id = 6, Name = "Raul Rodriguez", Email = "rodriguez.raul@hotmail.com" },
        new Client { Id = 7, Name = "Johana Espitia", Email = "johana_espitia@hotmail.com" }
    };
        public class CustomerModel
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int RecordCount { get; set; }

            public List<Client> client { get; set; }



        }

        public ActionResult GridMVC_Index()//https://www.codeproject.com/Tips/597253/Using-the-Grid-MVC-in-ASP-NET-MVC
        {
            ViewBag.clients = clients;
            return View(clients);
        }

        [HttpPost]
        public JsonResult AjaxMethod(int pageIndex)
        {
            //NorthwindEntities entities = new NorthwindEntities();
            CustomerModel model = new CustomerModel();
            model.PageIndex = pageIndex;
            model.PageSize = 10;
            model.RecordCount = clients.Count();
            int startIndex = (pageIndex - 1) * model.PageSize;
            model.client = (from customer in clients
                            select customer)
                            .OrderBy(customer => customer.Id)
                            .Skip(startIndex)
                            .Take(model.PageSize).ToList();
            return Json(model);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult DeleteInterest(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Interest cat = db.Interest.Find(id);
            //if (cat == null)
            //{
            //    return HttpNotFound();
            //}
            var list = db.Charters.ToList().FirstOrDefault();
            return View(list);

        }


        [HttpPost, ActionName("DeleteInterest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedI(int id)
        {
            var list = db.Charters.ToList().FirstOrDefault();
            //Remaining code...
                return View(list);
        }


        private static Random _rnd = new Random();

        private static List<string> _db = new List<string> { "Yes", "No", "Definitely, yes", "I don't know", "Looks like, yes" };

        [HttpGet]
        public ActionResult Menu_Index()
        {
            return View(new SampleViewModel());
        }


        [HttpPost]
        public JsonResult GetAnswer(string question)
        {
            int index = _rnd.Next(_db.Count);
            var answer = _db[index];
            return Json(answer);
        }

        public ActionResult Aspnet_Index()
        {
            return View(new SampleViewModel());
        }

        #region email

        public class OpsViewModel
        {
            //public OpsModel OpsModel { get; set; }
            //public string ToEmailName { get; set; }
            //public int SelectedId { get; set; }

            public OpsModel OpsModel { get; set; }
            public IList<SelectListItem> Carrier { get; set; }
            public int[] SelectedCarrierId { get; set; }
        }

        public ActionResult email_Index()
        {
           // pageSetup();
            return View("SpotRateRequest");
        }

        [HttpPost]
        public ActionResult _OpsResults(int legNumber)
        {
            //pageSetup();

            if (legNumber != 0)
            {
                //List<CALL_TO_MY_DB_Result> srDetails = db_preproc.CALL_TO_MY_DB__Sel(legNumber).ToList();

                //ViewBag.RatesCount = srDetails.Count();
                //ViewBag.Rates = srDetails;
                //List<get_list_Sel_Result> carrierList = db_Get_list_Sel("XXXXX").ToList();
                //ViewBag.CarrierList = carrierList.Select(c => new SelectListItem
                //{
                //    Value = Convert.ToString(c.ToId),
                //    Text = c.Carrier

                //});
                //ViewBag.CarrierList = new List<SelectListItem>
                //{
                //    new SelectListItem {Text = "Apple", Value = "Apple"},
                //    new SelectListItem {Text = "Pear", Value = "Pear"},
                //    new SelectListItem {Text = "Banana", Value = "Banana"},
                //    new SelectListItem {Text = "Orange", Value = "Orange"},
                //};
                var model = new OpsViewModel();
                model.Carrier  = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Apple1", Value = "Apple"},
                    new SelectListItem {Text = "Pear1", Value = "Pear"},
                    new SelectListItem {Text = "Banana1", Value = "Banana"},
                    new SelectListItem {Text = "Orange1", Value = "Orange"},
                };


                return PartialView("_OpsResults", model);
            }


            return View("SpotRateRequest");
        }

        [HttpPost]
        public ActionResult SendEmailView(string Carrier)
        {
            //pageSetup();
            //call SendEmailView view to invoke webmail  
            string list = "someEmail@somedomain.com; anotheremail@anotherdomain.com;";
            List<string> email = new List<string>();
           
            return View("SendEmailView");
        }
        #endregion

        #region Datepicker for Bootstrap
        public ActionResult BootstrapDatepicker()//https://vitalets.github.io/bootstrap-datepicker/
        {
            return View();
        }
        #endregion


        #region Cant Insert Data into Database Using Ajax //https://forums.asp.net/t/2142091.aspx
        //public class RMA_History
        //{
        //    public int Id { get; set; }
        //    public string Kundenummer { get; set; }
        //    public string Ordrenummer { get; set; }
        //}

        public ActionResult ProcessRequestRMAO_Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ProcessRequestRMA(RMA_History model)
        {

            ViewBag.ID = model.Id;

            if (ModelState.IsValid)
            {
                if (ViewBag.ID == 0)
                {
                    db.RMA_Histories.Add(new RMA_History
                    {
                        //Id = ViewBag.ID,
                        Kundenummer = model.Kundenummer,
                        Ordrenummer = model.Ordrenummer

                    });
                    db.SaveChanges();
                }


            }
            else  //(!ModelState.IsValid) //
            {
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
            }


            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region enum 枚举

        public ActionResult enum_Index()
        {

            //var options = new List<Relationship>();

            //options.Add(new Relationship() { Id = 0, relationshipType = (TestApplication1.Models.RelationshipType.Child), RelationshipName = "ab1" });

            //options.Add(new Relationship() { Id = 1, relationshipType = (TestApplication1.Models.RelationshipType.Self), RelationshipName = "ab2" });

            //options.Add(new Relationship() { Id = 2, relationshipType = (TestApplication1.Models.RelationshipType.Spouse), RelationshipName = "ab3" });

            //var enumlist = options[1];
            Relationship model = new Relationship();
            return View(model);
        }
        #endregion

        #region  jqGrid
        public ActionResult jqGrid_Index()//https://www.c-sharpcorner.com/article/using-jqgrid-with-asp-net-mvc/
        {
            //http://www.trirand.com/blog/jqgrid/jqgrid.html
            //http://blog.mn886.net/jqGrid/

            return View();
        }


        public JsonResult GetCustomers(string sord, int page, int rows, string searchString)
        {
            // Create Instance of DatabaseContext class for Accessing Database.
            TestApplication1Context db = new TestApplication1Context();

            //Setting Paging
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = db.Customers.Select(
                a => new
                {
                    a.CustomerID,
                    a.CompanyName,
                    a.ContactName,
                    a.ContactTitle,
                    a.City,
                    a.PostalCode,
                    a.Country,
                    a.Phone,
                });

            //Get Total Row Count
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            //Setting Sorting
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.CustomerID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.CustomerID);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //Setting Search
            if (!string.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(m => m.CompanyName == searchString || m.ContactName == searchString);
            }
            //Sending Json Object to View.
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult CreateCustomer([Bind(Exclude = "CustomerID")] Customers customers)
        {
            StringBuilder msg = new StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    using (TestApplication1Context db = new TestApplication1Context())
                    {
                        db.Customers.Add(customers);
                        db.SaveChanges();
                        return Json("Saved Successfully", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var errorList = (from item in ModelState
                                     where item.Value.Errors.Any()
                                     select item.Value.Errors[0].ErrorMessage).ToList();

                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var errormessage = "Error occured: " + ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }

        }

        public string EditCustomer(Customers customers)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    using (TestApplication1Context db = new TestApplication1Context())
                    {
                        db.Entry(customers).State = EntityState.Modified;
                        db.SaveChanges();
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Some Validation ";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string DeleteCustomer(int Id)
        {
            using (TestApplication1Context db = new TestApplication1Context())
            {
                Customers customer = db.Customers.Find(Id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return "Deleted successfully";
            }
        }
        #endregion

        #region convert url.action

        public ActionResult url_Index()
        {

            //var options = new List<Relationship>();

            //options.Add(new Relationship() { Id = 0, relationshipType = (TestApplication1.Models.RelationshipType.Child), RelationshipName = "ab1" });

            //options.Add(new Relationship() { Id = 1, relationshipType = (TestApplication1.Models.RelationshipType.Self), RelationshipName = "ab2" });

            //options.Add(new Relationship() { Id = 2, relationshipType = (TestApplication1.Models.RelationshipType.Spouse), RelationshipName = "ab3" });

            //var enumlist = options[1];
            Relationship model = new Relationship();
            return View(model);
        }

        #endregion

        #region convert PagedListPager

        public ActionResult PagedListPager_Index(int? page)
        {
            //https://github.com/troygoode/PagedList
            //https://gist.github.com/troygoode/1053136
            //http://www.nudoq.org/#!/Packages/PagedList.Mvc/PagedList.Mvc/PagedListRenderOptions

            var products = db.author2s.ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.ToPagedList(pageNumber, 2); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }

        #endregion
    }
}