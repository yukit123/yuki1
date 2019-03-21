using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApplication1.Models;

namespace TestApplication1.Controllers
{
    public class author2Controller : Controller
    {//https://www.codeproject.com/Tips/766214/List-Model-Binding-in-MVC
        //https://forums.asp.net/p/2148051/6234195.aspx?Re+How+to+Bind+SQL+foreign+key+column+to+dropdown+in+MVC+
        private TestApplication1Context db = new TestApplication1Context();

        // GET: author2
        public ActionResult Index()
        {
            var list=db.author2s.Where(s => s.book2.Any(x=>x.Publisher=="p1")).ToList();//2层数据 多对一



            ////list3.GroupBy(s => new { s.Text, s.keyword }, (key, group) => new { GroupName = key, Items = group.ToList() })
            //var onelist = db.author2s.ToList();
            //var manylist = db.book2s.ToList();
            ////onelist.GroupBy(s => new { s.Text, s.keyword }, (key, group) => new { GroupName = key, Items = group.ToList() })
            ////onelist.GroupBy(s=>s.Name,(key,goup)=>new{GroupName=key,Items=goup.ToList()})

            //onelist.GroupBy(s => s.book2.GroupBy(p => p.Author_id));
            //manylist.GroupBy(s => new { s.Title, s.Publisher }, (key, group) => new { GroupName = key, Items = group.ToList() });

            //var lresult7 = db.author2s
            //   .Join(db.book2s
            //      , orderdetail => orderdetail.Author_id
            //      , order => order.Author_id
            //      , (orderdetail, order) => new
            //      {
            //          order,
            //          orderdetail
            //      }).GroupBy(od => new
            //      {
            //          od.orderdetail.Author_id,
            //          od.order.Title
            //      })
            //      .OrderBy(d => d.Key.Title)
            //      .Select(grp => new
            //      {
            //          OrderNo = grp.Key.Title
            //      });

            return View(db.author2s.ToList());
        }

        // GET: author2/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author2 author2 = db.author2s.Find(id);
            if (author2 == null)
            {
                return HttpNotFound();
            }
            return View(author2);
        }

        // GET: author2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: author2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Author_id,Name")] author2 author2)
        {

            if (ModelState.IsValid)
            {
                author2.Author_id = Guid.NewGuid();
                db.author2s.Add(author2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author2);
        }

        // GET: author2/Edit/5
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Author_id = new SelectList(db.author2s, "Author_id", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            author2 author2 = db.author2s.Find(id);
            if (author2 == null)
            {
                return HttpNotFound();
            }
            return View(author2);
        }

        public JsonResult UpdateNtf(int? id, string status)
        {

      
            return Json(11, JsonRequestBehavior.AllowGet);

        }

        // POST: author2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Author_id,Name")]*/ author2 author2)//list model bind [Bind]会阻止显示一对多数据
        {

            author2 author22 = db.author2s.Find(author2.Author_id);

            //    if (ModelState.IsValid)
            //    {
            //        db.Entry(author2).State = EntityState.Modified;
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }

            //    else {
            //    var msg = string.Empty;
            //    foreach (var value in ModelState.Values)
            //    {
            //        if (value.Errors.Count > 0)
            //        {
            //            foreach (var error in value.Errors)
            //            {
            //                msg = msg + error.ErrorMessage;
            //            }
            //        }
            //    }
            //    ModelState.AddModelError(string.Empty, msg);//@Html.ValidationSummary

            //}

            return View(author2);
        }

        // GET: author2/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author2 author2 = db.author2s.Find(id);
            if (author2 == null)
            {
                return HttpNotFound();
            }
            return View(author2);
        }

        // POST: author2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            author2 author2 = db.author2s.Find(id);
            db.author2s.Remove(author2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
