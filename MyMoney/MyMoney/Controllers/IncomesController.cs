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
    public class IncomesController : Controller
    {
        private Entities db = new Entities();

        // GET: Incomes
        public ActionResult Index()
        {
            var incomes = db.Incomes.Include(i => i.Accounts).Include(i => i.IncomeCategories).Include(i => i.Periods).Include(i => i.Years);
            return View(incomes.ToList());
        }

        // GET: Incomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incomes incomes = db.Incomes.Find(id);
            if (incomes == null)
            {
                return HttpNotFound();
            }
            return View(incomes);
        }

        // GET: Incomes/Create
        public ActionResult Create()
        {
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName");
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName");
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName");
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName");
            return View();
        }

        // POST: Incomes/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Account,Year,Period,IncomeCategory,PlannedDate,PlannedAmount,RealDate,RealAmount,Closed")] Incomes incomes)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(incomes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", incomes.Account);
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", incomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", incomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", incomes.Year);
            return View(incomes);
        }

        // GET: Incomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incomes incomes = db.Incomes.Find(id);
            if (incomes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", incomes.Account);
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", incomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", incomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", incomes.Year);
            return View(incomes);
        }

        // POST: Incomes/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Account,Year,Period,IncomeCategory,PlannedDate,PlannedAmount,RealDate,RealAmount,Closed")] Incomes incomes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", incomes.Account);
            ViewBag.IncomeCategory = new SelectList(db.IncomeCategories, "Id", "IncomeCategoryName", incomes.IncomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", incomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", incomes.Year);
            return View(incomes);
        }

        // GET: Incomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incomes incomes = db.Incomes.Find(id);
            if (incomes == null)
            {
                return HttpNotFound();
            }
            return View(incomes);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incomes incomes = db.Incomes.Find(id);
            db.Incomes.Remove(incomes);
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
