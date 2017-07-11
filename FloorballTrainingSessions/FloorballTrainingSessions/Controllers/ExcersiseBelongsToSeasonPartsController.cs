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
    public class ExcersiseBelongsToSeasonPartsController : Controller
    {
        private Entities db = new Entities();

        // GET: ExcersiseBelongsToSeasonParts
        public ActionResult Index()
        {
            var excersiseBelongsToSeasonParts = db.ExcersiseBelongsToSeasonParts.Include(e => e.Excersises).Include(e => e.SeasonParts);
            return View(excersiseBelongsToSeasonParts.ToList());
        }

        // GET: ExcersiseBelongsToSeasonParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts = db.ExcersiseBelongsToSeasonParts.Find(id);
            if (excersiseBelongsToSeasonParts == null)
            {
                return HttpNotFound();
            }
            return View(excersiseBelongsToSeasonParts);
        }

        // GET: ExcersiseBelongsToSeasonParts/Create
        public ActionResult Create()
        {
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName");
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            return View();
        }

        // POST: ExcersiseBelongsToSeasonParts/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Excersise,SeasonPart")] ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts)
        {
            if (ModelState.IsValid)
            {
                db.ExcersiseBelongsToSeasonParts.Add(excersiseBelongsToSeasonParts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToSeasonParts.Excersise);
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", excersiseBelongsToSeasonParts.SeasonPart);
            return View(excersiseBelongsToSeasonParts);
        }

        // GET: ExcersiseBelongsToSeasonParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts = db.ExcersiseBelongsToSeasonParts.Find(id);
            if (excersiseBelongsToSeasonParts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToSeasonParts.Excersise);
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", excersiseBelongsToSeasonParts.SeasonPart);
            return View(excersiseBelongsToSeasonParts);
        }

        // POST: ExcersiseBelongsToSeasonParts/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Excersise,SeasonPart")] ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excersiseBelongsToSeasonParts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToSeasonParts.Excersise);
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", excersiseBelongsToSeasonParts.SeasonPart);
            return View(excersiseBelongsToSeasonParts);
        }

        // GET: ExcersiseBelongsToSeasonParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts = db.ExcersiseBelongsToSeasonParts.Find(id);
            if (excersiseBelongsToSeasonParts == null)
            {
                return HttpNotFound();
            }
            return View(excersiseBelongsToSeasonParts);
        }

        // POST: ExcersiseBelongsToSeasonParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExcersiseBelongsToSeasonParts excersiseBelongsToSeasonParts = db.ExcersiseBelongsToSeasonParts.Find(id);
            db.ExcersiseBelongsToSeasonParts.Remove(excersiseBelongsToSeasonParts);
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
