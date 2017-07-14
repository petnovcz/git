using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FloorballTrainingSessions
{
    public class AdminController : Controller
    {
        private Entities db = new Entities();

        public int GetPlayerID(string userid)
        {
            var players = db.Players.Where(t => (t.User == userid)).FirstOrDefault();
            return players.Id;
        }
        public string GetPlayerName(string userid)
        {
            var players = db.Players.Where(t => (t.User == userid)).FirstOrDefault();
            return players.Name;
        }
        public int GetActiveSeason()
        {
            var seasons = db.Seasons.Where(t => (t.IsActiveSeason == true)).FirstOrDefault();
            return seasons.Id;
        }
        public string GetSeasonName(int SeasonId)
        {
            var seasons = db.Seasons.Where(t => (t.Id == SeasonId)).FirstOrDefault();
            return seasons.SeasonName;
        }
        // GET: Admin
        public ActionResult Index(int? SeasonId)
        {
            AdminModel admins = new AdminModel();
            admins.CurrentUser = User.Identity.GetUserId();
            admins.CurrentPlayer = GetPlayerID(admins.CurrentUser);
            admins.CurrentPlayerName = GetPlayerName(admins.CurrentUser);
            admins.Seasons = db.Seasons.ToList();
            admins.ActiveSeason = GetActiveSeason();
            if (SeasonId != null) { admins.ActiveSeason = SeasonId.GetValueOrDefault(); };
            admins.ActiveSeasonName = GetSeasonName(admins.ActiveSeason);
            admins.Teamplayers = db.TeamPlayers.Where(t => (t.Season == admins.ActiveSeason && t.Player == admins.CurrentPlayer)).ToList();
            return View(admins);
        }
    }
}