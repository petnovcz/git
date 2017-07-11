using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FloorballTrainingSessions;

namespace FloorballTrainingSessions.Views
{
    public class TrainingSchemePartModelsController : Controller
    {
        private Entities db = new Entities();

        // GET: TrainingSchemePartModels
        public ActionResult Index()
        {
            var trainingSchemePartModels = db.TrainingSchemePartModels.Include(t => t.ExcersiseCategories).Include(t => t.TrainingSchemeModels);
            return View(trainingSchemePartModels.ToList());
        }

        // GET: TrainingSchemePartModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemePartModels trainingSchemePartModels = db.TrainingSchemePartModels.Find(id);
            if (trainingSchemePartModels == null)
            {
                return HttpNotFound();
            }
            return View(trainingSchemePartModels);
        }

        // GET: TrainingSchemePartModels/Create
        public ActionResult Create()
        {
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName");
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName");
            return View();
        }

        // POST: TrainingSchemePartModels/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingSchemeModel,ExcersiseCategory,PartLength,NumberOfExcersises,Series,SeriesLength,RestBetweenSeries,RestBetweenExcersises")] TrainingSchemePartModels trainingSchemePartModels)
        {
            if (ModelState.IsValid)
            {
                db.TrainingSchemePartModels.Add(trainingSchemePartModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", trainingSchemePartModels.ExcersiseCategory);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainingSchemePartModels.TrainingSchemeModel);
            return View(trainingSchemePartModels);
        }

        // GET: TrainingSchemePartModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemePartModels trainingSchemePartModels = db.TrainingSchemePartModels.Find(id);
            if (trainingSchemePartModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", trainingSchemePartModels.ExcersiseCategory);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainingSchemePartModels.TrainingSchemeModel);
            return View(trainingSchemePartModels);
        }

        // POST: TrainingSchemePartModels/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingSchemeModel,ExcersiseCategory,PartLength,NumberOfExcersises,Series,SeriesLength,RestBetweenSeries,RestBetweenExcersises")] TrainingSchemePartModels trainingSchemePartModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingSchemePartModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", trainingSchemePartModels.ExcersiseCategory);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainingSchemePartModels.TrainingSchemeModel);
            return View(trainingSchemePartModels);
        }

        // GET: TrainingSchemePartModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemePartModels trainingSchemePartModels = db.TrainingSchemePartModels.Find(id);
            if (trainingSchemePartModels == null)
            {
                return HttpNotFound();
            }
            return View(trainingSchemePartModels);
        }

        // POST: TrainingSchemePartModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingSchemePartModels trainingSchemePartModels = db.TrainingSchemePartModels.Find(id);
            db.TrainingSchemePartModels.Remove(trainingSchemePartModels);
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
