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
    public class IncomeCategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: IncomeCategories
        public ActionResult Index()
        {
            return View(db.IncomeCategories.ToList());
        }

        // GET: IncomeCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategories incomeCategories = db.IncomeCategories.Find(id);
            if (incomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(incomeCategories);
        }

        // GET: IncomeCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomeCategories/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IncomeCategoryName")] IncomeCategories incomeCategories)
        {
            if (ModelState.IsValid)
            {
                db.IncomeCategories.Add(incomeCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomeCategories);
        }

        // GET: IncomeCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategories incomeCategories = db.IncomeCategories.Find(id);
            if (incomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(incomeCategories);
        }

        // POST: IncomeCategories/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IncomeCategoryName")] IncomeCategories incomeCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomeCategories);
        }

        // GET: IncomeCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeCategories incomeCategories = db.IncomeCategories.Find(id);
            if (incomeCategories == null)
            {
                return HttpNotFound();
            }
            return View(incomeCategories);
        }

        // POST: IncomeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeCategories incomeCategories = db.IncomeCategories.Find(id);
            db.IncomeCategories.Remove(incomeCategories);
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
