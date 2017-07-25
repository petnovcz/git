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
    public class PlayerSigningToTrainingsController : Controller
    {
        private Entities db = new Entities();

        // GET: PlayerSigningToTrainings
        public ActionResult Index()
        {
            var playerSigningToTrainings = db.PlayerSigningToTrainings.Include(p => p.Players).Include(p => p.Trainings);
            return View(playerSigningToTrainings.ToList());
        }

        public PartialViewResult List(int player, int training, int team, bool? status)
        {
            if (status != null)
            {
                var exists = db.PlayerSigningToTrainings.Where(t=> t.Player == player).Where(t=>t.Training == training).FirstOrDefault();
                
                if (exists != null && exists.Status != status)
                {
                    var Id = exists.Id;
                    //update entity a save
                    PlayerSigningToTrainings edit = db.PlayerSigningToTrainings.Find(Id);
                    edit.Status = status.Value;
                    edit.SignedDate = DateTime.Now;
                    db.Entry(edit).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (exists == null)
                {
                    PlayerSigningToTrainings add = new PlayerSigningToTrainings();
                    add.Player = player;
                    add.Training = training;
                    add.Status = status.Value;
                    add.SignedDate = DateTime.Now;
                    db.PlayerSigningToTrainings.Add(add);
                    db.SaveChanges();
                }
            }
            var playerSigningToTrainings = db.PlayerSigningToTrainings.Include(p => p.Players).Include(p => p.Trainings);
            playerSigningToTrainings = playerSigningToTrainings.Where(t => t.Player == player).Where(t => t.Training == training);
            ViewBag.player = player;
            ViewBag.training = training;
            if (playerSigningToTrainings.Count() != 0)
                    {
                        if (playerSigningToTrainings.FirstOrDefault().Status == true)
                        {
                            ViewBag.Jdu = true;
                            ViewBag.Nejdu = false;
                        }
                        if (playerSigningToTrainings.FirstOrDefault().Status == false)
                        {
                            ViewBag.Jdu = false;
                            ViewBag.Nejdu = true;
                        }
            }
            ViewBag.Team = team;
                return PartialView(playerSigningToTrainings.FirstOrDefault());
        }

        // GET: PlayerSigningToTrainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerSigningToTrainings playerSigningToTrainings = db.PlayerSigningToTrainings.Find(id);
            if (playerSigningToTrainings == null)
            {
                return HttpNotFound();
            }
            return View(playerSigningToTrainings);
        }

        // GET: PlayerSigningToTrainings/Create
        public ActionResult Create()
        {
            ViewBag.Player = new SelectList(db.Players, "Id", "Name");
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id");
            return View();
        }

        // POST: PlayerSigningToTrainings/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Training,Player,Status,PlayerSignedDate,SignedDate ")] PlayerSigningToTrainings playerSigningToTrainings)
        {
            if (ModelState.IsValid)
            {
                db.PlayerSigningToTrainings.Add(playerSigningToTrainings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Player = new SelectList(db.Players, "Id", "Name", playerSigningToTrainings.Player);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", playerSigningToTrainings.Training);
            return View(playerSigningToTrainings);
        }

        // GET: PlayerSigningToTrainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerSigningToTrainings playerSigningToTrainings = db.PlayerSigningToTrainings.Find(id);
            if (playerSigningToTrainings == null)
            {
                return HttpNotFound();
            }
            ViewBag.Player = new SelectList(db.Players, "Id", "Name", playerSigningToTrainings.Player);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", playerSigningToTrainings.Training);
            return View(playerSigningToTrainings);
        }

        // POST: PlayerSigningToTrainings/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Training,Player,Status,PlayerSignedDate, SignedDate")] PlayerSigningToTrainings playerSigningToTrainings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerSigningToTrainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Player = new SelectList(db.Players, "Id", "Name", playerSigningToTrainings.Player);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", playerSigningToTrainings.Training);
            return View(playerSigningToTrainings);
        }

        // GET: PlayerSigningToTrainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerSigningToTrainings playerSigningToTrainings = db.PlayerSigningToTrainings.Find(id);
            if (playerSigningToTrainings == null)
            {
                return HttpNotFound();
            }
            return View(playerSigningToTrainings);
        }

        // POST: PlayerSigningToTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerSigningToTrainings playerSigningToTrainings = db.PlayerSigningToTrainings.Find(id);
            db.PlayerSigningToTrainings.Remove(playerSigningToTrainings);
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
