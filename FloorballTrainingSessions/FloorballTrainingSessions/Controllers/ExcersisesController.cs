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
    public class ExcersisesController : Controller
    {
        private Entities db = new Entities();

        // GET: Excersises
        public ActionResult Index()
        {
            return View(db.Excersises.ToList());
        }

        // GET: Excersises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        // GET: Excersises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excersises/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExcersiseName,Description,Image")] Excersises excersises)
        {
            if (ModelState.IsValid)
            {
                db.Excersises.Add(excersises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excersises);
        }

        // GET: Excersises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        // POST: Excersises/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExcersiseName,Description,Image")] Excersises excersises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excersises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excersises);
        }

        // GET: Excersises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        // POST: Excersises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excersises excersises = db.Excersises.Find(id);
            db.Excersises.Remove(excersises);
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
