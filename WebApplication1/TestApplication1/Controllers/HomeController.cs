using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
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

            // partialResult5 内连接嵌套右连接 nest
            var partialResult5 = (from Table2 in db.CountrySizes
                                  join InnerJoin in (
                                   from Table2 in db.AuthorModels
                                   join Table3 in db.CountrySizes
                                   on Table2.Id equals Table3.Id into leftJoin
                                   from j in leftJoin.DefaultIfEmpty()
                                   select new
                                   {
                                       CID = j.Id,
                                       AID = Table2.Id,
                                       ACC = Table2.Name,
                                       SIZE = j.size,
                                       NAME = j.country
                                   }
                                  )
                                  on Table2.Id equals InnerJoin.AID
                                  //where InnerJoin.AID > 1 && InnerJoin.ACC == "aaa"
                                  where InnerJoin.CID > 1 && Equals(InnerJoin.SIZE,"aa")
                                  orderby Table2.Id, InnerJoin.AID
                                  select new
                                  {
                                      Table2.Id,
                                      InnerJoin.NAME,
                                      InnerJoin.AID

                                  }).ToList();



            //var partialResult6 = (
            //                       from rightJoinTable in
            //                        (from Table2 in db.AuthorModels
            //                        join Table1 in db.CountrySizes
            //                        on Table2.Id equals Table1.Id into rightJoin
            //                        from rj in rightJoin.DefaultIfEmpty()
            //                         select new
            //                         {
            //                             CID = rj.Id,
            //                             AID = Table2.Id,
            //                             NAME = Table2.Name,
            //                             SIZE = rj.size
            //                         }
            //                        )
            //                       join Table3 in db.CountrySizes
        
            //                       on rightJoinTable.AID equals Table3.Id into leftjoin
            //                       orderby rightJoinTable.NAME, leftjoin.GroupBy(p=>p.Id)

            //                       from lj in leftjoin.DefaultIfEmpty()
            //                       select new
            //                       {
            //                           CID = lj.Id,//data from Table3
            //                           AID = rightJoinTable.AID, //data from Table2
            //                           SIZE = rightJoinTable.SIZE //data from Table1
            //                       }
                                  
            //                       ).ToList();



            ////var list2 = db.CountrySizes.Select(p => new { p.country, p.Id, p.size }).DistinctBy(p => p.country).ToList();
            #endregion
            return View();
        }

        public class TRACK_NMBR_ViewModel
        {
            public string TRACK_NMBR { get; set; }
        }

        public ActionResult GetNextView(string keyword/*int id*/)
        {
            //var xx = Request.QueryString["id"].ToString();
            ViewBag.Message = "Your contact page.";
            TRACK_NMBR_ViewModel vm = new TRACK_NMBR_ViewModel();
            vm.TRACK_NMBR = keyword;

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> GetNextView(TRACK_NMBR_ViewModel fILE_RCPTS_LOG)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.FILE_RCPTS_LOG.Add(fILE_RCPTS_LOG);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(fILE_RCPTS_LOG);
        //}

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
            
             //(DateTime.Today.Date.AddMonths(-1))
            

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
            #region dropdownlist selected value 预选项
            // List<SelectListItem> size = db.CountrySizes.Select(x => new SelectListItem { Value = x.size, Text = x.size, Selected = false }).DistinctBy(p => p.Value).ToList();
            //ViewBag.country = new SelectList(db.CountrySizes, "Id", "country", 3);
            #endregion

            List<SelectListItem> country = db.CountrySizes.Select(x => new SelectListItem { Value = x.country, Text = x.country, Selected = false }).DistinctBy(p => p.Value).ToList();
            List<SelectListItem> size = db.CountrySizes.Select(x => new SelectListItem { Value = x.size, Text = x.size, Selected = false }).DistinctBy(p => p.Value).ToList();
            ViewBag.country = new SelectList(country, "Text", "Value");
            ViewBag.size = new SelectList(size, "Text", "Value");
            return View();
        }

        [HttpGet]
        public JsonResult GetData(string country, string size)
        {
            var list = db.CountrySizes.Where(_ => _.country == country && _.size == size ).ToList();
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
        #region  GridMvc 初始化生成GridMvc change下拉框触发生成GridMvc
        private readonly List<Client> clients = new List<Client>()
    {
        new Client { Id = 1, Name = "Select", Email = "julito_gtu@hotmail.com" },
        new Client { Id = 2, Name = "Active", Email = "jtorres@hotmail.com" },
        new Client { Id = 3, Name = "In Active", Email = "oscar@hotmail.com" },
        new Client { Id = 4, Name = "Hold", Email = "ginna@hotmail.com" },
        new Client { Id = 5, Name = "Hold", Email = "natha@hotmail.com" },
        new Client { Id = 6, Name = "Select", Email = "rodriguez.raul@hotmail.com" },
        new Client { Id = 7, Name = "Select", Email = "johana_espitia@hotmail.com" }
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

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Select", Value = "Select" });
            items.Add(new SelectListItem { Text = "Active", Value = "Active" });
            items.Add(new SelectListItem { Text = "In Active", Value = "In Active" });
            items.Add(new SelectListItem { Text = "Hold", Value = "Hold" });

            //List<SelectListItem> selectlist = clients.Select(x => new SelectListItem { Value = x.Name, Text = x.Name, Selected=(items.Any(a=>a.Text==x.Name)) }).DistinctBy(p=>p.Value).ToList();
            //ViewBag.selectlist = new SelectList(items, "Text", "Value");
  

            ViewBag.Status = new SelectList(items);

            return View(clients);
        }

        [HttpPost]
        public JsonResult AjaxMethod(int pageIndex)
        {
            //NorthwindEntities entities = new NorthwindEntities();
            CustomerModel model = new CustomerModel();
            model.PageIndex = pageIndex;
            model.PageSize = 3;
            model.RecordCount = clients.Count();
            int startIndex = (pageIndex - 1) * model.PageSize;
            model.client = (from customer in clients
                            select customer)
                            .OrderBy(customer => customer.Id)
                            .Skip(startIndex)
                            .Take(model.PageSize).ToList();
            return Json(model);
        }

        //[HttpPost]
        public JsonResult getLeads(string UserName)
        {
            ////NorthwindEntities entities = new NorthwindEntities();
            //CustomerModel model = new CustomerModel();
            //model.PageIndex = 2;
            //model.PageSize = 3;
            //model.RecordCount = clients.Count();
            //int startIndex = (2 - 1) * model.PageSize;
            //model.client = (from customer in clients
            //                select customer)
            //                .OrderBy(customer => customer.Id)
            //                .Skip(startIndex)
            //                .Take(model.PageSize).ToList();
  
            return Json(new { imagelist = "/images/Arrow.png" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

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

            //return Json(new { success=0,model }, JsonRequestBehavior.AllowGet);

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

        public class RMAHistory
        {
            public int? Id { get; set; }
            public DateTime OrdreDato { get; set; }
            public string AntalRMA { get; set; }

        }
        public ActionResult RMAList(int? pageNumber)//PagedList

        {

            //List<RMAHistory> query = db.RMAStatus.Join(db.RMA_History, u => u.ID, y => y.StatusID, (u, y) => new { u, y }).
            //Where(x => x.y.Ordrenummer.Contains(searchingrma) && x.y.Fakturnummer.Contains(searchingrma) || searchingrma == null).
            //Select(t => new RMAHistory
            //{

            //    OrdreDato = t.y.OrdreDato,
            //    AntalRMA = t.y.AntalRMA


            //}).OrderBy(t => t.OrdreDato).ToPagedList(pageNumber ?? 1, 5).ToList();

            var query = db.AuthorModels.Join(db.CountrySizes, u => u.Id, y => y.Id, (u, y) => new { u, y }).
           Where(x => x.y.country.Contains("FILE_DESC 1")).
           Select(t => new RMAHistory
           {

               Id = t.y.Id,
               AntalRMA = t.y.size


           }).OrderBy(t => t.Id).ToList();

          //  ViewBag.Model = query;
            IPagedList<RMAHistory> query2 = query.ToPagedList(pageNumber ?? 1, 5);


            return View(query2);




        }
        #endregion

        #region SideBar
        public ActionResult SideBar_Index()
        {
            //https://blackrockdigital.github.io/startbootstrap-simple-sidebar/#

            return View();
        }

        #endregion

        #region sss
        //public class WidgetView
        //{
        //    public string WidgetName { get; set; }
        //    public string WidgetDescription { get; set; }


        //}
        public class WidgetView
        {
            public int vId { get; set; }
            public string vName { get; set; }


        }
        public ActionResult Database_Index()
        {
            List<WidgetView> wdgList = new List<WidgetView>();
            //var widgetlist = db.Widgets.OrderBy(a => a.SortOrder).ToList();



            //foreach (var w in widgetlist)
            //{
            //    WidgetView widget = new WidgetView();
            //    widget.WidgetName = w.WidgetName;
            //    widget.WidgetDescription = w.WidgetDescription;
            //   // widget.sortorder = w.SortOrder;
            //    wdgList.Add(widget);
            //}

           // var widgetlist = db.Database.SqlQuery<Tuple<int, string>>("select * from AuthorModels").ToList();
            var widgetlist = db.AuthorModels.OrderBy(a => a.Id).ToList();

            foreach (var w in widgetlist)
            {
                WidgetView widget = new WidgetView();
                widget.vId = w.Id;
                widget.vName = w.Name;
                // widget.sortorder = w.SortOrder;
                wdgList.Add(widget);
            }


            return View(wdgList);
        }

        #endregion
        public ActionResult clock()//https://cssanimation.rocks/clocks/
        {
            return View();
        }

        public class OfferView
        {
            public string CurrencyName { get; set; }
            public string CurrencyNameISO { get; set; }
            public string regionSelected { get; set; }
            public string currencyList { get; set; }
            public List<SelectListItem> regionSelection { get; set; }

           
        }


        public ActionResult PrimaryView()
        {
            //Processing code here
            var selectlist = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
            ViewBag.regionSelect_ddl = selectlist;
            OfferView model = new OfferView();
            return View(model);
        }

        [HttpPost]
        public ActionResult PrimaryView(OfferView model)
        {
            //Processing code here
            var selectlist = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
            ViewBag.regionSelect_ddl = selectlist;

            return View();
        }
        [HttpGet]
        public ActionResult PartialView(string selectedRegionName)
        {
            OfferView model = new OfferView();
            model.regionSelected = selectedRegionName;
            //DataTable dt = new DataTable();

            //if (selectedRegionName == "APAC")
            //{
            //    model.currencyList = model.currencyList_APAC.Copy();
            //}
            //else if (selectedRegionName == "AMER")
            //{
            //    model.currencyList = model.currencyList_AMER.Copy();
            //}
            //else if (selectedRegionName == "EMEA")
            //{
            //    model.currencyList = model.currencyList_EMEA.Copy();
            //}
            //else
            //{
            //    return View();
            //}

            return PartialView("_PartialView", model);
        }

        #region BootStrap Validator
        public class BootStrapValidatorModel
        {
            public int Id { get; set; }
           
            public string userName { get; set; }

            public string pwd { get; set; }

        }

        public ActionResult BootStrapValidator()
        {

            //var options = new List<BootStrapValidatorModel>();

            //options.Add(new BootStrapValidatorModel() { Id = 0, userName = "aa", pwd = "ab1" });

            //options.Add(new BootStrapValidatorModel() { Id = 1, userName = "bb", pwd = "ab2" });

            //options.Add(new BootStrapValidatorModel() { Id = 2, userName = "cc", pwd = "ab3" });

            //var enumlist = options[1];
            CountrySize model = new CountrySize();
            return View(model);
        }
        #endregion


        #region model popup submit without form by ajax FormData Upload
        public ActionResult PageBuilder()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult ModalUploader2(HttpPostedFileBase file) //HttpPostedFileBase file有效
        {

            var file3 = Request.Files[0];//有效

            HttpPostedFileBase file2 = Request.Files["file"]; //有效
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file.FileName.Replace(" ", "-")));
                    string extension = Path.GetExtension(file.FileName);
                    //if (!ValidateExtension(extension))
                    //{
                    //    ViewBag.Message = "Not a valid image type.";
                    //    return View();
                    //}

                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }

            // return View();
            //return RedirectToAction("PageBuilder");

            return Json(new { Message = ViewBag.Message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region dynamic linq
        public class Employee
        {
            public string Name { get; set; }
            public string State { get; set; }
            public string Department { get; set; }

        }
        public ActionResult DynamicLinq()//https://www.nuget.org/packages/System.Linq.Dynamic/ install
        {

            IQueryable result;
            //List<Employee> result2;

            Employee[] empList = new Employee[6];
            empList[0] = new Employee() { Name = "CA", State = "A", Department = "xyz" };
            empList[1] = new Employee() { Name = "ZP", State = "B", Department = "xyz" };
            empList[2] = new Employee() { Name = "AC", State = "B", Department = "xyz" };
            empList[3] = new Employee() { Name = "AA", State = "A", Department = "xyz" };
            empList[4] = new Employee() { Name = "A2", State = "A", Department = "pqr" };
            empList[5] = new Employee() { Name = "BA", State = "B", Department = "pqr" };

            List<string> sortable_bot = empList.Select(_ => _.State).ToList();
           // List<string> sortable_bot = new List<string>() { "State", "Department" };

            var empqueryable = empList.AsQueryable();
            var dynamiclinqquery = DynamicQueryable.GroupBy(empqueryable, "new (State, Department)", "it");


            var eq = empqueryable.GroupBy("new (State, Department)", "it").Select("new(it.Key as Key, it as Employees)");
            //var eq = empqueryable.GroupBy("new (State, Department)", "it");

            var keyEmplist = (from dynamic dat in eq select dat).ToList();

            //result2 = eq.Select("new (it.Key as Key , it.Select(it." + sortable_bot[0] + ").Count()  as Count)");
           //var result2 = eq.Select("new (it.Key as Key , it.Select(it." + sortable_bot[0] + ").Count()  as Count)");

            //  var result3 = eq.Select("new (it.Key as Key , it.Select(it.State).Count()  as Count)");
            

            foreach (var group in keyEmplist)
            {
                var key = group.Key;
                var elist = group.Employees;

                foreach (var emp in elist)
                {

                }
            }
            
            return View(keyEmplist);
        }
        #endregion

        #region aria-labelledby dropdown-menu bootstrap dropdownlist

        public class dropdown_menuVM
        {
            public List<MembershipTypes> MembershipTypes { get; set; }
            public Customer Customer { get; set; }
        }

        public class MembershipTypes
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public class Customer
        {
            public int MembershipTypeId { get; set; }
            public string MembershipTypeName { get; set; }
        }
        public ActionResult dropdown_menu()
        {
            List<MembershipTypes> MembershipTypeslist = new List<MembershipTypes>();
            MembershipTypeslist.Add(new MembershipTypes() { ID = 1, Name = "AA"});
            MembershipTypeslist.Add(new MembershipTypes() { ID = 2, Name = "BB" });
            MembershipTypeslist.Add(new MembershipTypes() { ID = 3, Name = "CC" });
            MembershipTypeslist.Add(new MembershipTypes() { ID = 4, Name = "DD" });

           Customer Customerlist = new Customer() { MembershipTypeId=1, MembershipTypeName = "CustomerAA" };

            dropdown_menuVM model = new dropdown_menuVM();
            model.Customer = Customerlist;
            model.MembershipTypes = MembershipTypeslist;
            return View(model);
        }

        [HttpPost]
        public ActionResult dropdown_menu(dropdown_menuVM model,int hiddenID)
        {
            //List<MembershipTypes> MembershipTypeslist = new List<MembershipTypes>();
            //MembershipTypeslist.Add(new MembershipTypes() { ID = 1, Name = "AA" });
            //MembershipTypeslist.Add(new MembershipTypes() { ID = 2, Name = "BB" });
            //MembershipTypeslist.Add(new MembershipTypes() { ID = 3, Name = "CC" });
            //MembershipTypeslist.Add(new MembershipTypes() { ID = 4, Name = "DD" });

            //Customer Customerlist = new Customer() { MembershipTypeId = 1, MembershipTypeName = "CustomerAA" };

            //dropdown_menuVM model = new dropdown_menuVM();
            return View();
        }
        #endregion

        //public JsonResult ProcessRequestRMA(RMAHistory model, string SelectedRMAAntal)
        //{
        //    var RMA = new RMA_History
        //    {

        //        Antal = model.Antal,
        //        AntalRMA = SelectedRMAAntal
        //    };

        //    if (SelectedRMAAntal > model.Antal)
        //    {
        //        return Json(new { success = 0 }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {

        //        db.RMA_History.Add(RMA);
        //        db.SaveChanges();
        //        return Json(new { success = 1, model }, JsonRequestBehavior.AllowGet);
        //    }

        //}

        public class Timervm
        {
            public DateTime EndDate { get; set; }

        }
        public ActionResult Timer()
        {
            //List<Timervm> list = new List<Timervm>() {
            //new Timervm { EndDate=Convert.ToDateTime("2018-01-01")},
            //new Timervm { EndDate=Convert.ToDateTime("2018-02-02") },
            //new Timervm { EndDate=Convert.ToDateTime("2018-03-03") }
            //};
            //return Json(new { list }, JsonRequestBehavior.AllowGet);

           return View();
        }
        public JsonResult Timerajax()
        {
            List<Timervm> list = new List<Timervm>() {
            new Timervm { EndDate=Convert.ToDateTime("2018-01-01")},
            new Timervm { EndDate=Convert.ToDateTime("2018-02-02") },
            new Timervm { EndDate=Convert.ToDateTime("2018-03-03") }
            };
            return Json(new {  list }, JsonRequestBehavior.AllowGet);
            //return View(list);
        }

        public ActionResult Timer2()
        {
            //List<Timervm> list = new List<Timervm>() {
            //new Timervm { EndDate=Convert.ToDateTime("2018-01-01")},
            //new Timervm { EndDate=Convert.ToDateTime("2018-02-02") },
            //new Timervm { EndDate=Convert.ToDateTime("2018-03-03") }
            //};
            //return Json(new { list }, JsonRequestBehavior.AllowGet);

            return View();
        }

        #region devexpress combobox
        public ActionResult Devexpress_Combobox()
        {
            //question https://forums.asp.net/p/2143575/6217140.aspx?p=True&t=636668664003231385
            //https://demos.devexpress.com/MVCxDataEditorsDemos/Editors/ComboBox
            //https://github.com/DevExpress-Examples/mvc-combobox-extension-cascading-combo-boxes-e2844
            // https://documentation.devexpress.com/AspNet/8163/ASP-NET-MVC-Extensions/Getting-Started/Integration-into-ASP-NET-MVC-Project/Manual-Integration-into-an-Existing-Project
            //https://documentation.devexpress.com/AspNet/11418/ASP-NET-WebForms-Controls/Data-Editors/Editor-Types/ASPxComboBox/Overview/ASPxComboBox-Overview
            //https://documentation.devexpress.com/AspNet/16137/ASP-NET-MVC-Extensions/Getting-Started/How-It-Works
            ViewBag.Message = "Your contact page.";

            Session["Contactid"] = db.CountrySizes.ToList();

            return View();
        }
        #endregion

        # region validation_modalpopupexample
        public class CedulaAppViewModel
        {
            [Required]
            [Display(Name = "Firstname")]
            public string Firstname { get; set; }
            [Required]
            [Display(Name = "Middle Initial")]
            public string MiddleInitial { get; set; }
            [Required]
            [Display(Name = "Surname")]
            public string Surname { get; set; }
        }

        public ActionResult validation_modalpopup()//https://forums.asp.net/p/2143505/6217182.aspx?Re+MVC+trigger+validation+on+button+click
        {
            return View();
        }

        [HttpPost]
        public ActionResult validation_modalpopup(CedulaAppViewModel model)
        {
             return View();
        }

        #endregion

        public class Groupby_IndexVm
        {
            public int MyProperty { get; set; }
            public List<author2> author2 { get; set; }

        }
        public ActionResult Groupby_Index()
        {
            //var list = new List<TestViewModel>();
            var list = db.CountrySizes.GroupBy(p => p.country, (key, group) => new { GroupName = key, Items = group.ToList() });
            ViewData["List"] = db.CountrySizes.GroupBy(p => p.country).ToList();

            var model = db.CountrySizes.GroupBy(p => p.country).ToArray();


            return View(model);
        }
    }
}