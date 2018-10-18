using ClosedXML.Excel;
//using Kendo.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApiTest.Controllers;
using WebApiTest.Models;
using WebApplication1.Helpers;
using WebApplication1.Models;
using static WebApplication1.FilterConfig;
//using Kendo.Mvc.UI

namespace WebApplication1.Controllers
{

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class BolgViewModel
    {
        /// <summary>
        /// blogs
        /// </summary>
        public List<Blog> blogs { get; set; }
        public List<Student> students { get; set; }
    }

    public class BolgView2Model
    {
        public List<Blog> blogs { get; set; }
        public List<Author> authors { get; set; }

    }
    public class boolModel
    {
        //public int BlogId { get; set; }
        public string BlogId { get; set; }

        public string Name { get; set; }


    }
    [SessionExpireFilter]
    public class HomeController : BaseController
    {

        private BlogContext db = new BlogContext();

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Index()
        {
            #region Regex
            string studentinfo = "Student Info : \n[]Student Attendance \n[]Student Lunch Time\n[]Student Play time\n[]Student Library time, \nStudent Class room Info : \n[]Maths Class Time \n[]Physics Class Time \n[]GK Class Time \n\nFinal Report";
            List<string> pattern = new List<string>();
            pattern.Add("\\[\\]");
            string[] studentRecord = null;

            try
            {
                if (studentinfo != null && pattern != null)
                {
                    studentRecord = Regex.Split(studentinfo, @"" + pattern[0] + "", RegexOptions.IgnoreCase).Where(s => s.Contains(pattern[0]) && s != string.Empty).ToArray().Select(p => p.Replace(pattern[0], string.Empty)).ToArray();
                }
            }
            catch (Exception e)
            {

            }
            #endregion
            //db.Blogs.FirstOrDefault();
            //db.Blogs.ToList()
            //BolgViewModel vm = new BolgViewModel();
            BolgView2Model vm2 = new BolgView2Model();
            vm2.blogs = db.Blogs.ToList();
            vm2.authors = db.Author.ToList();
            var list = db.Blogs.ToList();
            ViewBag.auth = db.Author.ToList();
            ViewBag.auth2 = db.Author.Select(_ => _.AuthorName).ToList();
            ViewBag.auth3 = db.Author.Select(_ => _.AuthorName).ToArray();

            #region LINQ 和 where  lamda都不允许数据转换 Regex.Replace
            //var tids = db.Blogs.AsEnumerable()
            //   .Select(p => Convert.ToInt32(Regex.Replace(p.Name, "[^0-9]+", string.Empty)))
            //   .ToArray();
            //var oo = Regex.Replace("--01", "[^0-9]+", string.Empty);
            //var oo2 = Regex.Replace("--Bolg01", "[^0-9]+", string.Empty);

            //var query = (from e in tids
            //             where e >= 2 && e <= 4
            //             select new Student()
            //             {

            //                 ID = db.Blogs.Find(e).BlogId,
            //                 Name = db.Blogs.Find(e).Name
            //             }).ToList();

            //var query2 = (from e in db.Blogs  // LINQ 和 where  lamda都不允许数据转换
            //              where Convert.ToInt32(Regex.Replace(e.Name, "[^0-9]+", string.Empty)) >= 2 && Convert.ToInt32(Regex.Replace(e.Name, "[^0-9]+", string.Empty)) <= 4
            //              select new Student()
            //              {
            //                  ID = e.BlogId,
            //                  Name = e.Name
            //              }).ToList();
            #endregion
            #region int to string

            //foreach (var item in list)
            //{
            //    item.BlogId2 = true;
            //}
            //list[2].BlogId2 = false;

            //foreach (var item in list)
            //{
            //    item.strBlogId = item.BlogId2 ? "Video" : "";
            //}

            //var query2 = list.Select(_ => new Blog()
            //{
            //    BlogId = _.BlogId,
            //    strBlogId = _.BlogId == 1 ? "Video" : "",
            //    Name = _.Name
            //});
            #endregion

            return View(list);
        }
        public int Doconvert(string id)
        {
            return Convert.ToInt32(Regex.Replace(id, "[^0-9]+", string.Empty));
        }

        [HttpPost]
        public ActionResult Index(string[] Number)
        {

            string strConn = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
            // string sqlstr = "INSERT INTO Table (Number) VALUES (@Number)";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand(strConn, conn);
            foreach (var item in Number)
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Table (Labels) VALUES (@Labels);";
                command.Parameters.AddWithValue("@Labels", item.ToString());
                conn.ConnectionString = strConn;

                conn.Open();
                SqlDataReader myReader = command.ExecuteReader();
                int n = command.ExecuteNonQuery();
                myReader.Close();
            }
            return View();
        }


        public class StudentGrade
        {
            public int ID { get; set; }
            public int StudentID { get; set; }
            public string Course { get; set; }
            public decimal Grade { get; set; }
        }

        public ActionResult PivotTable()
        {
            var list = new List<StudentGrade>
         {
             new StudentGrade{ID=1,StudentID=1,Course="A",Grade=89},
             new StudentGrade{ID=2,StudentID=2,Course="A",Grade=84},
             new StudentGrade{ID=3,StudentID=3,Course="A",Grade=79},
             new StudentGrade{ID=4,StudentID=4,Course="A",Grade=91},
             new StudentGrade{ID=5,StudentID=2,Course="B",Grade=67},
             new StudentGrade{ID=6,StudentID=1,Course="C",Grade=95}
         };
            DataTable dt = new DataTable();
            dt.Columns.Add(" ");
            var columns = list.Select(x => x.StudentID).Distinct().ToList();// 1 2 3 4
            foreach (var item in columns)
            {
                dt.Columns.Add(item.ToString());
            }
            var courses = list.Select(x => x.Course).Distinct().ToList();//A B C
            foreach (var course in courses)
            {
                List<string> tempList = new List<string>();
                tempList.Add(course.ToString());
                foreach (var column in columns)
                {
                    var grade = list.Where(x => x.StudentID == column && x.Course == course).Select(x => x.Grade).FirstOrDefault();
                    tempList.Add(grade.ToString());
                }
                dt.Rows.Add(tempList.ToArray<string>());
            }
            return View(dt);
        }

        [HttpGet]
        public JsonResult GetPrice(string item, string customer)
        {
            ViewBag.Message = "Your application description page.";
            var aa = Convert.ToInt32(item + customer);
            return Json(new { success = true, msg = "123" }, JsonRequestBehavior.AllowGet);
        }



        public class Labels
        {
            public int LabelId { get; set; }
            public string LabelName { get; set; }
            public List<Label> labinfo { get; set; }
        }

