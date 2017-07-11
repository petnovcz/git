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
    public class ExcersiseBelongsToCategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: ExcersiseBelongsToCategories
        public ActionResult Index()
        {
            var excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Include(e => e.ExcersiseCategories).Include(e => e.Excersises);
            return View(excersiseBelongsToCategory.ToList());
        }

        // GET: ExcersiseBelongsToCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToCategory excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Find(id);
            if (excersiseBelongsToCategory == null)
            {
                return HttpNotFound();
            }
            return View(excersiseBelongsToCategory);
        }

        // GET: ExcersiseBelongsToCategories/Create
        public ActionResult Create()
        {
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName");
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName");
            return View();
        }

        // POST: ExcersiseBelongsToCategories/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Excersise,ExcersiseCategory")] ExcersiseBelongsToCategory excersiseBelongsToCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExcersiseBelongsToCategory.Add(excersiseBelongsToCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", excersiseBelongsToCategory.ExcersiseCategory);
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToCategory.Excersise);
            return View(excersiseBelongsToCategory);
        }

        // GET: ExcersiseBelongsToCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToCategory excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Find(id);
            if (excersiseBelongsToCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", excersiseBelongsToCategory.ExcersiseCategory);
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToCategory.Excersise);
            return View(excersiseBelongsToCategory);
        }

        // POST: ExcersiseBelongsToCategories/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Excersise,ExcersiseCategory")] ExcersiseBelongsToCategory excersiseBelongsToCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excersiseBelongsToCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExcersiseCategory = new SelectList(db.ExcersiseCategories, "Id", "ExcersiseCategoryName", excersiseBelongsToCategory.ExcersiseCategory);
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", excersiseBelongsToCategory.Excersise);
            return View(excersiseBelongsToCategory);
        }

        // GET: ExcersiseBelongsToCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseBelongsToCategory excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Find(id);
            if (excersiseBelongsToCategory == null)
            {
                return HttpNotFound();
            }
            return View(excersiseBelongsToCategory);
        }

        // POST: ExcersiseBelongsToCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExcersiseBelongsToCategory excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Find(id);
            db.ExcersiseBelongsToCategory.Remove(excersiseBelongsToCategory);
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
