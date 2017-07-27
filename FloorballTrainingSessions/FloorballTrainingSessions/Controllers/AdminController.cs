using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FloorballTrainingSessions.Controllers;

namespace FloorballTrainingSessions
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        //private Entities db = new Entities();
        protected PlayersController c = new PlayersController();
        protected AspNetUsersController a = new AspNetUsersController();
        protected SeasonsController s = new SeasonsController();
        protected TeamPlayersController tp = new TeamPlayersController();
        /*
        */

        // GET: Admin
        public ActionResult Index(int? SeasonId)
        {
            AdminModel admins = new AdminModel();
            admins.CurrentUser = a.AspNetUserByID(User.Identity.GetUserId());
            admins.CurrentPlayer = c.GetPlayerbyUserID(admins.CurrentUser.Id);
            admins.ActiveSeason = s.GetActiveSeason();
            if (SeasonId != null) { admins.ActiveSeason = s.GetSeasonByID(SeasonId.Value); };
            admins.Teamplayers = tp.GetTeamsForPlayerandSeason(admins.CurrentPlayer.Id, admins.ActiveSeason.Id);
            admins.Seasons = s.GetSeason();
            return View(admins);
        }
    }
}