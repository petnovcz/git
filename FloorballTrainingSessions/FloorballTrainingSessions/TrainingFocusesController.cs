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
    public class TrainingFocusesController : Controller
    {
        private Entities db = new Entities();

        // GET: TrainingFocuses
        public ActionResult Index()
        {
            var trainingFocuses = db.TrainingFocuses.Include(t => t.SeasonParts);
            return View(trainingFocuses.ToList());
        }

        // GET: TrainingFocuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingFocuses trainingFocuses = db.TrainingFocuses.Find(id);
            if (trainingFocuses == null)
            {
                return HttpNotFound();
            }
            return View(trainingFocuses);
        }

        // GET: TrainingFocuses/Create
        public ActionResult Create()
        {
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            return View();
        }

        // POST: TrainingFocuses/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingFocusName,SeasonPart")] TrainingFocuses trainingFocuses)
        {
            if (ModelState.IsValid)
            {
                db.TrainingFocuses.Add(trainingFocuses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingFocuses.SeasonPart);
            return View(trainingFocuses);
        }

        // GET: TrainingFocuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingFocuses trainingFocuses = db.TrainingFocuses.Find(id);
            if (trainingFocuses == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingFocuses.SeasonPart);
            return View(trainingFocuses);
        }

        // POST: TrainingFocuses/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingFocusName,SeasonPart")] TrainingFocuses trainingFocuses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingFocuses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainingFocuses.SeasonPart);
            return View(trainingFocuses);
        }

        // GET: TrainingFocuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingFocuses trainingFocuses = db.TrainingFocuses.Find(id);
            if (trainingFocuses == null)
            {
                return HttpNotFound();
            }
            return View(trainingFocuses);
        }

        // POST: TrainingFocuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingFocuses trainingFocuses = db.TrainingFocuses.Find(id);
            db.TrainingFocuses.Remove(trainingFocuses);
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
