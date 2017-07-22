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
    public class ExcersiseCategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: ExcersiseCategories
        public ActionResult Index()
        {
            return View(db.ExcersiseCategories.ToList());
        }

        public PartialViewResult CategoriesListForExcersises(int excersise)
        {
            var excersises = db.ExcersiseCategories;
            excersises.Include(t=>t.ExcersiseBelongsToCategory);
            ViewBag.ExcresiseId = excersise;
            //foreach (var c in excersises)
            //{
            //    c.ExcersiseBelongsToCategory.Where(x => x.Excersise == excersise);
            //}
            //excersises = excersises.Where(t => t.ExcersiseBelongsToCategory.Any(x => x.ExcersiseCategory == excersisecategories));

            return PartialView(excersises.ToList());
        }


        // GET: ExcersiseCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseCategories excersiseCategories = db.ExcersiseCategories.Find(id);
            if (excersiseCategories == null)
            {
                return HttpNotFound();
            }
            return View(excersiseCategories);
        }

        // GET: ExcersiseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExcersiseCategories/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExcersiseCategoryName")] ExcersiseCategories excersiseCategories)
        {
            if (ModelState.IsValid)
            {
                db.ExcersiseCategories.Add(excersiseCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excersiseCategories);
        }

        // GET: ExcersiseCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseCategories excersiseCategories = db.ExcersiseCategories.Find(id);
            if (excersiseCategories == null)
            {
                return HttpNotFound();
            }
            return View(excersiseCategories);
        }

        // POST: ExcersiseCategories/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExcersiseCategoryName")] ExcersiseCategories excersiseCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excersiseCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excersiseCategories);
        }

        // GET: ExcersiseCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcersiseCategories excersiseCategories = db.ExcersiseCategories.Find(id);
            if (excersiseCategories == null)
            {
                return HttpNotFound();
            }
            return View(excersiseCategories);
        }

        // POST: ExcersiseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExcersiseCategories excersiseCategories = db.ExcersiseCategories.Find(id);
            db.ExcersiseCategories.Remove(excersiseCategories);
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
