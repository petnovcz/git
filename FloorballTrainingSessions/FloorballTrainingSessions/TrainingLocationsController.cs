﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FloorballTrainingSessions
{
    public class TrainingLocationsController : Controller
    {
        private Entities db = new Entities();

        // GET: TrainingLocations
        public ActionResult Index()
        {
            return View(db.TrainingLocations.ToList());
        }

        // GET: TrainingLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingLocations trainingLocations = db.TrainingLocations.Find(id);
            if (trainingLocations == null)
            {
                return HttpNotFound();
            }
            return View(trainingLocations);
        }

        // GET: TrainingLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingLocations/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingLocationName,PricePerHour,Description,Inner")] TrainingLocations trainingLocations)
        {
            if (ModelState.IsValid)
            {
                db.TrainingLocations.Add(trainingLocations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingLocations);
        }

        // GET: TrainingLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingLocations trainingLocations = db.TrainingLocations.Find(id);
            if (trainingLocations == null)
            {
                return HttpNotFound();
            }
            return View(trainingLocations);
        }

        // POST: TrainingLocations/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingLocationName,PricePerHour,Description,Inner")] TrainingLocations trainingLocations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingLocations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingLocations);
        }

        // GET: TrainingLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingLocations trainingLocations = db.TrainingLocations.Find(id);
            if (trainingLocations == null)
            {
                return HttpNotFound();
            }
            return View(trainingLocations);
        }

        // POST: TrainingLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingLocations trainingLocations = db.TrainingLocations.Find(id);
            db.TrainingLocations.Remove(trainingLocations);
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
