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
    public class OutcomesController : Controller
    {
        private Entities db = new Entities();

        // GET: Outcomes
        public ActionResult Index()
        {
            var outcomes = db.Outcomes.Include(o => o.Accounts).Include(o => o.OutcomeCategories).Include(o => o.Periods).Include(o => o.Years);
            return View(outcomes.ToList());
        }

        // GET: Outcomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcomes outcomes = db.Outcomes.Find(id);
            if (outcomes == null)
            {
                return HttpNotFound();
            }
            return View(outcomes);
        }

        // GET: Outcomes/Create
        public ActionResult Create()
        {
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName");
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName");
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName");
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName");
            return View();
        }

        // POST: Outcomes/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Account,Year,Period,OutcomeCategory,PlannedDate,PlannedAmount,RealDate,RealAmount,Closed")] Outcomes outcomes)
        {
            if (ModelState.IsValid)
            {
                db.Outcomes.Add(outcomes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", outcomes.Account);
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", outcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", outcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", outcomes.Year);
            return View(outcomes);
        }

        // GET: Outcomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcomes outcomes = db.Outcomes.Find(id);
            if (outcomes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", outcomes.Account);
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", outcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", outcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", outcomes.Year);
            return View(outcomes);
        }

        // POST: Outcomes/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Account,Year,Period,OutcomeCategory,PlannedDate,PlannedAmount,RealDate,RealAmount,Closed")] Outcomes outcomes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outcomes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = new SelectList(db.Accounts, "Id", "AccountName", outcomes.Account);
            ViewBag.OutcomeCategory = new SelectList(db.OutcomeCategories, "Id", "OutcomeCategoryName", outcomes.OutcomeCategory);
            ViewBag.Period = new SelectList(db.Periods, "Id", "PeriodName", outcomes.Period);
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", outcomes.Year);
            return View(outcomes);
        }

        // GET: Outcomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outcomes outcomes = db.Outcomes.Find(id);
            if (outcomes == null)
            {
                return HttpNotFound();
            }
            return View(outcomes);
        }

        // POST: Outcomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outcomes outcomes = db.Outcomes.Find(id);
            db.Outcomes.Remove(outcomes);
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
