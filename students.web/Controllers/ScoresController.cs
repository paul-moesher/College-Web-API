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
    public class ScoresController : Controller
    {
        private schoolContext db = new schoolContext();

        // GET: Scores
        public ActionResult Index()
        {
            var scores = db.Scores.Include(s => s.ScoreTypes).Include(s => s.StudentClasses);
            return View(scores.ToList());
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.ScoreTypesID = new SelectList(db.ScoreTypes, "ID", "Type");
            ViewBag.StudentClassesID = new SelectList(db.StudentClasses, "ID", "ID");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ScoreTypesID,StudentClassesID,Description,DateAssigned,DateDue,DateSubmitted,PointsEarned,PointsPossible")] Scores scores)
        {
            if (ModelState.IsValid)
            {
                db.Scores.Add(scores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScoreTypesID = new SelectList(db.ScoreTypes, "ID", "Type", scores.ScoreTypesID);
            ViewBag.StudentClassesID = new SelectList(db.StudentClasses, "ID", "ID", scores.StudentClassesID);
            return View(scores);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScoreTypesID = new SelectList(db.ScoreTypes, "ID", "Type", scores.ScoreTypesID);
            ViewBag.StudentClassesID = new SelectList(db.StudentClasses, "ID", "ID", scores.StudentClassesID);
            return View(scores);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ScoreTypesID,StudentClassesID,Description,DateAssigned,DateDue,DateSubmitted,PointsEarned,PointsPossible")] Scores scores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScoreTypesID = new SelectList(db.ScoreTypes, "ID", "Type", scores.ScoreTypesID);
            ViewBag.StudentClassesID = new SelectList(db.StudentClasses, "ID", "ID", scores.StudentClassesID);
            return View(scores);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scores scores = db.Scores.Find(id);
            db.Scores.Remove(scores);
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
