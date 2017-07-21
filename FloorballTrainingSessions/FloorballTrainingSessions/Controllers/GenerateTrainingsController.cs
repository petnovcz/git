using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FloorballTrainingSessions
{
    public class GenerateTrainingsController : Controller
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
        
        public string GetSeasonName(int SeasonId)
        {
            var seasons = db.Seasons.Where(t => (t.Id == SeasonId)).FirstOrDefault();
            return seasons.SeasonName;
        }
        // GET: Admin
        /*public ActionResult Index(int SeasonId)
        {
            GenerateTrainings generatetrainings = new GenerateTrainings();
            generatetrainings.CurrentUser = User.Identity.GetUserId();
            generatetrainings.CurrentPlayer = GetPlayerID(generatetrainings.CurrentUser);
            generatetrainings.CurrentPlayerName = GetPlayerName(generatetrainings.CurrentUser);
            generatetrainings.SelectedSeason = SeasonId;
            if (SeasonId != null) { admins.ActiveSeason = SeasonId.GetValueOrDefault(); };
            admins.ActiveSeasonName = GetSeasonName(admins.ActiveSeason);
            admins.Teamplayers = db.TeamPlayers.Where(t => (t.Season == admins.ActiveSeason && t.Player == admins.CurrentPlayer)).ToList();
            return View(admins);
        }*/
        public ActionResult Create(int selectedseason, int selectedteam)
        {
            ViewBag.SelectedSeason = selectedseason;
            ViewBag.SelectedTeam = selectedteam;
            ViewBag.CurrentUser = User.Identity.GetUserId();
            ViewBag.CurrentPlayer = GetPlayerID(User.Identity.GetUserId());
            ViewBag.CurrentPlayerName = GetPlayerName(User.Identity.GetUserId());
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName");
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");            
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName");            
            List<DayInWeek> dayinweek = new List<DayInWeek>();
            dayinweek.Insert(0, new DayInWeek { day = 0, dayname = "Neděle" });
            dayinweek.Insert(1, new DayInWeek { day = 1, dayname = "Pondělí" });
            dayinweek.Insert(2, new DayInWeek { day = 2, dayname = "Úterý" });
            dayinweek.Insert(3, new DayInWeek { day = 3, dayname = "Středa" });
            dayinweek.Insert(4, new DayInWeek { day = 4, dayname = "Čtvrtek" });
            dayinweek.Insert(5, new DayInWeek { day = 5, dayname = "Pátek" });
            dayinweek.Insert(6, new DayInWeek { day = 6, dayname = "Sobota" });
            ViewBag.DayInWeek = new SelectList(dayinweek, "day", "dayname");

            return View();
        }

        // POST: Excersises/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrentUser,CurrentPlayer,CurrentPlayerName,SelectedSeason,SelectedSeasonName, SelectedTeam, SelectedTeamName, DateFrom, DateTo, dayinweek, SeasonPart, TrainingLocation, TrainingFocus, TrainingSchemeModel, TrainingLength, Weekday, SigningLimitDaysAhead, TrainingTime, SigningTime, MeetTime ")] GenerateTrainings generatetrainings)
        {
            if (ModelState.IsValid)
            {
                int interval = 1;
                DateTime startDate = generatetrainings.DateFrom;
                DateTime stopDate = generatetrainings.DateTo;
                while ((startDate = startDate.AddDays(interval)) <= stopDate)
                {
                    int week = Convert.ToInt32(startDate.DayOfWeek);
                    if (week == generatetrainings.dayinweek){
                        Trainings trainings = new Trainings();
                        trainings.Season = generatetrainings.SelectedSeason;
                        trainings.Team = generatetrainings.SelectedTeam;
                        DateTime trainingdate = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                    generatetrainings.TrainingTime.Hour, generatetrainings.TrainingTime.Minute, generatetrainings.TrainingTime.Second);
                        trainings.TrainingDate = trainingdate;
                        DateTime meetdate = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                    generatetrainings.MeetTime.Hour, generatetrainings.MeetTime.Minute, generatetrainings.MeetTime.Second);
                        trainings.MeetDate = meetdate;
                        DateTime signindate = new DateTime(startDate.Year, startDate.Month, startDate.Day,
                                    generatetrainings.SigningTime.Hour, generatetrainings.SigningTime.Minute, generatetrainings.SigningTime.Second);
                        signindate = signindate.AddDays(generatetrainings.SigningLimitDaysAhead);
                        trainings.SigningLimitDate = signindate;
                        trainings.TrainingLocation = generatetrainings.TrainingLocation;
                        trainings.SeasonPart = generatetrainings.SeasonPart;
                        trainings.TrainingFocus = generatetrainings.TrainingFocus;
                        trainings.TrainingLength = generatetrainings.TrainingLength;
                        trainings.TrainingSchemeModel = generatetrainings.TrainingSchemeModel;
                        db.Trainings.Add(trainings);
                        db.SaveChanges();
                        


                    }
                }
                return RedirectToAction("List", "Trainings", new { selectedseason = generatetrainings.SelectedSeason, selectedteam = generatetrainings.SelectedTeam });
            }
            ViewBag.SelectedSeason = generatetrainings.SelectedSeason;
            ViewBag.SelectedTeam = generatetrainings.SelectedTeam;
            ViewBag.CurrentUser = User.Identity.GetUserId();
            ViewBag.CurrentPlayer = GetPlayerID(User.Identity.GetUserId());
            ViewBag.CurrentPlayerName = GetPlayerName(User.Identity.GetUserId());
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName");
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName");
            List<DayInWeek> dayinweek = new List<DayInWeek>();
            dayinweek.Insert(0, new DayInWeek { day = 0, dayname = "Neděle" });
            dayinweek.Insert(1, new DayInWeek { day = 1, dayname = "Pondělí" });
            dayinweek.Insert(2, new DayInWeek { day = 2, dayname = "Úterý" });
            dayinweek.Insert(3, new DayInWeek { day = 3, dayname = "Středa" });
            dayinweek.Insert(4, new DayInWeek { day = 4, dayname = "Čtvrtek" });
            dayinweek.Insert(5, new DayInWeek { day = 5, dayname = "Pátek" });
            dayinweek.Insert(6, new DayInWeek { day = 6, dayname = "Sobota" });
            ViewBag.DayInWeek = new SelectList(dayinweek, "day", "dayname");
            return View(generatetrainings);
        }
    }
}