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
    public class TeamPlayersController : Controller
    {
        private Entities db = new Entities();

        // GET: TeamPlayers
        public ActionResult Index()
        {
            var teamPlayers = db.TeamPlayers.Include(t => t.PlayerFunctions).Include(t => t.Players).Include(t => t.Seasons).Include(t => t.Teams);
            

            return View(teamPlayers.ToList());
        }
        public ActionResult List(int SeasonId, int TeamId)
        {
            var teamPlayers = db.TeamPlayers.Include(t => t.PlayerFunctions).Include(t => t.Players).Include(t => t.Seasons).Include(t => t.Teams).Where(t => (t.Season == SeasonId && t.Team == TeamId));
            ViewBag.SelectedTeam = TeamId;
            ViewBag.SelectedSeason = SeasonId;

            return View(teamPlayers.ToList());
        }

        // GET: TeamPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayers teamPlayers = db.TeamPlayers.Find(id);
            if (teamPlayers == null)
            {
                return HttpNotFound();
            }
            return View(teamPlayers);
        }

        // GET: TeamPlayers/Create
        public ActionResult Create(int SelectedTeam, int SelectedSeason)
        {
            ViewBag.PlayerFunction = new SelectList(db.PlayerFunctions, "Id", "PlayerFunctionName");
            ViewBag.Player = new SelectList(db.Players, "Id", "Name");
            ViewBag.Season = SelectedSeason;
            ViewBag.Team = SelectedTeam;
            return View();
        }

        // POST: TeamPlayers/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Team,Player,PlayerFunction,Season")] TeamPlayers teamPlayers)
        {
            if (ModelState.IsValid)
            {
                int SeasonId = teamPlayers.Season;
                int TeamId = teamPlayers.Team;
                db.TeamPlayers.Add(teamPlayers);
                db.SaveChanges();
                return RedirectToAction("List", new { SeasonId = SeasonId, TeamId = TeamId });
            }

            ViewBag.PlayerFunction = new SelectList(db.PlayerFunctions, "Id", "PlayerFunctionName", teamPlayers.PlayerFunction);
            ViewBag.Player = new SelectList(db.Players, "Id", "Name", teamPlayers.Player);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", teamPlayers.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", teamPlayers.Team);
            return View(teamPlayers);
        }

        // GET: TeamPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayers teamPlayers = db.TeamPlayers.Find(id);
            if (teamPlayers == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerFunction = new SelectList(db.PlayerFunctions, "Id", "PlayerFunctionName", teamPlayers.PlayerFunction);
            ViewBag.Player = new SelectList(db.Players, "Id", "Name", teamPlayers.Player);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", teamPlayers.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", teamPlayers.Team);
            return View(teamPlayers);
        }

        // POST: TeamPlayers/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Team,Player,PlayerFunction,Season")] TeamPlayers teamPlayers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamPlayers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerFunction = new SelectList(db.PlayerFunctions, "Id", "PlayerFunctionName", teamPlayers.PlayerFunction);
            ViewBag.Player = new SelectList(db.Players, "Id", "Name", teamPlayers.Player);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", teamPlayers.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", teamPlayers.Team);
            return View(teamPlayers);
        }

        // GET: TeamPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamPlayers teamPlayers = db.TeamPlayers.Find(id);
            if (teamPlayers == null)
            {
                return HttpNotFound();
            }
            return View(teamPlayers);
        }

        // POST: TeamPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamPlayers teamPlayers = db.TeamPlayers.Find(id);
            db.TeamPlayers.Remove(teamPlayers);
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
