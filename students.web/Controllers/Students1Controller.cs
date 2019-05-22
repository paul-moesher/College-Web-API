using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeDBEF.DAL;
using CollegeEFDB.Models;

namespace Students.Web
{
    public class Students1Controller : Controller
    {
        private schoolContext db = new schoolContext();

        // GET: Students1
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students1 students1 = db.Students.Find(id);
            if (students1 == null)
            {
                return HttpNotFound();
            }
            return View(students1);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FName,LName,SNN,Address,City,State,Zip,Phone")] Students1 students1)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students1);
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students1 students1 = db.Students.Find(id);
            if (students1 == null)
            {
                return HttpNotFound();
            }
            return View(students1);
        }

        // POST: Students1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FName,LName,SNN,Address,City,State,Zip,Phone")] Students1 students1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students1);
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students1 students1 = db.Students.Find(id);
            if (students1 == null)
            {
                return HttpNotFound();
            }
            return View(students1);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students1 students1 = db.Students.Find(id);
            db.Students.Remove(students1);
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
