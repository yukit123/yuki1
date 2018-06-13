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
    {
        private TestApplication1Context db = new TestApplication1Context();

        // GET: author2
        public ActionResult Index()
        {
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

        // POST: author2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Author_id,Name")] author2 author2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
