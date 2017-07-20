using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FloorballTrainingSessions
{
    public class TrainingSchemeModelsController : Controller
    {
        private Entities db = new Entities();

        // GET: TrainingSchemeModels
        public ActionResult Index()
        {
            var trainingSchemeModels = db.TrainingSchemeModels.Include(t => t.SeasonParts);
            
            return View(trainingSchemeModels.ToList());
        }

        // GET: TrainingSchemeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemeModels trainingSchemeModels = db.TrainingSchemeModels.Find(id);
            if (trainingSchemeModels == null)
            {
                return HttpNotFound();
            }
            return View(trainingSchemeModels);
        }

        // GET: TrainingSchemeModels/Create
        public ActionResult Create()
        {
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            return View();
        }

        // POST: TrainingSchemeModels/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingSchemeName,SeasonPart")] TrainingSchemeModels trainingSchemeModels)
        {
            if (ModelState.IsValid)
            {
                db.TrainingSchemeModels.Add(trainingSchemeModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingSchemeModels.SeasonPart);
            return View(trainingSchemeModels);
        }

        // GET: TrainingSchemeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemeModels trainingSchemeModels = db.TrainingSchemeModels.Find(id);
            if (trainingSchemeModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingSchemeModels.SeasonPart);
            return View(trainingSchemeModels);
        }

        // POST: TrainingSchemeModels/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingSchemeName,SeasonPart")] TrainingSchemeModels trainingSchemeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingSchemeModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingSchemeModels.SeasonPart);
            return View(trainingSchemeModels);
        }

        // GET: TrainingSchemeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSchemeModels trainingSchemeModels = db.TrainingSchemeModels.Find(id);
            if (trainingSchemeModels == null)
            {
                return HttpNotFound();
            }
            return View(trainingSchemeModels);
        }

        // POST: TrainingSchemeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingSchemeModels trainingSchemeModels = db.TrainingSchemeModels.Find(id);
            db.TrainingSchemeModels.Remove(trainingSchemeModels);
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
