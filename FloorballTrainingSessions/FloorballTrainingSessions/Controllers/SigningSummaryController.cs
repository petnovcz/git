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
    public partial class SigningSummaryController : Controller
    {
        private Entities db = new Entities();

        public PartialViewResult Result(int training, int team)
        {
            SigningSummary signingSummary = new SigningSummary();

            //var goalies = db.TeamPlayers.Where(t => t.Team == team).Include(t => t.PlayerFunctions).Where(t=>t.PlayerFunctions.IsGoalie == true);
            //var players = db.TeamPlayers.Where(t => t.Team == team).Include(t => t.PlayerFunctions).Where(t => t.PlayerFunctions.IsPlayer == true);
            //var trainers = db.TeamPlayers.Where(t => t.Team == team).Include(t => t.PlayerFunctions).Where(t => t.PlayerFunctions.IsTrainer == true || t.PlayerFunctions.IsManager == true);
            int goaliesin = 0;
            int playersin = 0;
            int trainersin = 0;
            int allin = 0;
            int goaliesout = 0;
            int playersout = 0;
            int trainersout = 0;
            int allout = 0;
            var signings = db.PlayerSigningToTrainings.Where(t => t.Training == training);

            foreach (PlayerSigningToTrainings s in signings)
            {
                if (db.TeamPlayers.Where(t => t.Team == team).Where(t => t.Player == s.Player).Include(t => t.PlayerFunctions).Where(t => t.PlayerFunctions.IsGoalie == true).Count() > 0)
                {
                    if (s.Status == true)
                    { goaliesin = goaliesin + 1; allin = allin + 1; }
                    else { goaliesout = goaliesout + 1; allout = allout + 1; }
                }
                if (db.TeamPlayers.Where(t => t.Team == team).Where(t => t.Player == s.Player).Include(t => t.PlayerFunctions).Where(t => t.PlayerFunctions.IsPlayer == true).Count() > 0)
                {
                    if (s.Status == true)
                    { playersin = playersin + 1; allin = allin + 1; }
                    else { playersout = playersout + 1; allout = allout + 1; }
                }
                if (db.TeamPlayers.Where(t => t.Team == team).Where(t => t.Player == s.Player).Include(t => t.PlayerFunctions).Where(t => t.PlayerFunctions.IsTrainer == true || t.PlayerFunctions.IsManager == true).Count() > 0)
                {
                    if (s.Status == true)
                    { trainersin = trainersin + 1;  }
                    else { trainersout = trainersout + 1;  }
                }

            }

            signingSummary.SignedInAll = allin;
            signingSummary.SignedOutAll = allout;
            signingSummary.SignedInG = goaliesin;
            signingSummary.SignedOutG = goaliesout;
            signingSummary.SignedInH = playersin;
            signingSummary.SignedOutH = playersout;
            signingSummary.SignedInV = trainersin;
            signingSummary.SignedOutV = trainersout;
            return PartialView(signingSummary);
        }
    }
}