        public ActionResult Tree()
        {
            DataSet ds = new DataSet();
            string connectionString =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Trees";
            // cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            Tree tree = new Tree();
            List<Tree> treelist = new List<Tree>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Tree tre = new Tree();
                tre.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                tre.NodeId = Convert.ToInt32(ds.Tables[0].Rows[i]["NodeId"].ToString());
                tre.Name = ds.Tables[0].Rows[i]["Name"].ToString();

                treelist.Add(tre);
            }
            tree.Treeinfo = treelist;
            con.Close();
            return View(tree);
        }

        public class CategoryViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            //represnts Parent ID and it's nullable  
            public int? Pid { get; set; }
            public virtual CategoryViewModel Parent { get; set; }
            public virtual ICollection<CategoryViewModel> Childs { get; set; }
        }

        private static List<CategoryViewModel> FillRecursive(List<CategoryViewModel> flatObjects, int? parentId = null)
        {
            return flatObjects.Where(x => x.Pid.Equals(parentId)).Select(item => new CategoryViewModel
            {
                Name = item.Name,
                ID = item.ID,
                Description = item.Description,
                Pid = item.Pid,
                Childs = FillRecursive(flatObjects, item.ID)
            }).ToList();
        }

        public ActionResult TreeViewDemo()
        {
            ViewBag.Tree = GetAllCategoriesForTree();
            return View();
        }
        public string GetAllCategoriesForTree()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            string connectionSrtring = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionSrtring))
            {
                string sql = @"select * from Categories";
                using (SqlCommand com = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Pid"].ToString() == "")
                        {
                            categories.Add(new CategoryViewModel
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Pid = null
                            });
                        }
                        else
                        {
                            categories.Add(new CategoryViewModel
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Pid = Convert.ToInt32(reader["Pid"])
                            });
                        }
                    }
                    conn.Close();
                }
            }
            if (categories != null)
            {
                List<CategoryViewModel> headerTree = FillRecursive(categories, null);

                #region treeTable  

                string root_li = string.Empty;
                string down1_names = string.Empty;
                string down2_names = string.Empty;

                foreach (var item in headerTree)
                {
                    root_li += " <tr data-tt-id=" + item.ID + " data-tt-parent-id=" + (item.Pid == null ? 0 : item.Pid) + ">"
                                + " <td>" + item.Name + "</td>"
                                + "</tr>";

                    down1_names = "";
                    foreach (var down1 in item.Childs)
                    {
                        down2_names = "";
                        foreach (var down2 in down1.Childs)
                        {
                            down2_names += " <tr data-tt-id=" + down2.ID + " data-tt-parent-id=" + down2.Pid + ">"
                                + " <td>" + down2.Name + "</td>"
                                + "</tr>";
                        }
                        down1_names += " <tr data-tt-id=" + down1.ID + " data-tt-parent-id=" + down1.Pid + ">"
                                        + " <td>" + down1.Name + "</td>"
                                        + "</tr>"
                                        + down2_names;

                    }
                    root_li += down1_names;
                }

                return "<table id=\"aa\">" + root_li + "</table>";
                #endregion




            }
            return "Record Not Found!!";
        }

        public ActionResult TreeTable()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public class Accounts
        {
            public String Account_Id;
            public String Account_name;
            public String Account_Parent;
        }

        public ActionResult TreeTable3()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Controllet part
        public JsonResult Get_Accounts()
        {
            DataSet ds = new DataSet();
            string connectionString =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student";
            // cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    listreg.Add(new Student
            //    {
            //        Account_name = dr["account_name"].ToString(),
            //        Account_Parent = dr["parent_account_ID"].ToString(),
            //    });
            //}

            var stulist = new List<datalistView>();

            // var re = from a in stulist select a;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stulist.Add(new datalistView
                {
                    datalistView_id = Convert.ToInt32(row["ID"]),
                    datalistView_Name = row["SName"].ToString()
                });
            }
            return Json(stulist, JsonRequestBehavior.AllowGet);
            //string listjsonstr = "[{\"nodeID\": {\"1\": [{\"ID\": \"1.1\",\"childNodeType\": \"branch\",\"childData\": [\"1.1: column 1\"]}],\"1.1\": [{\"ID\": \"1.1.1\",\"childNodeType\": \"leaf\",\"childData\": [\"1.1.1: column 1\"]}],\"2\": [{\"ID\": \"2.1\",\"childNodeType\": \"leaf\",\"childData\": [\"2.1: column 1\"]}]}}]";
            //return Json(new { list = listjsonstr }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TreeTable4()//icon folder for tree table
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult treegrid()//icon folder for tree table
        {

            ViewBag.Message2 = "{\"rows\": [{ \"id\": 1, \"name\": \"All Tasks\", \"begin\": \"3/4/2010\", \"end\": \"3/20/2010\", \"progress\": 60, \"iconCls\": \"icon-ok\" }]}";

            return View();
        }

        public ActionResult TreeGrid2()//jqxTreeGrid
        {

            // ViewBag.Message2 = "{\"rows\": [{ \"id\": 1, \"name\": \"All Tasks\", \"begin\": \"3/4/2010\", \"end\": \"3/20/2010\", \"progress\": 60, \"iconCls\": \"icon-ok\" }]}";

            return View();
        }
        public ActionResult datepicker()
        {
            //var list = db.Blogs.ToList().FirstOrDefault();
            //ViewBag.Message = "Your application description page.";
            Blog bl = new Blog();

            bl.DateDocument = Convert.ToDateTime("2018/12/14");
            return View(bl);
        }

        public ActionResult validate()
        {
            var list = db.Student.ToList();
            ProjectAndStudentModels pvm = new ProjectAndStudentModels();
            pvm.StudentsAndID = db.Student.ToList();
            return View(pvm);
            //var query ={"related_products":[{"product_id":20856},{"product_id":21125},{"product_id":21509},{"product_id":22159},{"product_id":22231},{"product_id":22757},{"product_id":22758}]};
            //var list = db.Products.ToList();
            //Product2 pvm = new Product2();
            //pvm.related_products = db.Products.Select(_=>_.product_id).ToArray();
            //return View(pvm);
        }

        [HttpPost]
        public JsonResult IsStudentExists(int? Id)//https://www.c-sharpcorner.com/article/remote-validation-in-mvc-5-to-check-if-username-and-email-id-exists/
        {
            //https://forums.asp.net/p/2147748/6233086.aspx?p=True&t=636746440919715939
            var list = db.Student.ToList();

            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method. 
            return Json((!list.Any(x => x.Id == Id) == false ? "false" : "true"), JsonRequestBehavior.AllowGet);
        }


        public ActionResult validate2()//此例需要提交后验证 直接验证参考：https://forums.asp.net/p/2147782/6233257.aspx?p=True&t=636747254515733755
        {
            var list = db.Label.ToList().FirstOrDefault();
            List<string> IDs = db.Label.Select(x => x.LabelName.ToString()).ToList();
            // ProjectAndStudentModels pvm = new ProjectAndStudentModels();
            // pvm.StudentsAndID = db.Student.ToList();
            //Label list2 = db.Label.ToList().FirstOrDefault();
            #region ListBoxFor 多选 model binding 
            var model = new Label();
            model.ListaProdotti = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Apple1", Value = "1"},
                    new SelectListItem {Text = "Pear1", Value = "2"},
                    new SelectListItem {Text = "Banana1", Value = "3"},
                    new SelectListItem {Text = "Orange1", Value = "4"},
                };
            #endregion
            return View(model);//list
        }

        public ActionResult TestAction()
        {
            //var stu = new Student();
            //stu.ID = 5;
            //stu.Name = "Vstu5";
            var list = db.Label.ToList();
            return View(list);
        }


        [HttpGet]
        public JsonResult GetData()
        {
            var list = db.Label.ToList();
            if (list == null)
            {
                return Json(new { success = false, showlist = list, msg = "operation failed" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, showlist = list, msg = "Successful operation" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetData2(int id)
        {
            var list = db.Cities.Where(_ => _.CountryId == id).ToList();
            //if (list == null)
            //{
            return Json(new { showlist = list }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(new { success = true, showlist = list, msg = "Successful operation" }, JsonRequestBehavior.AllowGet);
            //}

        }

        public class datalistView
        {
            public int datalistView_id { get; set; }
            public string datalistView_Name { get; set; }
        }
        public ActionResult datalist()
        {
            return View();
        }

        public ActionResult Data(string term)
        {
            DataSet ds = new DataSet();
            string connectionString =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Student";
            // cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            var stulist = new List<datalistView>();

            // var re = from a in stulist select a;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                stulist.Add(new datalistView
                {
                    datalistView_id = Convert.ToInt32(row["ID"]),
                    datalistView_Name = row["SName"].ToString()
                });
            }
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    stulist.Add(new datalistView
            //    {
            //        datalistView_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
            //        datalistView_Name = ds.Tables[0].Rows[i]["SName"].ToString()
            //    });
            //}
            //convert the required data to jsontype

            // var list233 = "{\"rows\": [{ \"id\": 1, \"name\": \"All Tasks\", \"begin\": \"3/4/2010\", \"end\": \"3/20/2010\", \"progress\": 60, \"iconCls\": \"icon-ok\" }]}";
            return Json(stulist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult datalist2()//select datalist
        {

            //Label todo = db.Label.Find(1);
            //List<SelectListItem> osrListItems1 = db.Label.Where(w => w.LabelId == 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = true }).Distinct().ToList();
            //List<SelectListItem> osrListItems2 = db.Label.Where(w => w.LabelId != 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = false }).Distinct().ToList();
            //List<SelectListItem> osrListItems = new List<SelectListItem>();
            //osrListItems.AddRange(osrListItems1);
            //osrListItems.AddRange(osrListItems2);
            //osrListItems = osrListItems.OrderBy(x => x.Value).ToList();

            List<SelectListItem> osrListItems3 = db.Label.Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = true }).ToList();
            ViewBag.OSRddl = new SelectList(osrListItems3, "Value", "Text");
            return View();
        }

        public ActionResult Get_priceinfo()//https://forums.asp.net/t/2132972.aspx( AUTOCOMPLETE )
        {
            return View();
        }

        public ActionResult AutoSuggests()//https://forums.asp.net/t/2142048.aspx( AUTOCOMPLETE )
        {
            return View();
        }

        public class Get_priceViewModel
        {
            public int id { get; set; }
            public string item_name { get; set; }
            public string price { get; set; }

            public string discount { get; set; }

        }

        [HttpPost]
        public ActionResult Get_price()
        {


            DataSet ds = new DataSet();
            string connectionString =
           @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Get_price";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //return ds;
            var list = new List<Get_priceViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Get_priceViewModel
                {
                    id = Convert.ToInt32(row["ID"]),
                    item_name = row["item_name"].ToString(),
                    price = row["price"].ToString(),
                    discount = row["discount"].ToString()
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_priceByname(string item_name)
        {


            DataSet ds = new DataSet();
            string connectionString =
           @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Get_price where item_name=@item_name";
            cmd.Parameters.AddWithValue("@item_name", item_name);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var list = new List<Get_priceViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Get_priceViewModel
                {
                    id = Convert.ToInt32(row["ID"]),
                    item_name = row["item_name"].ToString(),
                    price = row["price"].ToString(),
                    discount = row["discount"].ToString()
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }



        public ActionResult TinaGetPrice()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetIndex2(string firstinput)
        {
            //here , you could get the parameter ：firstinput
            return Json(new { price = 1, discount = 2 }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult treetable2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult echojson()
        {
            string listjsonstr = "[{\"nodeID\": {\"1\": [{\"ID\": \"1.1\",\"childNodeType\": \"branch\",\"childData\": [\"1.1: column 1\"]}],\"1.1\": [{\"ID\": \"1.1.1\",\"childNodeType\": \"leaf\",\"childData\": [\"1.1.1: column 1\"]}],\"2\": [{\"ID\": \"2.1\",\"childNodeType\": \"leaf\",\"childData\": [\"2.1: column 1\"]}]}}]";
            return Json(new { list = listjsonstr }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult slider()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult checkbox()
        {
            Label2 labvm = new Label2();
            labvm.LabelId = 1;
            labvm.LabelName = "XX1";
            labvm.labinfo = db.Label.ToList();
            // var list = db.Label.ToList();

            ViewBag.OSRddl = new SelectList(db.Label.ToList(), "LabelId", "LabelName").Distinct();

            return View(labvm);

        }

        public ActionResult Modalpopup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class OpsViewModel
        {
            public IList<SelectListItem> Carrier { get; set; }
            public int[] SelectedCarrierId { get; set; }
        }

        public ActionResult Modalpopup2()
        {
            var model = new OpsViewModel();
            model.Carrier = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Apple1", Value = "Apple"},
                    new SelectListItem {Text = "Pear1", Value = "Pear"},
                    new SelectListItem {Text = "Banana1", Value = "Banana"},
                    new SelectListItem {Text = "Orange1", Value = "Orange"},
                };

            ViewBag.Message = "Your contact page.";

            return View(model);
        }
        public ActionResult jsonfile()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Dynamic form fields not submitted

        public class JiontableViewModel
        {
            public int Id { get; set; }
            public String Sname { get; set; }

            public String Pname { get; set; }

        }

        public ActionResult Foreach()
        {

            JiontableViewModel jtvm = new JiontableViewModel();
            Label2 labvm = new Label2();
            labvm.LabelId = 1;
            labvm.LabelName = "XX1";
            labvm.labinfo = db.Label.ToList();
            var p = db.Project.ToList();
            var l = db.Label.ToList();
            var SesseionItem3 = (from y in db.Label.ToList()
                                 join si in db.Project.ToList() on y.LabelId equals si.Id
                                 select new JiontableViewModel()
                                 {
                                     Id = y.LabelId,
                                     Sname = y.LabelName,
                                     Pname = "11"
                                 }).ToList();

            var SesseionItem2 = (from y in db.Label.ToList()

                                 select new JiontableViewModel()
                                 {
                                     Id = y.LabelId,
                                     Sname = y.LabelName,
                                     Pname = "11"
                                 }).ToList();

            var data4 = db.Label.Select(m => new
            {
                Session = m.LabelId,
                SesseionItem = from y in db.Label
                               join si in db.Project on y.LabelId equals si.Id
                               where si.Id == m.LabelId
                               select new
                               {
                                   si.Id,
                                   y.LabelName,
                                   si.PName
                               }

            });

            //var list = (from y in data4
            //            select new JiontableViewModel()

            //            {

            //                Id = y.,

            //                Key2 = y.value2

            //            }).ToList();

            return Json(new { list = data4 }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult datatables()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public JsonResult datatableajax(string array)
        {
            //JSON转实体类模型对象
            JavaScriptSerializer js = new JavaScriptSerializer();
            ViewBag.json = js.Deserialize<List<Column>>(array);

            //object parsedJson = JsonConvert.DeserializeObject(str);
            //return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();

            return Json(stream, JsonRequestBehavior.AllowGet);
        }

        public ActionResult datatable2()//calendar //https://stackoverflow.com/questions/41420839/datatables-date-range-filter //jquery datepicker filter datetable.net date range //filter range between date in datetable
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit(/*int? id, string owner*/)
        {

            var cvgetid = db.Label.SingleOrDefault(p => p.LabelId == 2);
            Label todo = db.Label.Find(cvgetid.LabelId);
            Label qq = db.Label.Where(p => p.LabelId == 2).SingleOrDefault();
            if (todo == null)
            {
                return HttpNotFound();
            }

            var options = new List<Label>();
            options.Add(new Label() { LabelId = 11, LabelName = "New Request" });
            options.Add(new Label() { LabelId = 12, LabelName = "Reviewed" });
            options.Add(new Label() { LabelId = 13, LabelName = "Started" });
            options.Add(new Label() { LabelId = 14, LabelName = "In Progress" });
            options.Add(new Label() { LabelId = 15, LabelName = "Completed" });
            ViewBag.Status = options;
            //List<SelectListItem> osrListItems = db.Label.Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName }).ToList();
            List<SelectListItem> osrListItems1 = db.Label.Where(w => w.LabelId == 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = true }).Distinct().ToList();
            List<SelectListItem> osrListItems2 = db.Label.Where(w => w.LabelId != 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = false }).Distinct().ToList();
            List<SelectListItem> osrListItems = new List<SelectListItem>();
            osrListItems.AddRange(osrListItems1);
            osrListItems.AddRange(osrListItems2);
            osrListItems = osrListItems.OrderBy(x => x.Value).ToList();

            ViewBag.OSRddl = new SelectList(osrListItems, "Value", "Text", osrListItems1[0].Value).Distinct();

            return View(todo);


        }

        // POST: Todoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,CreatedDate,Task,Status,FollowUp,Group,Owner")] string OSRddl, Label todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);

        }

        public ActionResult CostCodeReport()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult RunCostCodeReport(string StartDate, string EndDate)
        {
            //do sth ....
            return View();
        }


        public ActionResult hover()//CSS position
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult search()
        {

            string myKeywords = "mvc,code,development";
            var myKeywords2 = myKeywords.Split(',');
            var relatedQuestions = new List<Search>();
            foreach (var i in myKeywords2)
            {
                relatedQuestions.AddRange(db.Search.Where(m => m.Keyword.Contains(i)).ToList());
            }
            ViewBag.search = relatedQuestions.Distinct().ToList();
            return View();
        }

        public ActionResult Get_priceinfo2()//sum
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Get_price2()
        {


            DataSet ds = new DataSet();
            string connectionString =
           @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Get_price";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //return ds;
            var list = new List<Get_priceViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Get_priceViewModel
                {
                    id = Convert.ToInt32(row["ID"]),
                    item_name = row["item_name"].ToString(),
                    price = row["price"].ToString(),
                    discount = row["discount"].ToString()
                });
            }
            //If you have more requirements for this collection,such as orderby.. you can list.OrderByDescending(_=>_.id)
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_priceByname2(string item_name)
        {


            DataSet ds = new DataSet();
            string connectionString =
           @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Get_price where item_name=@item_name";
            cmd.Parameters.AddWithValue("@item_name", item_name);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var list = new List<Get_priceViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Get_priceViewModel
                {
                    id = Convert.ToInt32(row["ID"]),
                    item_name = row["item_name"].ToString(),
                    price = row["price"].ToString(),
                    discount = row["discount"].ToString()
                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #region PDF


        public virtual ActionResult PdfTest()
        {

            //var path = @"D://";
            //var file = Path.Combine(path, "test.pdf");
            //file = Path.GetFullPath(file);
            ////if (!file.StartsWith(path))
            ////{
            ////    // someone tried to be smart and sent 
            ////    // ?filename=..\..\creditcard.pdf as parameter
            ////    throw new HttpException(403, "Forbidden");
            ////}
            //return File(file, "application/pdf");
            return View();

        }

        public virtual ActionResult Pdf()
        {


            //第一种方法
            //   //var path = @"http://localhost:50638/api/GetFile/2";
            //  var path = @"D://";
            //  var file = Path.Combine(path, "test.pdf");  
            ////  var url = @Url.Content("http://localhost:50638/api/GetFile/2");
            //  file = Path.GetFullPath(file);
            //  //if (!file.StartsWith(path))
            //  //{
            //  //    // someone tried to be smart and sent 
            //  //    // ?filename=..\..\creditcard.pdf as parameter
            //  //    throw new HttpException(403, "Forbidden");
            //  //}
            //  return File(file, "application/pdf");

            //第二种方法
            var fileStream = new FileStream("D://" + "test.pdf",
                                     FileMode.Open,
                                     FileAccess.Read
                                   );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;

        }

        public FileResult GetDocument()
        {
           // System.Diagnostics.Debug.WriteLine("111");

            Debugger.Log(1,"11","Home DisplayPDF() invoked");
            string zFileu = Server.MapPath(@"~/images/") + "test.pdf";
            return File(zFileu, "application/pdf");

            ////byte[] doc = Pdf();
            //var path = @"D://";
            //var file = Path.Combine(path, "test.pdf");
            //file = Path.GetFullPath(file);
            //string mimeType = "application/pdf";
            //Response.AppendHeader("Content-Disposition", "inline; filename=" + "test.pdf");
            //return File(file, mimeType);
        }

        public virtual ActionResult pdf2()
        {
            var path = @"D://";
            var file = Path.Combine(path, "test.pdf");
            file = Path.GetFullPath(file);
            //if (!file.StartsWith(path))
            //{
            //    // someone tried to be smart and sent 
            //    // ?filename=..\..\creditcard.pdf as parameter
            //    throw new HttpException(403, "Forbidden");
            //}
            return File(file, "application/pdf");


        }
        #endregion


        public ActionResult HeightExpander()//sum
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FloatWindow()//Send Values to Floating Window and Get back Info in MVC
        {
            return View();
        }

        #region 存储过程
        public class FoodViewModel
        {
            public int FoodID { get; set; }
            public int OrgID { get; set; }
            public int CategoryID { get; set; }
            public string FoodItem { get; set; }

        }
        public ActionResult storeProcedure()//调用存储过程  //https://forums.asp.net/t/2132556.aspx
        {
            DataSet ds = new DataSet();
            string connectionstring = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            string sql = "kd_selFoodItemsSearch";
            //string sql = "EXEC kd_selFoodItemsSearch @OrgID,@SearchText";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@OrgID", 2);
            command.Parameters.AddWithValue("@SearchText", "p");
            command.CommandType = CommandType.StoredProcedure;
            //command.CommandType = CommandType.Text;

            command.Connection = connection;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            //  DataTable dt = new DataTable();
            sda.Fill(ds);


            var list = new List<FoodViewModel>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new FoodViewModel
                {
                    FoodID = Convert.ToInt32(row["FoodID"]),

                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    FoodItem = row["FoodItem"].ToString()
                });
            }


            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult storeProcedure2()//调用存储过程
        {

            string sql = "kd_selFoodItemsSearch";
            ////string sql = "EXEC kd_selFoodItemsSearch @OrgID,@SearchText";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@OrgID", 2);
            command.Parameters.AddWithValue("@SearchText", "p");
            // command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.Text;

            var list = ExecuteStoredProc(command, "TotalCount");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult storeProcedure3()//调用存储过程
        {

            string sql = "kd_selFoodItem";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@OrgID", 2);
            SqlParameter parOutput = command.Parameters.Add("@fid", SqlDbType.Int);  //定义输出参数  
            SqlParameter parOutput2 = command.Parameters.Add("@cid", SqlDbType.Int);  //定义输出参数  
            SqlParameter parOutput3 = command.Parameters.Add("@fit", SqlDbType.NVarChar, 50);  //定义输出参数  
            parOutput.Direction = ParameterDirection.Output;  //参数类型为Output  
            parOutput2.Direction = ParameterDirection.Output;  //参数类型为Output  
            parOutput3.Direction = ParameterDirection.Output;  //参数类型为Output  

            command.CommandType = CommandType.StoredProcedure;


            var list = ExecuteStoredProc(command, "TotalCount");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        protected IEnumerable<FoodViewModel> ExecuteStoredProc(SqlCommand command, string CountColName = "TotalCount")
        {
            DataSet ds = new DataSet();
            var reader = (SqlDataReader)null;
            var list = new List<FoodViewModel>();
            string connectionstring = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
            SqlConnection _connection = new SqlConnection(connectionstring);

            try
            {
                command.Connection = _connection;
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FoodViewModel e = new FoodViewModel
                    {
                        FoodID = (int)reader["FoodID"],
                        CategoryID = (int)reader["CategoryID"],
                        FoodItem = reader["FoodItem"].ToString()
                    };
                    list.Add(e);

                }

                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //GetDataCount(Convert.ToInt32(reader[CountColName].ToString()));
                    }
                }

            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
                _connection.Close();
                _connection.Dispose();
            }
            return list;
        }

        #endregion

        #region Export Excel Create/ADD DELETE DOCUMENT


        public ActionResult Index_Export()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ExportExcel()//add
        {
            var filename = "test.xls";
            string fullPath = Path.Combine(Server.MapPath("~/Content"), filename);
            using (FileStream fs = System.IO.File.Create(fullPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            return Json(new { fileName = filename });
        }
        [HttpGet]
        [DeleteFile]
        public ActionResult Download(string file) // delete
        {
            //get the temp folder and file path in server
            string fullPath = Path.Combine(Server.MapPath("~/Content"), file);

            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"
            return File(fullPath, "application/vnd.ms-excel", file);
        }

        public ActionResult DownloadFile(int id)// Download
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "test.xlsx");
            string fileName = "test.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        #region importEcportTools
        //public class ImportExportTool
        //{
        //    private static ICollection<Label> _students;
        //    public static ICollection<Label> Students
        //    {
        //        get
        //        {
        //            return _students;
        //        }
        //        set
        //        {
        //            _students = value;
        //        }
        //    }

        //    public static ICollection<Label> GetStudents()
        //    {
        //        ICollection<Label> students = new List<Label>();

        //        Random r = new Random();
        //        students.Add(new Label { LabelId = 1, LabelName = "A"});
        //        students.Add(new Label { LabelId = 2, LabelName = "B" });
        //        students.Add(new Label { LabelId = 3, LabelName = "C" });

        //        //students.Add(new Label { Name = "E", Age = 17, EnglishScore = r.Next(60, 100), MathScore = r.Next(60, 100), Gender = Gender.Male });

        //        _students = students;

        //        return students;
        //    }

        //    public static ICollection<Label> Import(Stream stream)
        //    {
        //        ICollection<Label> students = new List<Label>();

        //        #region read excel
        //        using (stream)
        //        {
        //            ExcelPackage package = new ExcelPackage(stream);

        //            ExcelWorksheet sheet = package.Workbook.Worksheets[1];

        //            #region check excel format
        //            if (sheet == null)
        //            {
        //                return students;
        //            }
        //            if (!sheet.Cells[1, 1].Value.Equals("Name") ||
        //                 !sheet.Cells[1, 2].Value.Equals("Age") ||
        //                 !sheet.Cells[1, 3].Value.Equals("Gender") ||
        //                 !sheet.Cells[1, 4].Value.Equals("English Score") ||
        //                 !sheet.Cells[1, 5].Value.Equals("Math Score"))
        //            {
        //                return students;
        //            }
        //            #endregion

        //            #region get last row index
        //            int lastRow = sheet.Dimension.End.Row;
        //            while (sheet.Cells[lastRow, 1].Value == null)
        //            {
        //                lastRow--;
        //            }
        //            #endregion

        //            #region read datas
        //            for (int i = 2; i <= lastRow; i++)
        //            {
        //                students.Add(new Student
        //                {
        //                    Name = sheet.Cells[i, 1].Value.ToString(),
        //                    Age = int.Parse(sheet.Cells[i, 2].Value.ToString()),
        //                    Gender = (Gender)Enum.Parse(typeof(Gender), sheet.Cells[i, 3].Value.ToString()),
        //                    EnglishScore = int.Parse(sheet.Cells[i, 4].Value.ToString()),
        //                    MathScore = int.Parse(sheet.Cells[i, 5].Value.ToString())

        //                });
        //            }
        //            #endregion

        //        }
        //        #endregion

        //        return students;
        //    }

        //    public static MemoryStream Export(ICollection<Student> students)
        //    {
        //        MemoryStream stream = new MemoryStream();
        //        ExcelPackage package = new ExcelPackage(stream);

        //        package.Workbook.Worksheets.Add("Students");
        //        ExcelWorksheet sheet = package.Workbook.Worksheets[1];

        //        #region write header
        //        sheet.Cells[1, 1].Value = "Name";
        //        sheet.Cells[1, 2].Value = "Age";
        //        sheet.Cells[1, 3].Value = "Gender";
        //        sheet.Cells[1, 4].Value = "English Score";
        //        sheet.Cells[1, 5].Value = "Math Score";
        //        sheet.Cells[1, 6].Value = "Average Score";

        //        using (ExcelRange range = sheet.Cells[1, 1, 1, 6])
        //        {
        //            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //            range.Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //            range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
        //            range.Style.Border.Bottom.Color.SetColor(Color.Black);
        //            range.AutoFitColumns(4);
        //        }
        //        #endregion

        //        #region write content
        //        int pos = 2;
        //        foreach (Student s in students)
        //        {
        //            sheet.Cells[pos, 1].Value = s.Name;
        //            sheet.Cells[pos, 2].Value = s.Age;
        //            sheet.Cells[pos, 3].Value = s.Gender;
        //            sheet.Cells[pos, 4].Value = s.EnglishScore;
        //            sheet.Cells[pos, 5].Value = s.MathScore;
        //            sheet.Cells[pos, 6].FormulaR1C1 = "AVERAGE(RC[-1], RC[-2])";

        //            if (s.MathScore > 90 && s.EnglishScore > 90)
        //            {
        //                using (ExcelRange range = sheet.Cells[pos, 1, pos, 6])
        //                {
        //                    range.Style.Font.Color.SetColor(Color.Blue);
        //                }
        //            }
        //            else if (s.MathScore < 80 && s.EnglishScore < 80)
        //            {
        //                using (ExcelRange range = sheet.Cells[pos, 1, pos, 6])
        //                {
        //                    range.Style.Font.Color.SetColor(Color.Red);
        //                }
        //            }

        //            using (ExcelRange range = sheet.Cells[pos, 1, pos, 6])
        //            {
        //                range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        //                range.Style.Border.Bottom.Color.SetColor(Color.Black);
        //                range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
        //            }

        //            pos++;
        //        }
        //        #endregion

        //        package.Save();

        //        return stream;
        //    }
        //}

        //public ActionResult Refresh()
        //{
        //    //ViewBag.students = ImportExportTool.GetStudents();

        //    return View("ImportExport");
        //}

        //public ActionResult Import(HttpPostedFileBase file)
        //{
        //    if (file == null)
        //    {
        //        ViewBag.Message = "Please select a file!";
        //    }
        //    else
        //    {
        //        ICollection<Student> students = ImportExportTool.Import(file.InputStream);
        //        ImportExportTool.Students = students;
        //    }

        //    ViewBag.students = ImportExportTool.Students;
        //    return View("ImportExport");
        //}

        //public FileResult Export()
        //{
        //    MemoryStream stream = ImportExportTool.Export(ImportExportTool.Students);

        //    return File(stream.ToArray(),
        //        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //        "EPPlusDemo.xlsx");
        //}

        #endregion
        #endregion

        #region zhyan.ise
        public ActionResult showmodal()//show modal by clicking on button inside td
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult image()//image inside td   关键： @Url.Content:正确加载图片
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult convert()//convert number to words jquery
        {
            #region Hashtable .Values.Cast<Label>
            //Hashtable h1 = new Hashtable();
            //Label p1 = new Label();
            //p1.LabelId = 1;
            //p1.LabelName = "Ram";

            //Label p2 = new Label();
            //p2.LabelId = 2;
            //p2.LabelName = "LAXMAN";

            //Label p3 = new Label();
            //p3.LabelId = 4;
            //p3.LabelName = "Kris";

            //h1.Add(1, p1);
            //h1.Add(2, p2);
            //h1.Add(3, p3);

            //var item = h1.Values.Cast<Label>().Where(x => x.LabelId > 3).ToList();
            #endregion

            return View();
        }

        public ActionResult AutoWidth()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult pagination()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #region https://forums.asp.net/t/2141538.aspx
        public class customer_pro
        {
            public string customer_name { get; set; }
            public string customer_group_name { get; set; }
            public string territory_name { get; set; }
            public string status { get; set; }
        }
        public ActionResult SearchDynamic()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Show_Customer()
        {
            //DataSet ds = dblayer.Show_Customer();
            //List<customer_pro> listreg = new List<customer_pro>();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{

            //    listreg.Add(new customer_pro
            //    {

            //        customer_name = dr["customer_name"].ToString(),
            //        customer_group_name = dr["customer_group_name"].ToString(),
            //        territory_name = dr["territory_name"].ToString(),
            //        status = dr["status"].ToString(),
            //        // series = dr["series"].ToString(),


            //    });
            //}

            var listreg = new List<customer_pro>();

            listreg.Add(new customer_pro() { customer_name = "aaa", customer_group_name = "aacustomer", territory_name = "aaterritory", status = "Yes" });

            listreg.Add(new customer_pro() { customer_name = "bbb", customer_group_name = "bbcustomer", territory_name = "bbterritory", status = "NO" });

            listreg.Add(new customer_pro() { customer_name = "ccc", customer_group_name = "cccustomer", territory_name = "ccterritory", status = "Yes" });
            return Json(listreg, JsonRequestBehavior.AllowGet);

        }
        #endregion

        public ActionResult ifnull() //https://forums.asp.net/t/2141735.aspx
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TextEdit(int? id) //https://forums.asp.net/t/2141735.aspx
        {

            Column model;
            if (id == null)
            {
                model = new Column();
            }
            else
            {
                model = db.Column.Find(id);
            }



            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveTextEdit(String Column5)
        {
            var model = new Column();
            model.Column5 = Column5;

            db.Column.Add(model);
            db.SaveChanges();
            // return RedirectToAction("Index");


            //return View("TextEdit");

            return Json(new { Success = 2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Table_Index()//show modal by clicking on button inside td
        {
            var list = db.Author.ToList();

            return View(list);
        }


        public ActionResult edit_journal_entry(int id, string authName)
        {
            // var list = db.Author.ToList();

            return View();
        }

        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult edit_journal_entry(List<Author> model)
        //{
        //    // var list = db.Author.ToList();

        //    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //}
        #endregion


        public ActionResult Webgrid()//https://forums.asp.net/t/2132883.aspx
        {
            ViewBag.Message = "Your contact page.";
            var list = db.Label.ToList();
            return View(list);
        }

        public class ListStrViewModel
        {
            public int Id { get; set; }
            public string field1 { get; set; }
            public string field2 { get; set; }

            public string field3 { get; set; }
            //public List<SelectListItem> dropdownlist { get; set; }

        }

        public ActionResult Webgrid2(/*int page = 1*/)//https://forums.asp.net/t/2132883.aspx
        {

            ViewBag.Message = "Your contact page.";
            //var list = db.Label.ToList();

            var selectlist = new List<SelectListItem>// https://forums.asp.net/t/2081566.aspx?How+to+show+dropdown+with+selected+value+in+webgrid      
            {
                  //https://stackoverflow.com/questions/12846572/dropdownlist-in-webgrid-mvc4
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
            ViewBag.selectlist = selectlist;

            List<ListStrViewModel> list2 = new List<ListStrViewModel>();
            list2.Add(new ListStrViewModel() { Id = 1, field1 = "aa1", field2 = "aa", field3 = "aa" });
            list2.Add(new ListStrViewModel() { Id = 2, field1 = "bb2", field2 = "bb", field3 = "bb" });
            list2.Add(new ListStrViewModel() { Id = 3, field1 = "cc3", field2 = "cc", field3 = "cc" });

            list2.Add(new ListStrViewModel() { Id = 4, field1 = "aa4", field2 = "aa", field3 = "aa" });
            list2.Add(new ListStrViewModel() { Id = 5, field1 = "bb5", field2 = "bb", field3 = "bb" });
            list2.Add(new ListStrViewModel() { Id = 6, field1 = "cc6", field2 = "cc", field3 = "cc" });



            List<String[]> addresses = new List<String[]>();
            String[] addressesArr = new String[3];
            addressesArr[0] = "zero";
            addressesArr[1] = "one";
            addressesArr[2] = "two";

            addresses.Add(addressesArr);
            addresses.Add(addressesArr);
            addresses.Add(addressesArr);

            //List<String> addresses = new List<String>();

            //addresses.Add("aa");
            //addresses.Add("bb");

            //addresses.Add("cc");

            #region 无效 在这个例子中
            // int skip = page != 0 ? (page - 1) : 0;

            //list2 = list2.OrderBy(_ => _.Id).Skip(skip * 1).Take(1).ToList();
            #endregion

            ViewBag.list = list2;
            ViewBag.addresses = addresses.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Webgrid2(string searchString)
        {

            List<ListStrViewModel> list2;
            if (!string.IsNullOrEmpty(searchString))
            {

                var list = db.Label.ToList();

                var selectlist = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
                ViewBag.selectlist = selectlist;

                list2 = new List<ListStrViewModel>();
                list2.Add(new ListStrViewModel() { field1 = "aa", field2 = "aa", field3 = "aa" });




            }
            else
            {
                var selectlist = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
                ViewBag.selectlist = selectlist;

                list2 = new List<ListStrViewModel>();
                list2.Add(new ListStrViewModel() { field1 = "aa", field2 = "aa", field3 = "aa" });
                list2.Add(new ListStrViewModel() { field1 = "bb", field2 = "bb", field3 = "bb" });
                list2.Add(new ListStrViewModel() { field1 = "cc", field2 = "cc", field3 = "cc" });

            }
            ViewBag.list = list2;
            return View(list2);

            // return Json(11, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Webgrid3()
        {
            ViewBag.Message = "Your contact page.";
            var list = db.Label.ToList();
            return View(list);
        }
        #region webgrid webapi
       

        [HttpGet]
        public ActionResult webgrid4(string ResourceID="")
        {
            try
            {
                ViewBag.ResourceList = ToSelectList();
                ViewBag.Title = "Order Recognition";
              
                    ResourceController api = new ResourceController();
                    return View(api.GetResources(ResourceID));//error:The type 'ApiController' is defined in an assembly that is not referenced. You must add a reference to assembly 'System.Web.Http, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.
                                                              //solution:Install-Package Microsoft.AspNet.WebApi.Core -version 5.2.3,it will be OK.
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        public SelectList ToSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem { Text = "Allex", Value = "A" });
            list.Add(new SelectListItem { Text = "Blake", Value = "B" });
            list.Add(new SelectListItem { Text = "Chris", Value = "C" });
            list.Add(new SelectListItem { Text = "Dan", Value = "D" });
            return new SelectList(list, "Value", "Text");
        }
        #endregion

        private static string GetSearchConditionValue(IDictionary<string, string> searchConditions, string key)
        {
            string tempValue = string.Empty;

            if (searchConditions != null && searchConditions.Keys.Contains("Conditions1"))
            {
                searchConditions.TryGetValue(key, out tempValue);
            }
            return tempValue;
        }

        public ActionResult localStorage()
        {
            ViewBag.Message = "Your contact page.";
            var list = db.Label.ToList();
            return View(list);
        }

        public JsonResult OpenOrders(string EmailID)
        {
            var db = new BlogContext();

            //string EmailID = Session["Email"].ToString();  Request.Form["Email"]

            string EmailID2 = Request["Email"];
            //var SalesOrdre = (from cbr in db.cbr
            //                  join c in db.c on cbr.c_No_ equals c.Company_No_

            //                  join sa in db.sh on cbr.No_ equals sa.SCN
            //                  join px in db.PX2 on c.E_Mail equals px.Email_ID

            //                  where c.E_Mail == EmailID
            //                  &&




            //                  select new Open
            //                  {
            //                      SendDate = sa.SenDate,
            //                      CreatedDate = sa.Order_Date,

            //                  }).OrderByDescending(t => t.CreatedDate).ToList();

            List<string> list = new List<string>();
            list.Add("wwww");
            list.Add("wwww2");

            return Json(list, JsonRequestBehavior.AllowGet);

        }


        public ActionResult AddDeleteRow()
        {


            var options = new List<Label>();

            options.Add(new Label() { LabelId = 11, LabelName = "lab1" });

            options.Add(new Label() { LabelId = 12, LabelName = "lab2" });

            options.Add(new Label() { LabelId = 13, LabelName = "lab3" });

            return View(options);

        }

        #region ModelState.Clear()
        public ActionResult ApplyLeave()
        {
            DateTime today = DateTime.Today;

            le_leaveApplication le_leaveApplication = new le_leaveApplication();
            le_leaveApplication.EmployeeId = 1;
            le_leaveApplication.LeaveFrom = today;
            le_leaveApplication.LeaveTo = today;

            return View(le_leaveApplication);
        }

        // POST: eClaim/le_leaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ApplyLeavePreview(le_leaveApplication le_leaveApplication)
        {
            if (ModelState.IsValid)
            {
                le_leaveApplication.LeaveDurationDays = (int)(le_leaveApplication.LeaveTo - le_leaveApplication.LeaveFrom).TotalDays + 1;

                // minus weekend and public holidays.
                //ViewBag.list = le_leaveApplication as le_leaveApplication;
                //return View("ApplyLeavePreview", le_leaveApplication);

                return View(le_leaveApplication);

            }


            return RedirectToAction("ApplyLeave");
        }

        //public ActionResult ApplyLeavePreview()
        //{

        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyLeavePreview2([Bind(Include = "Id,EmployeeId,LeaveType,LeaveFrom,LeaveTo,LeaveDurationDays")] le_leaveApplication le_leaveApplication)
        {
            if (ModelState.IsValid)
            {
                // insert a record into leave application table with status 'pending approval' and leave application date = system date.
                le_leaveApplication.DateApplied = DateTime.Today;
                le_leaveApplication.ApplicationStatus = "Pending Approval";

                db.le_leaveApplications.Add(le_leaveApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(le_leaveApplication);
        }
        #endregion
        #region Ajax.BeginForm Html.BeginForm SelectListItem in model
        public class ListViewModel
        {
            public int SelectedValue { get; set; }
            public List<SelectListItem> Fields { get; set; }
        }
        public ViewResult BeginFormList(string category, string price, string SelectedValue, int page = 1)
        {

            ListViewModel model = new ListViewModel
            {

                Fields = new List<SelectListItem>

                {

                   new SelectListItem { Text = "Order By Descending", Value = "OrderByDescending" },

                   new SelectListItem { Text = "Pune", Value = "2" },

                   new SelectListItem { Text = "Mumbai", Value = "3" },

                   new SelectListItem { Text = "Delhi", Value = "4" }

                }

            };

            return View(model);
        }
        #endregion

        public ActionResult MultipleSelect()
        {

            var options = new List<TEnum>();
            var date = Convert.ToDateTime("2018-01-01");

            //options.Add(new TEnum() { EnumId = 0, EnumType = (WebApplication1.Models.EnumType.Male), EnumName="ab1", Dateofbirth=DateTime.Now });
            options.Add(new TEnum() { EnumId = 0, EnumType = (WebApplication1.Models.EnumType.Male), EnumName = "ab1", Dateofbirth = Convert.ToDateTime("2018-01-01") });

            options.Add(new TEnum() { EnumId = 1, EnumType = (WebApplication1.Models.EnumType.Female), EnumName = "ab2", Dateofbirth = Convert.ToDateTime("2017-06-01") });

            options.Add(new TEnum() { EnumId = 2, EnumType = (WebApplication1.Models.EnumType.Male), EnumName = "ab3", Dateofbirth = Convert.ToDateTime("2018-06-02") });

            var enumlist = options[1];


            //var list = new List<SelectListItem>
            //{
            //    new SelectListItem{Text="Apple",Value="1"},
            //    new SelectListItem{Text="Banana",Value="2"},
            //    new SelectListItem{Text="Orange",Value="3"}
            //};
            //ViewBag.fruit = list;
            #region dateadd Month
            //linq to sql
            //            dateadd(dd, -1, GetDate())：
            //https://forums.asp.net/t/2142596.aspx
            //https://zhidao.baidu.com/question/1305169345966664379.html
            //https://www.cnblogs.com/lowkey666/archive/2012/11/23/2784457.html

            //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //DateTime dt_today = DateTime.Now.AddDays(-1);
            //var query = options.Where(p => p.Dateofbirth.Month == dt_today.Month && p.Dateofbirth.Year == dt_today.Year && p.EnumId == 2).ToList();

            //var query2 = options.Where(p => p.Dateofbirth.Month == DateTime.Now.AddDays(-1).Month && p.Dateofbirth.Year == DateTime.Now.AddDays(-1).Year && p.EnumId == 2).ToList();


            #endregion
            return View(enumlist);
        }
        [HttpPost]
        public ActionResult MultipleSelect(List<string> fruit, List<string> fruitListbox, TEnum tEnum, string Dateofbirth)
        {


            var list = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
            ViewBag.fruit = list;
            //Save
            return View();
        }

        public ActionResult ImportExcel(List<string> fruit, List<string> fruitListbox)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{Text="Apple",Value="1"},
                new SelectListItem{Text="Banana",Value="2"},
                new SelectListItem{Text="Orange",Value="3"}
            };
            ViewBag.fruit = list;
            //Save
            return View();
        }

        public class ImportExcelViewModel
        {

            public string email { get; set; }
            public string RowNb { get; set; }

        }
        public JsonResult Upload()
        {
            //if (Request != null)
            //{
            //    HttpPostedFileBase file = Request.Files["UploadedFile"];
            //    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            //    {
            //        string fileName = file.FileName;
            //        string fileContentType = file.ContentType;
            //        byte[] fileBytes = new byte[file.ContentLength];
            //        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
            //        var usersList = new List<Label>();
            //        using (var package = new ExcelPackage(file.InputStream))
            //        {
            //            var currentSheet = package.Workbook.Worksheets;
            //            var workSheet = currentSheet.First();
            //            var noOfCol = workSheet.Dimension.End.Column;
            //            var noOfRow = workSheet.Dimension.End.Row;

            //            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
            //            {
            //                var user = new Label();
            //                user.LabelId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
            //                user.LabelName = workSheet.Cells[rowIterator, 2].Value.ToString();
            //                usersList.Add(user);
            //            }
            //        }
            //    }
            //}
            //return View("ImportExcel");

            try
            {

                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string fileName = file.FileName;
                            string fileContentType = file.ContentType;
                            byte[] fileBytes = new byte[file.ContentLength];
                            var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                            //List<lead> leadsList = new List<lead>();
                            List<ImportExcelViewModel> lstImportExcel = new List<ImportExcelViewModel>();
                            List<ImportExcelViewModel> errorLstImportExcel = new List<ImportExcelViewModel>();

                            using (var package = new ExcelPackage(file.InputStream))
                            {
                                var currentSheet = package.Workbook.Worksheets;
                                var workSheet = currentSheet.First();
                                var noOfCol = workSheet.Dimension.End.Column;
                                var noOfRow = workSheet.Dimension.End.Row;

                                //first row is titles
                                for (int rowIterator = 1; rowIterator <= noOfRow; rowIterator++)
                                {
                                    /********************************Validtae*************************/
                                    var importExcelRow = new ImportExcelViewModel
                                    {
                                        // email = workSheet.Cells[rowIterator, 1].Value.ToString(),
                                        RowNb = workSheet.Cells[rowIterator, 2].Value.ToString()


                                    };
                                    lstImportExcel.Add(importExcelRow);
                                    /*****************************validate*****************************************/

                                }
                                //lstImportExcel = ValidateImport(lstImportExcel); //validate the rows with the system values 
                                if (lstImportExcel != null)
                                {


                                    foreach (var importExcelRow in lstImportExcel)
                                    {
                                        //if (importExcelRow.IsVallid == true)
                                        //{
                                        //    //save in database
                                        //}
                                        //else
                                        //{
                                        //save records of error  that are not saved
                                        var errorImportExcelRow = new ImportExcelViewModel
                                        {
                                            email = importExcelRow.email,
                                            RowNb = importExcelRow.RowNb

                                        };
                                        errorLstImportExcel.Add(errorImportExcelRow);
                                        //}
                                    }



                                }
                                else
                                {
                                    //something wrong in validation
                                    return Json(false, JsonRequestBehavior.AllowGet);
                                }


                            }
                            //export to excel the error emails
                            ExcelPackage excel = new ExcelPackage();
                            var myworkSheet = excel.Workbook.Worksheets.Add("Sheet1");

                            //Header of table  
                            //  
                            myworkSheet.Row(1).Height = 20;
                            myworkSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            myworkSheet.Row(1).Style.Font.Bold = true;
                            myworkSheet.Cells[1, 1].Value = "Row Number";
                            myworkSheet.Cells[1, 2].Value = "Email";

                            //Body of table  
                            //  
                            int recordIndex2 = 1;
                            foreach (var student in errorLstImportExcel)
                            {
                                myworkSheet.Cells[recordIndex2, 1].Value = student.RowNb.ToString();
                                myworkSheet.Cells[recordIndex2, 2].Value = student.email.ToString();

                                recordIndex2++;
                            }
                            myworkSheet.Column(1).AutoFit();
                            myworkSheet.Column(2).AutoFit();

                            var fileBytes2 = excel.GetAsByteArray();
                            Response.Clear();

                            Response.AppendHeader("Content-Length", fileBytes2.Length.ToString());
                            Response.AppendHeader("Content-Disposition",
                                String.Format("attachment; filename=\"{0}\"; size={1}; creation-date={2}; modification-date={2}; read-date={2}"
                                    , "test2.xlsx"
                                    , fileBytes2.Length
                                    , DateTime.Now.ToString("R"))
                                );
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                            Response.BinaryWrite(fileBytes2);
                            Response.End();

                            return Json(false, JsonRequestBehavior.AllowGet);

                        }
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {

                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {


                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public class FileColl
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }
        public ActionResult Downloadfile_link()
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@"~/stuff"));
            var files = directory.GetFiles().ToList();
            List<FileColl> fileC = new List<FileColl>();
            string path = Server.MapPath("~/stuff/");//设定上传的文件路径

            foreach (var file in files)
            {
                fileC.Add(new FileColl { FileName = file.Name, FilePath = file.FullName });
            }

            return View(fileC);
        }

        #region Unobtrusive Ajax.BeginForm
        public ActionResult Unobtrusive()
        {

            return View();
        }


        public ActionResult MyMap()
        {

            return View();
        }
        #endregion

        #region MVC Edit view with Picture
        public static Image resizeMyImage(Image imgToResize, Size size)
        {

            return (Image)(new Bitmap(imgToResize, size));
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult ImageUpload(/*HttpPostedFileBase Filedata*/)
        {
            #region upload and save image
            //ImageDatabaseEntities6 db = new ImageDatabaseEntities6();
            // file = Request.Files["ImageFile"]; 
            //HttpPostedFileBase file = Request.Files["SelectImage"]; //Request.Files
            var file = Request.Files[0];
            int imgId = 0;
            //var file = jobs.ImageFile;
            byte[] imagebyte = null;
            if (file != null)
            {
                file.SaveAs(Server.MapPath("/images/" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                Label img = new Label();
                //img.ImageTitle = file.FileName;
                //img.ImageByte = imagebyte;
                //img.ImagePath = "/UploadImage/" + file.FileName;
                img.LabelName = "/images/" + file.FileName;
                //db.Label.Add(img);
                //db.SaveChanges();
                imgId = img.LabelId;
            }
            return Json("3", JsonRequestBehavior.AllowGet);

            #endregion
            #region 调整图片大小 并保存图片 save and resize image 
            //Image sourceimage = Image.FromStream(Filedata.InputStream);  //mainImg is of type HttpPostedFileBase
            //Guid g = Guid.NewGuid();
            //string fileName = g + "_" + System.IO.Path.GetFileName(Filedata.FileName);
            //Image thumbnail = resizeMyImage(sourceimage, new Size(525, 328));


            ////string thumbnailsPath = System.IO.Path.Combine(
            ////    Server.MapPath("~/Uploads/apartments/thumbnails"), fileName);
            ////var path = Path.Combine(Server.MapPath("/images/"), fileName);
            //var path= System.IO.Path.Combine(
            //    Server.MapPath("/images/"), fileName);

            //thumbnail.Save(path);
            //return View();
            #endregion
        }
        public JsonResult DisplayingImage(int imgID) //https://stackoverflow.com/questions/17721009/url-action-not-working-not-showing-picture-in-img //image src call mvc action show pic
        {
            //ImageDatabaseEntities6 db = new ImageDatabaseEntities6();
            var id = Convert.ToInt32(imgID);
            var img = db.Label.SingleOrDefault(x => x.LabelId == id);
            return Json(img.LabelName, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pic_Edit(int? ImageId = 1)
        {
            if (ImageId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Label jobs = db.Label.Find(1);

            if (jobs == null)
            {
                return HttpNotFound();
            }

            return View(jobs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pic_Edit(Label jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobs);
        }
        #endregion
        #region ClosedXML download xml Merge cells insert pic
        public ActionResult ClosedXML_Index()
        {
            var list = db.Author.Take(10).ToList();
            return View(list);
        }

        [HttpPost]
        public FileResult ClosedXML_Export(string usename,string usename2)
        {
            #region 劫持返回验证信息 表单 AJAX ActionResult
            //if (!string.IsNullOrEmpty(usename))
            //{
            //    var data = db.Blogs.Where(x => x.Name == usename).ToList();
            //    if (data.Count == 0)
            //    {
            //        return Json(new { status = true, list = data }, JsonRequestBehavior.AllowGet);
            //    }
            //    else {
            //        return Json(new { status = true, list = data }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            //return Json(new { status = true}, JsonRequestBehavior.AllowGet);
            #endregion
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("CustomerId"),
                                            new DataColumn("ContactName") });

            var customers = from customer in db.Author.Take(10)
                            select customer;

            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.id, customer.AuthorName);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                // var workbook = new XLWorkbook();
                var ws = wb.Worksheets.Add("Merge Cells");

                // Merge a row
                ws.Cell("B2").Value = "Merged Row(1) of Range (B2:D3)";
                ws.Range("B2:D3").Row(1).Merge();

                // Merge a column
                ws.Cell("F2").Value = "Merged Column(1) of Range (F2:G8)";
                ws.Cell("F2").Style.Alignment.WrapText = true;
                ws.Range("F2:G8").Column(1).Merge();

                //Merge a range
                ws.Cell("B4").Value = "Merged Range (B4:D6)";
                ws.Cell("B4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("B4:D8").Merge();

                // Unmerging a range...
                ws.Cell("B8").Value = "Unmerged";
                ws.Range("B8:D8").Merge();
                ws.Range("B8:D8").Unmerge();


                // var ws2 = wb.AddWorksheet("Sheet2");

                //var imagePath = @"c:\path\to\your\image.jpg";


                var imagePath = Server.MapPath("/images/test.jpg");


                //// Load the image.
                //System.Drawing.Image image1 = System.Drawing.Image.FromFile(imagePath);

                //// Save the image in JPEG format.
                //image1.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                var image = ws.AddPicture(imagePath)
                    .MoveTo(ws.Cell("B4").Address)
                    .Scale(0.5); // optional: resize picture

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion
        # region use datatable as parameter in stored procedure   执行后 User表会自动填充，执行前先清空

        public ActionResult StoredProcedure_Index()
        {

            DataTable _DataTable = GenerateDataTable();
            SqlParameter Parameter = new SqlParameter("@param1", _DataTable);
            Parameter.TypeName = "dbo.UsersTableType";
            db.Database.ExecuteSqlCommand("exec User_Insert @param1", Parameter);

            ////string connString = ConfigurationSettings.AppSettings["Sql"];

            //  string connString =
            //@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";

            //  //Open SQL Connection
            //  using (SqlConnection conn = new SqlConnection(connString))
            //  {
            //      conn.Open();
            //      //Initialize command object
            //      using (SqlCommand cmd = new SqlCommand("User_Insert", conn))
            //      {
            //          //set the command type  to stored procedure
            //          cmd.CommandType = CommandType.StoredProcedure;

            //          //add parameter
            //          cmd.Parameters.AddWithValue("@param1", _DataTable);

            //          //execute the stored procedure
            //          cmd.ExecuteNonQuery();
            //      }
            //  }

            return View();
        }
        private DataTable GenerateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UName");
            dt.Columns.Add("Email");
            dt.Rows.Add("Andy", "qwefe");
            dt.Rows.Add("Mary", "adsafsf");
            dt.Rows.Add("Jacj", "sdsa");

            return dt;
        }
        #endregion

        //toastr
        public ActionResult toastr()
        {

            TempData["Message"] = "Client Details Edited Successfully";

            return View();
        }

        public ActionResult IgnoreCaseAndAccentuation(string filter)
        {
            filter = "Mv";
            var list = db.Search.ToList();
            string queryText = filter.ToUpper().RemoveDiacritics();
            var result = (from c in list
                          where c.Title.ToUpper().RemoveDiacritics().Contains(queryText)
                          select c).ToList();
            return View();
        }

        #region Upload file to file server without submit
        //public class selectmodelVM
        //{
        //    public int Id { get; set; }
        //    public string Text { get; set; }
        //    public string Value { get; set; }

        //}

        public ActionResult UploadOutSubmit(HttpPostedFileBase file2/*, string selectvalue*/)
        {
            //var list = new List<selectmodelVM>
            //{
            //    new selectmodelVM{Text="1",Value="1"},
            //    new selectmodelVM{Text="2",Value="2"},
            //    new selectmodelVM{Text="3",Value="3"}
            //};
            if (file2 != null && file2.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file2.FileName);

                var path = Path.Combine(Server.MapPath("/images/"), fileName);

                file2.SaveAs(path);
            }

            return View(/*list*/);
        }
        [HttpPost]
        public ActionResult UploadOutSubmitAjax()//Edge not work =>solution:Path.GetFileName(file2.FileName)
        {
            var file = Request.Files[0];
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("/images/" + fileName));
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region DropDownList 级联 array to SelectList  //https://forums.asp.net/t/2142902.aspx?Fill+two+relative+drop+down+list
        public class DemoViewModel
        {

            public string Text { get; set; }
            public string Value { get; set; }
            public string keyword { get; set; }

        }
        public class TestViewModel
        {

            public string Text { get; set; }
            public string Value { get; set; }
        }

        public class enquiry_products
        {
            public string enquiry_is_active { get; set; }
            public string opportunity_expiry_date { get; set; }
            public string opportunity_stage { get; set; }

        }

        public class Hobby
        {
            public int HobbyID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public Person Person { get; set; }
        }

        public class Person
        {
            public int PersonID { get; set; }
            public int Age { get; set; }
            public string Name { get; set; }
            public ICollection<Hobby> Hobbies { get; set; }
        }

        public ActionResult PartnerPreference()
        {
            #region
            var minagelist = new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            var maxagelist = new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            var minitems = minagelist.Select((n, i) =>
            {
                return new SelectListItem
                {
                    Value = n.ToString(),
                    Text = i.ToString()
                };
            }).ToList();

            var maxitems = maxagelist.Select((n, i) =>
            {
                return new SelectListItem
                {
                    Value = n.ToString(),
                    Text = i.ToString()
                };
            }).ToList();

            ViewBag.minagelist = new SelectList(minitems, "Value", "Value");
            ViewBag.maxagelist = new SelectList(maxitems, "Value", "Value");
            #endregion

            #region GROUPBY AddRange 
            var list1 = new List<TestViewModel>
            {
                new TestViewModel{Text="Apple2",Value="1"},
                new TestViewModel{Text="Banana",Value="2"},
                new TestViewModel{Text="Orange",Value="3"},
                new TestViewModel{Text="Banana",Value="4"},
                new TestViewModel{Text="Orange",Value="5"},
                new TestViewModel{Text="Banana",Value="2"},
                new TestViewModel{Text="Banana",Value="4"},
                new TestViewModel{Text="Banana",Value="5"}





            };


            //var list2 = new List<TestViewModel>
            //{
            //    new TestViewModel{Text="Apple2",Value="11"},
            //    new TestViewModel{Text="Banana",Value="2"},
            //    new TestViewModel{Text="Orange",Value="3"}

            //};

            var querylist1 = new List<TestViewModel>();
            var querylist2 = new List<TestViewModel>();


            //foreach (var item in list1.Select(p => p.Value).ToList())
            //{
            //    querylist1 = list2.Where(p => p.Value == item).ToList();
            //    querylist2.AddRange(querylist1);
            //}
            #region Contain Any
            //var list11 = new string [] { "33","34" };
            //var products = (from s in db.Author
            //                where s.id != 100 && list11.Any(_=>_==s.id.ToString())
            //                select s).ToList();
            #endregion

            //foreach (var item in list11)
            //{
            //    //querylist1 = list2.Where(p => p.Value == item).ToList();         
            //    //querylist2.AddRange(querylist1);
            //    var products = db.Author.Where(s => s.id == item).ToList();
            //    test.Add(item);
            //}


            //querylist2.GroupBy(item => item.Text,(key, group) =>  new { GroupName = key, Items = group.ToList() })
            #endregion

            //var Personlist1 = new List<Person>
            //{
            //    new Person{PersonID=1,Age=51,Name="aa"},
            //    new Person{PersonID=2,Age=10,Name="bb"},
            //    new Person{PersonID=3,Age=10,Name="cc"}

            //};

            //var Hobbylist2 = new List<Hobby>
            //{
            //    new Hobby{HobbyID=1,Name="aa",Type="y"},
            //    new Hobby{HobbyID=2,Name="bb",Type="y"},
            //    new Hobby{HobbyID=3,Name="cc",Type="n"}

            //};


            #region GROUPBY MUTIPLE
            //var list3 = new List<DemoViewModel>
            //{
            //    new DemoViewModel{Text="Apple",keyword="x",Value="1"},
            //    new DemoViewModel{Text="Banana",keyword="x",Value="2"},
            //    new DemoViewModel{Text="Banana",keyword="p",Value="3"},
            //    new DemoViewModel{Text="Orange",keyword="x",Value="4"},
            //    new DemoViewModel{Text="Orange",keyword="x",Value="5"},


            //};

            ////list3.GroupBy(s => new { s.Text, s.keyword }, (key, group) => new { GroupName = key, Items = group.ToList() })
            #endregion



            return View();
        }

        #endregion

        #region ToPagedList pagelist.mvc 分页 https://github.com/TroyGoode/PagedList linq to sql https://forums.asp.net/t/2141165.aspx
        public class mixViewModel
        {
            public int LabelId { get; set; }
            public string LabelName { get; set; }

            public string CityName { get; set; }


        }


        public ActionResult SampleMatchSummary_Index()
        {
            ViewBag.CasteId = new SelectList(db.Label.ToList(), "LabelId", "LabelName");
            return View();
        }

        [HttpPost]
        public ActionResult SampleMatchSummary_Index(int[] castemultilist, string LanguageId, int? page)
        {
            var profilelist2 = new List<mixViewModel>();
            foreach (var item in castemultilist)
            {
                //list = db.Cities.Where(_ => _.CountryId == item).ToList();

                //var profileModel = (from p in db.c

                //                    join c in db.CasteList on p.PCaste equals c.CasteId
                //                    where (p.PCaste in castemultilist)

                //                  select new ViewProfileVM
                //                  {

                //                      CasteName = c.CasteName

                //                  }
                //              ).ToList<ViewProfileVM>().ToPagedList(page ?? 1, 10);

                var profilelist = (from l in db.Label.ToList()
                                   join c in db.Cities.ToList() on l.LabelId equals c.CountryId
                                   where l.LabelId == item
                                   select new mixViewModel()
                                   {
                                       LabelId = l.LabelId,
                                       LabelName = l.LabelName,
                                       CityName = c.CityName
                                   }).ToList();
                profilelist2.AddRange(profilelist);

            }
            ViewBag.profilelist = profilelist2.ToPagedList(page ?? 1, 5);

            //var list = db.Cities.Where(_ => _.CountryId == castemultilist.).ToList();
            ViewBag.CasteId = new SelectList(db.Label.ToList(), "LabelId", "LabelName");
            //int castelist1 = Convert.ToInt32(castemultilist);
            //int languageid1 = Convert.ToInt32(LanguageId);

            //if ((castemultilist == null) && (!string.IsNullOrEmpty(LanguageId)))
            //{
            //    //var profileModel = mainDatabaseContext.Profile.Where(p => p.PGender != GenderName && p.PId != PID).ToList<ProfileModel>();
            //    var profileModel = (from p in db.Profile

            //                        join c in db.CasteList on p.PCaste equals c.CasteId
            //                        where (p.PCaste in castemultilist)

            //                  select new ViewProfileVM
            //                  {

            //                      CasteName = c.CasteName

            //                  }
            //              ).ToList<ViewProfileVM>().ToPagedList(page ?? 1, 10);
            //    ViewBag.MatchSummary = profileModel;
            //    return View();
            //}
            //else
            //{
            //    var profileModel = (from p in db.Profile

            //                        join c in db.CasteList on p.PCaste equals c.CasteId

            //                        where (p.PCaste == ((from ps in db.Profile where ps.ProfileId == Profileid select ps.PCaste).FirstOrDefault()))
            //                        select new ViewProfileVM
            //                        {

            //                            CasteName = c.CasteName

            //                        }
            //                              ).ToList<ViewProfileVM>().ToPagedList(page ?? 1, 10);
            //    ViewBag.MatchSummary = profileModel;

            //}
            return View();
            //return PartialView(ViewBag.profilelist);
        }

        #endregion

        #region Multifilter
        public ActionResult FilterColumn(string filter)
        {

            return View();
        }
        #endregion

        #region one to many entity

        public class GroupGroupProperty
        {
            public int GroupId { get; set; }
            public string GroupName { get; set; }

            public string GroupDescription { get; set; }

            public int GroupPropertyId { get; set; }
            public string GroupPropertyName { get; set; }

            public string GroupPropertyDescription { get; set; }

        }

        public ActionResult Relationships()
        {

            //db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var partialResult4 = (from gp in db.Groups
                                  join gpp in db.GroupProperties
                                  on gp.GrpId equals gpp.Id

                                  select new GroupGroupProperty
                                  {
                                      GroupId = gp.GrpId,
                                      GroupName = gp.Name,
                                      GroupDescription = gp.Description,
                                      GroupPropertyId = gpp.Id,
                                      GroupPropertyName = gp.Name,
                                      GroupPropertyDescription = gp.Description

                                  }).ToList();

            return View();

        }
        #endregion


        #region kendo treeview
        public class kendoTreeviewVM
        {
            public int Id { get; set; }
            public int? IdParent { get; set; }
            public int? Level { get; set; }
            public string Name { get; set; }

        }

        //public class kendoTreeviewVM2
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }

        //}
        public ActionResult kendo_treeview()
        {


            //var products =
            //   RepositoryFunctions.ProductsRepository.GetProducts().OrderBy(p => p.Name).ToList();
            //return PartialView(products);

            // return null;

            var list = new List<kendoTreeviewVM>
            {
                new kendoTreeviewVM{Id=1,IdParent=0,Level=0,Name="Product 1"},
                new kendoTreeviewVM{Id=2,IdParent=1,Level=1,Name="Item 1"},
                new kendoTreeviewVM{Id=3,IdParent=1,Level=1,Name="Item 2"},
                new kendoTreeviewVM{Id=4,IdParent=2,Level=2,Name="Sub Item 1"}

            };

            #region https://forums.asp.net/t/2145521.aspx
            // var list2 = list.Select(a => new kendoTreeviewVM2
            // {

            //     Id = a.Id+a.IdParent.Value+a.Level.Value,
            //     Name = "ss"

            // }
            //).ToList();
            #endregion
            return View(list);
        }
        #endregion

        //public ClientReceiptViewModel GetClientPolicy(string id)
        //{
        //    var result = new ClientReceiptViewModel();
        //    var query = "Select *, CONVERT(bigint,RowVersionNo) as RowVersionNo2 FROM Underwriting_PolicyFile WHERE PolicyRefCode = @PolicyRefCode; ";
        //    result.Underwriting_PolicyFile = context.Query<Underwriting_PolicyFile>(query, new
        //    {
        //        PolicyRefCode = id
        //    }).FirstOrDefault();

        //    if (result.Underwriting_PolicyFile != null)
        //    {
        //        var query2 = "Select PolicyRefCode, DebitNoteNo,InsBranchCode,TransactionCode, BranchCode, PolicyCode,InsuerLeadCode, PercentageCover,ClientType,ClientCode,InsurerCode," +
        //         "CONVERT(bigint, RowVersionNo) as RowVersionNo2 FROM Underwriting_InsurerPolicyDistribution WHERE PolicyRefCode = @PolicyRefCode " +
        //         "AND CommenceDate = @CDate AND ExpiryDate = @ExDate AND RenewalDate = @RDate AND TerminalDate = @TDate AND(TransactionCode = '0001' OR TransactionCode = '0002'); ";


        //        result.Underwriting_InsurerPolicyDistribution =
        //        context.Query<Underwriting_InsurerPolicyDistribution>(query2, new
        //        {
        //            PolicyRefCode = id,
        //            CDate = result.Underwriting_PolicyFile.CommenceDate,
        //            ExDate = result.Underwriting_PolicyFile.ExpiryDate,
        //            RDate = result.Underwriting_PolicyFile.RenewalDate,
        //            TDate = result.Underwriting_PolicyFile.TerminalDate
        //        }).ToList();

        //    }
        //    return result;

        //}

        #region //https://forums.asp.net/t/2146631.aspx  event.preventDefault();
        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int EmailID { get; set; }
            public string Country { get; set; }
            public string City { get; set; }

        }

        public ActionResult EmployeeList()
        {

            var list = new List<Employee>
            {
                new Employee{EmployeeID=1,FirstName="f1",LastName="l1",EmailID=1,Country="c1",City="ct1"},
                new Employee{EmployeeID=2,FirstName="f2",LastName="l2",EmailID=2,Country="c2",City="ct2"},
                new Employee{EmployeeID=3,FirstName="f3",LastName="l3",EmailID=3,Country="c3",City="ct3"},
                new Employee{EmployeeID=4,FirstName="f4",LastName="l4",EmailID=4,Country="c4",City="ct4"}

            };
            ViewBag.XX = 11;
            var employees = list.OrderBy(e => e.FirstName).ToList();
            return View(employees);
        }

        public ActionResult GetEmployeebyID(int ID)
        {
            //Employee employee = list.Find(ID);
            Employee employee = new Employee();
            employee.EmployeeID = 2;
            employee.FirstName = "xx";

            //return View("EmployeeList", employee);
            return RedirectToAction("EmployeeList", employee);
            // return PartialView("_ViewEmployee", employee);
        }

        //[HttpPost]
        //public ActionResult GetEmployeebyID(int ID)
        //{
        //    if (Request.IsAjaxRequest())
        //    {
        //        Employee employee = new Employee();
        //        employee.EmployeeID = 2;
        //        employee.FirstName = "xx";
        //        return PartialView("_ViewEmployee", employee);
        //    }
        //    else
        //    {
        //        return PartialView("_ViewEmployee", null);
        //    }
        //}

        public ActionResult _ViewEmployee(int? ID)
        {
            Employee employee = new Employee();
            employee.EmployeeID = 2;
            employee.FirstName = "f2";
            employee.LastName = "l2";
            employee.EmailID = 2;
            employee.Country = "c2";
            employee.City = "ct2";
            
            return PartialView(employee);
        }

        public ActionResult DeleteEmployee(int ID)
        {
            //using (DemoEntities dc = new DemoEntities())
            //{
            //    var v = list.Where(a => a.EmployeeID == ID).FirstOrDefault();
            //    if (v != null)
            //    {
            //        dc.Employees.Remove(v);
            //        dc.SaveChanges();

            //    }
            //}
            return RedirectToAction("EmployeeList");
        }

        [HttpPost]
        public ActionResult AddEditEmployee(Employee emp)
        {
            //if (ModelState.IsValid)
            //{
            //    // Get Employee By ID
            //    Employee obj = dc.Employees.Find(emp.EmployeeID);

            //    if (obj == null)
            //    {
            //        // Insert new Employee
            //        dc.Employees.Add(emp);
            //        dc.SaveChanges();
            //    }
            //    else
            //    {
            //        obj.FirstName = emp.FirstName;
            //        obj.LastName = emp.LastName;
            //        obj.EmailID = emp.EmailID;
            //        obj.City = emp.City;
            //        obj.Country = emp.Country;
            //        dc.SaveChanges();
            //    }
            //}


            return RedirectToAction("EmployeeList");
        }
        #endregion

        #region Bootstrap dynamic modal content

        public class QuestionViewModel
        {
            public string Title { get; set; }
            public string Description { get; set; }

        }

        public class EmptyRows
        {
            public int Id { get; set; }
            public string name1 { get; set; }
            public string name2 { get; set; }
            public string name3 { get; set; }


        }
        public ActionResult Bootstrapmodal_Index()
        {
            #region not in in linq
            //var exceptionList = new List<string> { "USAcity1", "USAcity1", "USAcity2" };
            //var query = db.Cities
            //                         .Select(e => e.CityName)
            //                         .Where(e => !exceptionList.Distinct().Contains(e)).ToList();
            #endregion
            #region how to merge rows with same id
            //var vm = new EmptyRows();

            //var list = new List<EmptyRows>
            //{
            //    new EmptyRows{Id=1,name1="t1"},
            //    new EmptyRows{Id=1,name2="f2"},
            //    new EmptyRows{Id=1,name3="f3"},
            //    new EmptyRows{Id=2,name1="t4",name2="f4",name3="f4"}

            //};
            //var list2 = list.GroupBy(x => x.Id).ToList();
            #endregion
            return View();
        }

        public ActionResult Details(int id)
        {
            // Get the data using the Id and pass the needed data to view.

            var vm = new QuestionViewModel();

            var list = new List<QuestionViewModel>
            {
                new QuestionViewModel{Title="t1",Description="f1"},
                new QuestionViewModel{Title="t2",Description="f2"},
                new QuestionViewModel{Title="t3",Description="f3"},
                new QuestionViewModel{Title="t4",Description="f4"}

            };
            //var question = list.FirstOrDefault(a => a.Id == id);
            //// To do: Add null checks

            //vm.Id = question.Id;
            vm = list.FirstOrDefault();

            return PartialView(vm);
        }
        #endregion

    }

}









