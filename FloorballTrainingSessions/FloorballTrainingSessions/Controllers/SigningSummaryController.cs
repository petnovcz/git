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

        public PartialViewResult Result(int training)
        {
            SigningSummary signingSummary = new SigningSummary();

            var teamplayerswithfunction = db.TeamPlayers.Where(t => t.PlayerFunctions.IsGoalie);
            var traigning = db.PlayerSigningToTrainings.Where(t => t.Training == training && t.Status == true);
            


            //signingSummary.SignedInAll = x;
                
                
            signingSummary.SignedOutAll = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == false)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsPlayer) == true || t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsGoalie) == true)
                .Count();
            signingSummary.SignedInG = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == true)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsGoalie) == true)
                .Count();
            signingSummary.SignedOutG = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == false)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsGoalie) == true)
                .Count();
            signingSummary.SignedInH = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == true)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsPlayer) == true)
                .Count();
            signingSummary.SignedOutH = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == false)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsPlayer) == true)
                .Count();
            signingSummary.SignedInV = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == true)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsTrainer) == true || t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsManager) == true)
                .Count();
            signingSummary.SignedOutV = db.PlayerSigningToTrainings
                .Where(t => t.Training == training)
                .Where(t => t.Status == false)
                .Where(t => t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsTrainer) == true|| t.Players.TeamPlayers.Any(p => p.PlayerFunctions.IsManager) == true)
                .Count();
            return PartialView(signingSummary);
        }
    }
}
