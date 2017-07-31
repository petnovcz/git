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
    public class BudgetOutcomesController : Controller
    {
        private Entities db = new Entities();

        // GET: BudgetOutcomes
        public ActionResult Index()
        {
            var budgetOutcomes = db.BudgetOutcomes.Include(b => b.OutcomeCategories).Include(b => b.Periods).Include(b => b.Years);
            return View(budgetOutcomes.ToList());
        }

        // GET: BudgetOutcomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetOutcomes budgetOutcomes = db.BudgetOutcomes.Find(id);
            if (budgetOutcomes == null)
            {
                return HttpNotFound();
            }
            return View(budgetOutcomes);
        }

        // GET: BudgetOutcomes/Create
        public ActionResult Create()
        {
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName");
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName");
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName");
            return View();
        }

        // POST: BudgetOutcomes/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Period,OutcomeCategory,Amount")] BudgetOutcomes budgetOutcomes)
        {
            if (ModelState.IsValid)
            {
                db.BudgetOutcomes.Add(budgetOutcomes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", budgetOutcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetOutcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetOutcomes.Year);
            return View(budgetOutcomes);
        }

        // GET: BudgetOutcomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetOutcomes budgetOutcomes = db.BudgetOutcomes.Find(id);
            if (budgetOutcomes == null)
            {
                return HttpNotFound();
            }
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", budgetOutcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetOutcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetOutcomes.Year);
            return View(budgetOutcomes);
        }

        // POST: BudgetOutcomes/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Period,OutcomeCategory,Amount")] BudgetOutcomes budgetOutcomes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetOutcomes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", budgetOutcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetOutcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetOutcomes.Year);
            return View(budgetOutcomes);
        }

        // GET: BudgetOutcomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetOutcomes budgetOutcomes = db.BudgetOutcomes.Find(id);
            if (budgetOutcomes == null)
            {
                return HttpNotFound();
            }
            return View(budgetOutcomes);
        }

        // POST: BudgetOutcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetOutcomes budgetOutcomes = db.BudgetOutcomes.Find(id);
            db.BudgetOutcomes.Remove(budgetOutcomes);
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
