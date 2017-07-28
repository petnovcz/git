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
    public class SeasonsController : Controller
    {
        private Entities db = new Entities();

        /// <summary>
        /// Gets season that is set up as active
        /// </summary>
        /// <returns>Seasons</returns>
        public Seasons GetActiveSeason()
        {
            var seasons = db.Seasons.Where(t => (t.IsActiveSeason == true)).FirstOrDefault();
            return seasons;
        }
        /// <summary>
        /// Gets season details based on SeasonID
        /// </summary>
        /// <returns>Seasons</returns>
        public Seasons GetSeasonByID(int SeasonId)
        {
            var seasons = db.Seasons.Where(t => (t.Id == SeasonId)).FirstOrDefault();
            return seasons;
        }
        /// <summary>
        /// Gets list of all seasons
        /// </summary>
        /// <returns>ICollection<Seasons></Seasons></returns>
        public ICollection<Seasons> GetSeason()
        {
            var seasons = db.Seasons.ToList();
            return seasons;
        }
        /// <summary>
        /// Gets list of all seasons where player is (player or goalie) or where player is (trainer or manager)
        /// </summary>
        /// <returns>ICollection<Seasons></Seasons></returns>
        public ICollection<Seasons> GetSeason(int player, bool? playerorgoalie, bool? trainerormanager)
        {

            var seasons = db.Seasons.Where(s => s.TeamPlayers.Any((tp=>tp.Player == player)));
            if (playerorgoalie != null)
            {
                seasons = seasons.Where(s => s.TeamPlayers
                .Any(tp => tp.Player == player && tp.PlayerFunctions.IsGoalie == playerorgoalie.Value || tp.PlayerFunctions.IsPlayer == playerorgoalie.Value));
            }
            if (trainerormanager != null)
            {
                seasons = seasons.Where(s => s.TeamPlayers
                .Any(tp => tp.Player == player && tp.PlayerFunctions.IsManager == trainerormanager.Value || tp.PlayerFunctions.IsTrainer == trainerormanager.Value));
            }
            


            return seasons.ToList();
        }





        // GET: Seasons
        public ActionResult Index()
        {
            return View(db.Seasons.ToList());
        }

        // GET: Seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // GET: Seasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seasons/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeasonName,IsActiveSeason")] Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                db.Seasons.Add(seasons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seasons);
        }

        // GET: Seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // POST: Seasons/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeasonName,IsActiveSeason")] Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seasons);
        }

        // GET: Seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seasons seasons = db.Seasons.Find(id);
            if (seasons == null)
            {
                return HttpNotFound();
            }
            return View(seasons);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seasons seasons = db.Seasons.Find(id);
            db.Seasons.Remove(seasons);
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
