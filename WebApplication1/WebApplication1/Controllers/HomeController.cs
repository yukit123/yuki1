using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

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
    public class HomeController : BaseController
    {
        private BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            //db.Blogs.FirstOrDefault();
            //db.Blogs.ToList()
            //BolgViewModel vm = new BolgViewModel();
            BolgView2Model vm2 = new BolgView2Model();
            vm2.blogs = db.Blogs.ToList();
            vm2.authors = db.Author.ToList();
            var list = db.Blogs.ToList();
            ViewBag.auth = db.Author.ToList();
            ViewBag.label = db.Label.ToList();
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
             SqlCommand command = new SqlCommand(strConn,conn);
            foreach (var item in Number)
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Table (Labels) VALUES (@Labels);";
                command.Parameters.AddWithValue("@Labels", item.ToString());
                conn.ConnectionString = strConn;
              
                conn.Open();
                SqlDataReader myReader = command.ExecuteReader();
                int n= command.ExecuteNonQuery();
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
            return Json( new { success = true, msg = "123" }, JsonRequestBehavior.AllowGet);
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
                Pid=item.Pid,
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
            //DataSet ds = dblayer.Get_Company_Name();
            //List<Accounts> listreg = new List<Accounts>();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    String Account_ID = dr["account_name"].ToString();
            //    listreg.Add(new Accounts
            //    {
            //        Account_Id = Account_ID.Replace(" ", String.Empty),
            //        Account_name = dr["account_name"].ToString(),
            //        Account_Parent = dr["parent_account_ID"].ToString(),
            //    });
            //}
            //return Json(listreg, JsonRequestBehavior.AllowGet);
            string listjsonstr = "[{\"nodeID\": {\"1\": [{\"ID\": \"1.1\",\"childNodeType\": \"branch\",\"childData\": [\"1.1: column 1\"]}],\"1.1\": [{\"ID\": \"1.1.1\",\"childNodeType\": \"leaf\",\"childData\": [\"1.1.1: column 1\"]}],\"2\": [{\"ID\": \"2.1\",\"childNodeType\": \"leaf\",\"childData\": [\"2.1: column 1\"]}]}}]";
            return Json(new { list = listjsonstr }, JsonRequestBehavior.AllowGet);
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
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult validate()
        {
            var list = db.Student.ToList();
            ProjectAndStudentModels pvm = new ProjectAndStudentModels();
            pvm.StudentsAndID = db.Student.ToList();
            return View(pvm);
        }

        [HttpPost]
        public JsonResult IsStudentExists(int? Id)
        {
            var list = db.Student.ToList();
          
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method. 
            return Json((!list.Any(x => x.Id == Id)==false?"false":"true"), JsonRequestBehavior.AllowGet);
        }


        public ActionResult validate2()
        {
            var list = db.Label.ToList().FirstOrDefault();
           // ProjectAndStudentModels pvm = new ProjectAndStudentModels();
           // pvm.StudentsAndID = db.Student.ToList();

            return View(list);
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
            if (list == null)
            {
                return Json(new { success = false, showlist = list, msg = "operation failed" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, showlist = list, msg = "Successful operation" }, JsonRequestBehavior.AllowGet);
            }

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

           var list233 = "{\"rows\": [{ \"id\": 1, \"name\": \"All Tasks\", \"begin\": \"3/4/2010\", \"end\": \"3/20/2010\", \"progress\": 60, \"iconCls\": \"icon-ok\" }]}";
            return Json(list233, JsonRequestBehavior.AllowGet);
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

            List<SelectListItem> osrListItems3=db.Label.Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected = true }).ToList();
            ViewBag.OSRddl = new SelectList(osrListItems3, "Value", "Text", osrListItems3[1].Value);
            return View();
        }

        public ActionResult Get_priceinfo()
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
            return View(labvm);

        }

        public ActionResult Modalpopup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Modalpopup2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
        public ActionResult datatableajax(string array)
        {
            // do sth to save data to sqldb
            return View();
        }

        public ActionResult datatable2()//calendar 
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit(/*int? id, string owner*/)
        {

                Label todo = db.Label.Find(1);
                if (todo == null)
                {
                    return HttpNotFound();
                }

                var options = new List<Label>();
                options.Add(new Label() { LabelId =11, LabelName = "New Request" });
                options.Add(new Label() { LabelId =12, LabelName = "Reviewed" });
                options.Add(new Label() { LabelId =13, LabelName = "Started" });
                options.Add(new Label() { LabelId =14, LabelName = "In Progress" });
                options.Add(new Label() { LabelId =15, LabelName = "Completed" });
                ViewBag.Status = options;
            //List<SelectListItem> osrListItems = db.Label.Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName }).ToList();
            List<SelectListItem> osrListItems1 = db.Label.Where(w => w.LabelId == 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName,Selected=true }).Distinct().ToList();
            List<SelectListItem> osrListItems2 = db.Label.Where(w => w.LabelId != 2).Select(osr => new SelectListItem { Value = osr.LabelId.ToString(), Text = osr.LabelName, Selected=false }).Distinct().ToList();
            List<SelectListItem> osrListItems = new List<SelectListItem>();
            osrListItems.AddRange(osrListItems1);
            osrListItems.AddRange(osrListItems2);
            osrListItems=osrListItems.OrderBy(x => x.Value).ToList();

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
        public ActionResult RunCostCodeReport(string StartDate,string EndDate)
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
            var relatedQuestions=new List<Search>();
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
            //byte[] doc = Pdf();
            var path = @"D://";
            var file = Path.Combine(path, "test.pdf");
            file = Path.GetFullPath(file);
            string mimeType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "inline; filename=" + "test.pdf");
            return File(file, mimeType);
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
        public ActionResult storeProcedure()//调用存储过程
        {
           // DataSet ds = new DataSet();
           // string connectionstring = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BlogContext;Integrated Security=True";
           // SqlConnection connection = new SqlConnection(connectionstring);
           // connection.Open();
            string sql = "kd_selFoodItemsSearch";
            ////string sql = "EXEC kd_selFoodItemsSearch @OrgID,@SearchText";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@OrgID", 2);
            command.Parameters.AddWithValue("@SearchText", "p");
           // command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.Text;

            //command.Connection = connection;
          //  SqlDataAdapter sda = new SqlDataAdapter(command);
          ////  DataTable dt = new DataTable();
          //  sda.Fill(ds);


          //  var list = new List<FoodViewModel>();
          //  foreach (DataRow row in ds.Tables[0].Rows)
          //  {
          //      list.Add(new FoodViewModel
          //      {
          //          FoodID = Convert.ToInt32(row["FoodID"]),
                 
          //          CategoryID = Convert.ToInt32(row["CategoryID"]),
          //          FoodItem = row["FoodItem"].ToString()
          //      });
          //  }

            var list=ExecuteStoredProc(command, "TotalCount");
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
                    FoodViewModel e = new FoodViewModel {
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

        public ActionResult DownloadFile()// Download
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "test.xls");
            string fileName = "test.xls";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
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
        #endregion


        public ActionResult Webgrid()
        {
            ViewBag.Message = "Your contact page.";
            var list = db.Label.ToList();
            return View(list);
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

        #region firstpagecontroller
        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult DoSave()
        //{
        //    var files = Request.Files;
        //    string Pic1 = string.Empty;
        //    string Pic2 = string.Empty;
        //    int i = 0;
        //    List<FileUrlModel> array = new List<FileUrlModel>();
        //    List<UrlNameModel> imgnamearray = new List<UrlNameModel>();

        //    for (i = 1; i <= files.Count; i++)
        //    {
        //        HttpPostedFileBase avatar = Request.Files[i - 1];
        //        string fname = files.AllKeys[i - 1];
        //        var FileName = files.Keys[i - 1];
        //        string name = Path.GetFileName(Request.Files[fname].FileName);//Path.GetFullPath(Request.Files[fname].FileName)
        //        if (string.IsNullOrEmpty(name))
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            if (i == (files.Count - 3))//头图
        //            {
        //                if (!CheckImg(avatar, 1))
        //                {
        //                    //return Json(new { success = 3,imgname= Request.Files.AllKeys[i-1]}, JsonRequestBehavior.AllowGet);
        //                    // imgname = Request.Files.AllKeys[i - 1];
        //                    imgnamearray.Add(new UrlNameModel() { id = (i - 1), imgname = Request.Files.AllKeys[i - 1] });
        //                }
        //                else
        //                {
        //                    //    model.ProductSmallPicture = Libraries.SaveFile.SaveUploadedFile(avatar, dirPath, "");
        //                    var extension = avatar.FileName.Substring(avatar.FileName.LastIndexOf('.'));//原文件扩展名
        //                    string filename = "";
        //                    if (name != "")
        //                        filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + avatar.ContentLength.ToString() + extension;//新文件名称
        //                    string imgurl = "/SiemensEcatalogImg/FirstPageImg/" + filename;
        //                    array.Add(new FileUrlModel() { id = (i - 1), fileurl = imgurl });
        //                    var file = Request.Files[fname];
        //                    string Paths = string.Format("/SiemensEcatalogImg/FirstPageImg/{0}", filename);
        //                    Pic1 = Paths;
        //                    if (Directory.Exists(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/")) == false)//如果不存在就创建file文件夹
        //                    {
        //                        Directory.CreateDirectory(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/"));
        //                    }
        //                    file.SaveAs(this.Server.MapPath("~" + Paths));
        //                }
        //            }
        //            else if (i == (files.Count - 2))//特色产品左一图
        //            {
        //                if (!CheckImg(avatar, 2))
        //                {
        //                    //return Json(new { success = 3,imgname= Request.Files.AllKeys[i-1]}, JsonRequestBehavior.AllowGet);
        //                    // imgname = Request.Files.AllKeys[i - 1];
        //                    imgnamearray.Add(new UrlNameModel() { id = (i - 1), imgname = Request.Files.AllKeys[i - 1] });
        //                }
        //                else
        //                {
        //                    //    model.ProductSmallPicture = Libraries.SaveFile.SaveUploadedFile(avatar, dirPath, "");
        //                    var extension = avatar.FileName.Substring(avatar.FileName.LastIndexOf('.'));//原文件扩展名
        //                    string filename = "";
        //                    if (name != "")
        //                        filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + avatar.ContentLength.ToString() + extension;//新文件名称
        //                    string imgurl = "/SiemensEcatalogImg/FirstPageImg/" + filename;
        //                    array.Add(new FileUrlModel() { id = (i - 1), fileurl = imgurl });
        //                    var file = Request.Files[fname];
        //                    string Paths = string.Format("/SiemensEcatalogImg/FirstPageImg/{0}", filename);
        //                    Pic1 = Paths;
        //                    if (Directory.Exists(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/")) == false)//如果不存在就创建file文件夹
        //                    {
        //                        Directory.CreateDirectory(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/"));
        //                    }
        //                    file.SaveAs(this.Server.MapPath("~" + Paths));
        //                }
        //            }
        //            else
        //            {
        //                if (!CheckImg(avatar, 3))
        //                {
        //                    //return Json(new { success = 3,imgname= Request.Files.AllKeys[i-1]}, JsonRequestBehavior.AllowGet);
        //                    // imgname = Request.Files.AllKeys[i - 1];
        //                    imgnamearray.Add(new UrlNameModel() { id = (i - 1), imgname = Request.Files.AllKeys[i - 1] });
        //                }
        //                else
        //                {
        //                    //    model.ProductSmallPicture = Libraries.SaveFile.SaveUploadedFile(avatar, dirPath, "");
        //                    var extension = avatar.FileName.Substring(avatar.FileName.LastIndexOf('.'));//原文件扩展名
        //                    string filename = "";
        //                    if (name != "")
        //                        filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + avatar.ContentLength.ToString() + extension;//新文件名称
        //                    string imgurl = "/SiemensEcatalogImg/FirstPageImg/" + filename;
        //                    array.Add(new FileUrlModel() { id = (i - 1), fileurl = imgurl });
        //                    var file = Request.Files[fname];
        //                    string Paths = string.Format("/SiemensEcatalogImg/FirstPageImg/{0}", filename);
        //                    Pic1 = Paths;
        //                    if (Directory.Exists(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/")) == false)//如果不存在就创建file文件夹
        //                    {
        //                        Directory.CreateDirectory(Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/"));
        //                    }
        //                    file.SaveAs(this.Server.MapPath("~" + Paths));
        //                }
        //            }
        //        }


        //    }
        //    if (imgnamearray.Count > 0)
        //    {
        //        return Json(new { success = 3, imgname = imgnamearray }, JsonRequestBehavior.AllowGet);

        //    }
        //    else
        //    {
        //        return Json(new { success = 1, array = array }, JsonRequestBehavior.AllowGet);

        //    }

        //    //return Json(new { success = 1, array = array }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult DoSaveModel(List<FirstPageModel> model, List<FileUrlModel> array)
        //{
        //    Dictionary<string, string> myDic = new Dictionary<string, string>();
        //    var HistoryPageLst = WebApiClient.Get<ResultMessage<List<FirstPageModel>>>("api/FirstPage/TGetFirstPageData", myDic);
        //    for (int i = 0; i < model.Count; i++)
        //    {
        //        if (model[i].ImageUrl.IndexOf("/SiemensEcatalogImg/FirstPageImg/") >= 0)
        //        {
        //            if (Path.GetFileName(model[i].ImageUrl).IndexOf("/") >= 0)
        //            {
        //                model[i].ImageUrl = Path.GetFileName(model[i].ImageUrl).Substring(Path.GetFileName(model[i].ImageUrl).LastIndexOf("/"), (Path.GetFileName(model[i].ImageUrl).LastIndexOf("/").ToString().Length - 1));
        //            }
        //            else
        //            { model[i].ImageUrl = Path.GetFileName(model[i].ImageUrl); }

        //            // model[i].ImageUrl = Path.GetFileName(model[i].ImageUrl);
        //        }
        //        else
        //        {
        //            for (int j = 0; j < array.Count; j++)
        //            {
        //                if (i == array[j].id)
        //                {
        //                    if (Path.GetFileName(array[j].fileurl).IndexOf("/") >= 0)
        //                    {
        //                        model[i].ImageUrl = Path.GetFileName(array[j].fileurl).Substring(Path.GetFileName(array[j].fileurl).LastIndexOf("/"), (Path.GetFileName(array[j].fileurl).LastIndexOf("/").ToString().Length - 1));
        //                    }
        //                    else
        //                    { model[i].ImageUrl = Path.GetFileName(array[j].fileurl); }
        //                }
        //            }
        //        }
        //    }
        //    var result = WebApiClient.Post<ResultMessageModel, List<FirstPageModel>>("api/FirstPage/TInsertFirstPageData", model);
        //    if (result.Success == 0)
        //    {
        //        if (HistoryPageLst.Data.Count() > 0)
        //        {
        //            string dirPath = Server.MapPath("~/SiemensEcatalogImg/FirstPageImg/");
        //            if (array != null)
        //            {
        //                foreach (var item in array)
        //                {

        //                    if (!String.IsNullOrEmpty((HistoryPageLst.Data[item.id]).ImageUrl))
        //                    {
        //                        //将不用的文件删除
        //                        DirectoryInfo NewFolder = new DirectoryInfo(dirPath + (HistoryPageLst.Data[item.id]).ImageUrl);
        //                        if (System.IO.File.Exists(dirPath + (HistoryPageLst.Data[item.id]).ImageUrl))
        //                        {
        //                            //NewFolder.Delete(true);
        //                            System.IO.File.Delete(dirPath + (HistoryPageLst.Data[item.id]).ImageUrl);
        //                        }
        //                    }
        //                }
        //            }
        //            //    else
        //            //    { 
        //            //    foreach (var item in HistoryPageLst.Data)
        //            //    {
        //            //        if (!String.IsNullOrEmpty(item.ImageUrl))
        //            //        {
        //            //            //将不用的文件删除
        //            //            DirectoryInfo NewFolder = new DirectoryInfo(dirPath + item.ImageUrl);
        //            //            if (System.IO.File.Exists(dirPath + item.ImageUrl))
        //            //            {
        //            //                //NewFolder.Delete(true);
        //            //                System.IO.File.Delete(dirPath + item.ImageUrl);
        //            //            }
        //            //        }
        //            //    }
        //            //}
        //        }

        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        ///// <summary>
        ///// 验证图片长宽
        ///// </summary>
        ///// <returns></returns>
        //public bool CheckImg(HttpPostedFileBase avatar, int Type)//Type=1：头图16/9 Type=2：特色产品左一图8/9 Type=3：其他图 16/9
        //{
        //    //原型上是(137*120)
        //    Image img = Image.FromStream(avatar.InputStream);
        //    //if (img.Height <= 90 || img.Height >= 150 || img.Width <= 90 || img.Width >= 150)
        //    //{
        //    //    return false;
        //    //}

        //    if (Type == 1)
        //    {
        //        if ((float)(img.Width) / (float)(img.Height) <= 1.3 || (float)(img.Width) / (float)(img.Height) >= 2.2)//16:9
        //        {
        //            return false;
        //        }
        //    }
        //    if (Type == 2)
        //    {
        //        if ((float)(img.Width) / (float)(img.Height) <= 0.3 || (float)(img.Width) / (float)(img.Height) >= 1.3)//8:9
        //        {
        //            return false;
        //        }
        //    }
        //    if (Type == 3)
        //    {
        //        if ((float)(img.Width) / (float)(img.Height) <= 1.3 || (float)(img.Width) / (float)(img.Height) >= 2.2)//16:9
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        #endregion


        public ActionResult AddDeleteRow()
        {
            ViewBag.Message = "Your contact page.";
            var options = new List<Label>();
            options.Add(new Label() { LabelId = 11, LabelName = "New Request" });
            options.Add(new Label() { LabelId = 12, LabelName = "Reviewed" });
            options.Add(new Label() { LabelId = 13, LabelName = "Started" });


            //var list = db.Blogs.ToList();
            return View(options);
        }


    }
}






    