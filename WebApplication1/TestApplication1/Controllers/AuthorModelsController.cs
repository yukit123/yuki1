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
    public class AuthorModelsController : Controller
    {
        private TestApplication1Context db = new TestApplication1Context();

        // GET: AuthorModels
        public ActionResult Index()
        {
            db.AuthorModels.Include("Books").ToList();
            return View(db.AuthorModels.ToList());
        }

        // GET: AuthorModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModel authorModel = db.AuthorModels.Find(id);
           // authorModel.Books = db.AuthorModels.Find(id);
            if (authorModel == null)
            {
                return HttpNotFound();
            }
            return View(authorModel);
        }
        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
 
        }
        // GET: AuthorModels/Create
        public ActionResult Create()
        {
            //AuthorViewModel vm = new AuthorViewModel();
            return View();
        }

        // POST: AuthorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AuthorModel authorModel)
        {
            if (ModelState.IsValid)
            {
                //AuthorModel model = new AuthorModel();
                //model.Name=authorModel.Name;
                db.AuthorModels.Add(authorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorModel);
        }

       

        // GET: AuthorModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModel authorModel = db.AuthorModels.Find(id);
           // authorModel.Books = db.AuthorModels.Include("Books");
            if (authorModel == null)
            {
                return HttpNotFound();
            }
            return View(authorModel);
        }

        // POST: AuthorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AuthorModel authorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorModel);
        }

        // GET: AuthorModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorModel authorModel = db.AuthorModels.Find(id);
            if (authorModel == null)
            {
                return HttpNotFound();
            }
            return View(authorModel);
        }

        // POST: AuthorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorModel authorModel = db.AuthorModels.Find(id);
            db.AuthorModels.Remove(authorModel);
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
