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
    public class DepartmentTypesController : Controller
    {
        private schoolContext db = new schoolContext();

        // GET: DepartmentTypes
        public ActionResult Index()
        {
            return View(db.DepartmentTypes.ToList());
        }

        // GET: DepartmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTypes departmentTypes = db.DepartmentTypes.Find(id);
            if (departmentTypes == null)
            {
                return HttpNotFound();
            }
            return View(departmentTypes);
        }

        // GET: DepartmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] DepartmentTypes departmentTypes)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentTypes.Add(departmentTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentTypes);
        }

        // GET: DepartmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTypes departmentTypes = db.DepartmentTypes.Find(id);
            if (departmentTypes == null)
            {
                return HttpNotFound();
            }
            return View(departmentTypes);
        }

        // POST: DepartmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] DepartmentTypes departmentTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentTypes);
        }

        // GET: DepartmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTypes departmentTypes = db.DepartmentTypes.Find(id);
            if (departmentTypes == null)
            {
                return HttpNotFound();
            }
            return View(departmentTypes);
        }

        // POST: DepartmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentTypes departmentTypes = db.DepartmentTypes.Find(id);
            db.DepartmentTypes.Remove(departmentTypes);
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
