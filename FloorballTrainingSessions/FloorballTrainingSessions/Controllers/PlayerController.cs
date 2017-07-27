using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FloorballTrainingSessions.Models
{
    [Authorize]
    public class PlayerController : Controller
    {
        protected PlayersController c = new PlayersController();
        protected AspNetUsersController a = new AspNetUsersController();
        protected SeasonsController s = new SeasonsController();
        protected TeamPlayersController tp = new TeamPlayersController();
        protected TeamsController t = new TeamsController();

        public PlayerModel Main(int? SeasonId, int? TeamId)
        {
            PlayerModel p = new PlayerModel();
            p.CurrentUser = a.AspNetUserByID(User.Identity.GetUserId());
            p.CurrentPlayer = c.GetPlayerbyUserID(p.CurrentUser.Id);
            p.ActiveSeason = s.GetActiveSeason();
            if (SeasonId != null) { p.ActiveSeason = s.GetSeasonByID(SeasonId.Value); };
            p.CurrentPlayerTeams = tp.GetTeamsForPlayerandSeason(p.CurrentPlayer.Id, p.ActiveSeason.Id);
            p.Seasons = s.GetSeason();
            if (TeamId != null) { p.ActiveTeam = t.GetTeamById(TeamId.Value); }
            if (TeamId == null) { p.ActiveTeam = t.GetTeamById(p.CurrentPlayerTeams.FirstOrDefault().Teams.Id); }
            
                return p;

        }
        
        
        
        // GET: Player
        public ActionResult Index(int? SeasonId, int? TeamId)
        {
            PlayerModel p = new PlayerModel();
            p = Main(SeasonId,TeamId);

            return View(p);
        }
    }
}