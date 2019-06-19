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
    public class SampleTable02Controller : Controller
    {
        private sql_textConnectionString db = new sql_textConnectionString();

        // GET: SampleTable02
        public ActionResult Index()
        {
            return View(db.SampleTable02.ToList());
        }

        // GET: SampleTable02/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleTable02 sampleTable02 = db.SampleTable02.Find(id);
            if (sampleTable02 == null)
            {
                return HttpNotFound();
            }
            return View(sampleTable02);
        }

        // GET: SampleTable02/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleTable02/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SampleId,SampleName,SampleCategory,SampleDateTime,IsSampleProcessed")] SampleTable02 sampleTable02)
        {
            if (ModelState.IsValid)
            {
                db.SampleTable02.Add(sampleTable02);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sampleTable02);
        }

        // GET: SampleTable02/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleTable02 sampleTable02 = db.SampleTable02.Find(id);
            if (sampleTable02 == null)
            {
                return HttpNotFound();
            }
            return View(sampleTable02);
        }

        // POST: SampleTable02/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SampleId,SampleName,SampleCategory,SampleDateTime,IsSampleProcessed")] SampleTable02 sampleTable02)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sampleTable02).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sampleTable02);
        }

        // GET: SampleTable02/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleTable02 sampleTable02 = db.SampleTable02.Find(id);
            if (sampleTable02 == null)
            {
                return HttpNotFound();
            }
            return View(sampleTable02);
        }

        // POST: SampleTable02/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleTable02 sampleTable02 = db.SampleTable02.Find(id);
            db.SampleTable02.Remove(sampleTable02);
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
