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
    public class PeriodsController : Controller
    {
        private Entities db = new Entities();

        // GET: Periods
        public ActionResult Index()
        {
            var periods = db.Periods.Include(p => p.Years);
            return View(periods.ToList());
        }

        // GET: Periods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        // GET: Periods/Create
        public ActionResult Create()
        {
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName");
            return View();
        }

        // POST: Periods/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PeriodName,Year,Starts,Ends")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                db.Periods.Add(periods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", periods.Year);
            return View(periods);
        }

        // GET: Periods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", periods.Year);
            return View(periods);
        }

        // POST: Periods/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PeriodName,Year,Starts,Ends")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Year = new SelectList(db.Years, "Id", "YearName", periods.Year);
            return View(periods);
        }

        // GET: Periods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periods periods = db.Periods.Find(id);
            db.Periods.Remove(periods);
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
