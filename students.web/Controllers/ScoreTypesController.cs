﻿using System;
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
    public class ScoreTypesController : Controller
    {
        private schoolContext db = new schoolContext();

        // GET: ScoreTypes
        public ActionResult Index()
        {
            return View(db.ScoreTypes.ToList());
        }

        // GET: ScoreTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreTypes scoreTypes = db.ScoreTypes.Find(id);
            if (scoreTypes == null)
            {
                return HttpNotFound();
            }
            return View(scoreTypes);
        }

        // GET: ScoreTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScoreTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ScoreTypes scoreTypes)
        {
            if (ModelState.IsValid)
            {
                db.ScoreTypes.Add(scoreTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoreTypes);
        }

        // GET: ScoreTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreTypes scoreTypes = db.ScoreTypes.Find(id);
            if (scoreTypes == null)
            {
                return HttpNotFound();
            }
            return View(scoreTypes);
        }

        // POST: ScoreTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] ScoreTypes scoreTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoreTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoreTypes);
        }

        // GET: ScoreTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreTypes scoreTypes = db.ScoreTypes.Find(id);
            if (scoreTypes == null)
            {
                return HttpNotFound();
            }
            return View(scoreTypes);
        }

        // POST: ScoreTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScoreTypes scoreTypes = db.ScoreTypes.Find(id);
            db.ScoreTypes.Remove(scoreTypes);
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
