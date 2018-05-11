using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthorsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Authors
        public ActionResult Index()
        {
            return View(db.Author.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,AuthorName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Author.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,AuthorName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Author.Find(id);
            db.Author.Remove(author);
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


        public ActionResult ApplyLeave()
        {
            DateTime today = DateTime.Today;

            le_leaveApplication le_leaveApplication = new le_leaveApplication();
            le_leaveApplication.EmployeeId = 1;
            le_leaveApplication.LeaveFrom = today;
            le_leaveApplication.LeaveTo = today;
            //le_leaveApplication.LeaveDurationDays = 3;

            return View(le_leaveApplication);
        }

        // POST: eClaim/le_leaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyLeave([Bind(Include = "Id,EmployeeId,LeaveType,LeaveFrom,LeaveTo,LeaveDurationDays")] le_leaveApplication le_leaveApplication)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                le_leaveApplication.LeaveDurationDays = (int)(le_leaveApplication.LeaveTo - le_leaveApplication.LeaveFrom).TotalDays + 1;
                le_leaveApplication.EmployeeId = 9;


                // minus weekend and public holidays.

                return View("ApplyLeavePreview", le_leaveApplication);

            }

            return View(le_leaveApplication);
        }

        public ActionResult DoSubmit()
        {
            le_leaveApplication le_leaveApplication = new le_leaveApplication();
            if (ModelState.IsValid)
            {
                le_leaveApplication.LeaveDurationDays = (int)(le_leaveApplication.LeaveTo - le_leaveApplication.LeaveFrom).TotalDays + 1;
                le_leaveApplication.EmployeeId = 9;


                // minus weekend and public holidays.

                return View("ApplyLeavePreview", le_leaveApplication);

            }

            return View("ApplyLeave");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyLeavePreview([Bind(Include = "Id,EmployeeId,LeaveType,LeaveFrom,LeaveTo,LeaveDurationDays")] le_leaveApplication le_leaveApplication)
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
    }
}
