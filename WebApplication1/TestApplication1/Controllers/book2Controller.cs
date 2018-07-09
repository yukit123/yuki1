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
    public class book2Controller : Controller
    {
        private TestApplication1Context db = new TestApplication1Context();

        // GET: book2
        public ActionResult Index()
        {
            var book2s = db.book2s.Include(b => b.author2);
            return View(db.book2s.ToList());
        }

        public class bookvm
        {
            public List<book2> book2 { get; set; }
            public List<author2> author2 { get; set; }

        }
        public ActionResult IndexVm()//https://forums.asp.net/t/2143323.aspx
        {
            //var book2s = db.book2s.Include(b => b.author2);
            bookvm vm = new bookvm();
            vm.author2 = db.author2s.ToList();
            vm.book2 = db.book2s.ToList();
            return View(vm);
        }

        // GET: book2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book2 book2 = db.book2s.Find(id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            return View(book2);
        }

        // GET: book2/Create
        public ActionResult Create()
        {
            ViewBag.Author_id = new SelectList(db.author2s, "Author_id", "Name");
            return View();
        }

        // POST: book2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Publisher,Author_id")] book2 book2)
        {

      
            if (ModelState.IsValid)
            {
                db.book2s.Add(book2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Author_id = new SelectList(db.author2s, "Author_id", "Name", book2.Author_id);
            return View(book2);
        }

        // GET: book2/Edit/5
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book2 book2 = db.book2s.Find(Id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author_id = new SelectList(db.author2s, "Author_id", "Name", book2.Author_id);

            ViewBag.DDU = new SelectList(db.author2s,
                                   "Author_id",
                                   "Name",
                                   book2.Author_id);
            return View(book2);
        }

        //public ActionResult Edit(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DTUnit dTUnit = db.DTUnits.Find(Id);
        //    if (dTUnit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.DDU= new SelectList(db.DTUnits, "Id", "Units", dTUnit.Id);

        //    return View(dTUnit);
        //}

        // POST: book2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Publisher,Author_id")] book2 book2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author_id = new SelectList(db.author2s, "Author_id", "Name", book2.Author_id);
            return View(book2);
        }

        // GET: book2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book2 book2 = db.book2s.Find(id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            return View(book2);
        }

        // POST: book2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book2 book2 = db.book2s.Find(id);
            db.book2s.Remove(book2);
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
