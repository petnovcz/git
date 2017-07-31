using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMoney;

namespace MyMoney.Controllers
{
    public class OutcomeCategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: OutcomeCategories
        public ActionResult Index()
        {
            return View(db.OutcomeCategories.ToList());
        }

        // GET: OutcomeCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeCategories outcomeCategories = db.OutcomeCategories.Find(id);
            if (outcomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(outcomeCategories);
        }

        // GET: OutcomeCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OutcomeCategories/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OutcomeCategoryName")] OutcomeCategories outcomeCategories)
        {
            if (ModelState.IsValid)
            {
                db.OutcomeCategories.Add(outcomeCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outcomeCategories);
        }

        // GET: OutcomeCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeCategories outcomeCategories = db.OutcomeCategories.Find(id);
            if (outcomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(outcomeCategories);
        }

        // POST: OutcomeCategories/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OutcomeCategoryName")] OutcomeCategories outcomeCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outcomeCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outcomeCategories);
        }

        // GET: OutcomeCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomeCategories outcomeCategories = db.OutcomeCategories.Find(id);
            if (outcomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(outcomeCategories);
        }

        // POST: OutcomeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutcomeCategories outcomeCategories = db.OutcomeCategories.Find(id);
            db.OutcomeCategories.Remove(outcomeCategories);
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
