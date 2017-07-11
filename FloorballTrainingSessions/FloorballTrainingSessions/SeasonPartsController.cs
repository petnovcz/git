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
    public class SeasonPartsController : Controller
    {
        private Entities db = new Entities();

        // GET: SeasonParts
        public ActionResult Index()
        {
            return View(db.SeasonParts.ToList());
        }

        // GET: SeasonParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonParts seasonParts = db.SeasonParts.Find(id);
            if (seasonParts == null)
            {
                return HttpNotFound();
            }
            return View(seasonParts);
        }

        // GET: SeasonParts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeasonParts/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeasonPartName")] SeasonParts seasonParts)
        {
            if (ModelState.IsValid)
            {
                db.SeasonParts.Add(seasonParts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seasonParts);
        }

        // GET: SeasonParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonParts seasonParts = db.SeasonParts.Find(id);
            if (seasonParts == null)
            {
                return HttpNotFound();
            }
            return View(seasonParts);
        }

        // POST: SeasonParts/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeasonPartName")] SeasonParts seasonParts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasonParts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seasonParts);
        }

        // GET: SeasonParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonParts seasonParts = db.SeasonParts.Find(id);
            if (seasonParts == null)
            {
                return HttpNotFound();
            }
            return View(seasonParts);
        }

        // POST: SeasonParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeasonParts seasonParts = db.SeasonParts.Find(id);
            db.SeasonParts.Remove(seasonParts);
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
