using Microsoft.Ajax.Utilities;
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

            ////var opportunities = (from c in db.CountrySizes
            ////                     join d in db.AuthorModels on c.Id equals d.Id
            ////                     group c by  new { c.country }
            ////                     into grp
            ////                     select new { product_name = grp.Key., product_tonnage = grp.Key.Title }).ToList();

            ////var qry = db.CountrySizes.Join(db.AuthorModels,req => req.Id,spon => spon.Id,(req, spon) => new { CountrySizes = req, AuthorModels = spon })
            ////.GroupBy(both => both.CountrySizes.country)
            ////.Select (p=>new { aaa=p});



            //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

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



    }
}