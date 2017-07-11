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
    public class PlayerFunctionsController : Controller
    {
        private Entities db = new Entities();

        // GET: PlayerFunctions
        public ActionResult Index()
        {
            return View(db.PlayerFunctions.ToList());
        }

        // GET: PlayerFunctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFunctions playerFunctions = db.PlayerFunctions.Find(id);
            if (playerFunctions == null)
            {
                return HttpNotFound();
            }
            return View(playerFunctions);
        }

        // GET: PlayerFunctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerFunctions/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlayerFunctionName,IsPlayer,IsGoalie,IsTrainer,IsManager")] PlayerFunctions playerFunctions)
        {
            if (ModelState.IsValid)
            {
                db.PlayerFunctions.Add(playerFunctions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playerFunctions);
        }

        // GET: PlayerFunctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFunctions playerFunctions = db.PlayerFunctions.Find(id);
            if (playerFunctions == null)
            {
                return HttpNotFound();
            }
            return View(playerFunctions);
        }

        // POST: PlayerFunctions/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlayerFunctionName,IsPlayer,IsGoalie,IsTrainer,IsManager")] PlayerFunctions playerFunctions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerFunctions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playerFunctions);
        }

        // GET: PlayerFunctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerFunctions playerFunctions = db.PlayerFunctions.Find(id);
            if (playerFunctions == null)
            {
                return HttpNotFound();
            }
            return View(playerFunctions);
        }

        // POST: PlayerFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerFunctions playerFunctions = db.PlayerFunctions.Find(id);
            db.PlayerFunctions.Remove(playerFunctions);
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
