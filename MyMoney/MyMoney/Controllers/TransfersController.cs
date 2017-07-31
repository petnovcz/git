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
    public class TransfersController : Controller
    {
        private Entities db = new Entities();

        // GET: Transfers
        public ActionResult Index()
        {
            var transfers = db.Transfers.Include(t => t.Accounts).Include(t => t.Accounts1);
            return View(transfers.ToList());
        }

        // GET: Transfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return HttpNotFound();
            }
            return View(transfers);
        }

        // GET: Transfers/Create
        public ActionResult Create()
        {
            ViewBag.AccountFrom = new SelectList(db.Accounts, "Id", "AccountName");
            ViewBag.AccountTo = new SelectList(db.Accounts, "Id", "AccountName");
            return View();
        }

        // POST: Transfers/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TransferDate,AccountFrom,AccountTo,Amount")] Transfers transfers)
        {
            if (ModelState.IsValid)
            {
                db.Transfers.Add(transfers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountFrom = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountFrom);
            ViewBag.AccountTo = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountTo);
            return View(transfers);
        }

        // GET: Transfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountFrom = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountFrom);
            ViewBag.AccountTo = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountTo);
            return View(transfers);
        }

        // POST: Transfers/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TransferDate,AccountFrom,AccountTo,Amount")] Transfers transfers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountFrom = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountFrom);
            ViewBag.AccountTo = new SelectList(db.Accounts, "Id", "AccountName", transfers.AccountTo);
            return View(transfers);
        }

        // GET: Transfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfers transfers = db.Transfers.Find(id);
            if (transfers == null)
            {
                return HttpNotFound();
            }
            return View(transfers);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfers transfers = db.Transfers.Find(id);
            db.Transfers.Remove(transfers);
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
