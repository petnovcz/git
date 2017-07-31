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
    public class BudgetIncomesController : Controller
    {
        private Entities db = new Entities();

        // GET: BudgetIncomes
        public ActionResult Index()
        {
            var budgetIncomes = db.BudgetIncomes.Include(b => b.IncomeCategories).Include(b => b.Periods).Include(b => b.Years);
            return View(budgetIncomes.ToList());
        }

        // GET: BudgetIncomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetIncomes budgetIncomes = db.BudgetIncomes.Find(id);
            if (budgetIncomes == null)
            {
                return HttpNotFound();
            }
            return View(budgetIncomes);
        }

        // GET: BudgetIncomes/Create
        public ActionResult Create()
        {
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName");
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName");
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName");
            return View();
        }

        // POST: BudgetIncomes/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Period,IncomeCategory,Amount")] BudgetIncomes budgetIncomes)
        {
            if (ModelState.IsValid)
            {
                db.BudgetIncomes.Add(budgetIncomes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", budgetIncomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetIncomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetIncomes.Year);
            return View(budgetIncomes);
        }

        // GET: BudgetIncomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetIncomes budgetIncomes = db.BudgetIncomes.Find(id);
            if (budgetIncomes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", budgetIncomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetIncomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetIncomes.Year);
            return View(budgetIncomes);
        }

        // POST: BudgetIncomes/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Period,IncomeCategory,Amount")] BudgetIncomes budgetIncomes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetIncomes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", budgetIncomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", budgetIncomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", budgetIncomes.Year);
            return View(budgetIncomes);
        }

        // GET: BudgetIncomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetIncomes budgetIncomes = db.BudgetIncomes.Find(id);
            if (budgetIncomes == null)
            {
                return HttpNotFound();
            }
            return View(budgetIncomes);
        }

        // POST: BudgetIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetIncomes budgetIncomes = db.BudgetIncomes.Find(id);
            db.BudgetIncomes.Remove(budgetIncomes);
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
