using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FloorballTrainingSessions
{
    public class TrainingsController : Controller
    {
        private Entities db = new Entities();


        ///<summary>
        /// Function returnes set of trainings filtered by season.
        ///</summary>
        public static IQueryable<Trainings> FilterBySeason(IQueryable<Trainings> tr, int season)
        {
            if (season != 0)
            {
                tr = tr.Where(t => (t.Season == season));
            }
            return (tr);
        }
        ///<summary>
        /// Function returnes set of trainings filtered by team.
        ///</summary>
        public static IQueryable<Trainings> FilterByTeam(IQueryable<Trainings> tr, int team)
        {
            if (team != 0)
            {
                tr = tr.Where(t => t.Team == team);
            }
            return (tr);
        }
        ///<summary>
        /// Function returnes set of trainings filtered by unconditional parameter Season Part.
        ///</summary>
        public static IQueryable<Trainings> FilterBySeasonPart(IQueryable<Trainings> tr, int? seasonpart)
        {
            if (seasonpart != 0)
            {
                tr = tr.Where(t => t.SeasonPart == seasonpart);
            }
            return (tr);
        }
        ///<summary>
        /// Function returnes set of trainings filtered by unconditional parameter Training Focus.
        ///</summary>
        public static IQueryable<Trainings> FilterByTrainingFocus(IQueryable<Trainings> tr, int? trainingfocus)
        {
            if (trainingfocus != 0)
            {
                tr = tr.Where(t => t.TrainingFocus == trainingfocus);
            }
            return (tr);
        }
        ///<summary>
        /// Function returnes set of trainings filtered by traininglocation.
        ///</summary>
        public static IQueryable<Trainings> FilterByTrainingLocation(IQueryable<Trainings> tr, int? traininglocation)
        {
            if (traininglocation != 0)
            {
                tr = tr.Where(t => t.TrainingLocation == traininglocation);
            }
            return (tr);
        }
        ///<summary>
        /// Function returnes set of trainings filtered by Training Scheme Model.
        ///</summary>
        public static IQueryable<Trainings> FilterByTrainingSchemeModel(IQueryable<Trainings> tr, int? trainingschememodel)
        {
            if (trainingschememodel != 0)
            {
                tr = tr.Where(t => t.TrainingSchemeModel == trainingschememodel);
            }
            return (tr);
        }
        ///<summary>
        /// Generates select list values of Season Parts with zero value for filtering (no filter)
        ///</summary>
        public SelectList AddViewBagForSelectListOfSeasonPartsForFilter ()
        {
            var seasonparts = db.SeasonParts.ToList();
            seasonparts.Insert(0, new SeasonParts { Id = 0, SeasonPartName = "-- Vyber část sezóny --" });
            var seasonpartlist = new SelectList(seasonparts, "Id", "SeasonPartName");
            return (seasonpartlist);
        }

        ///<summary>
        /// Generates select list values of Training Focuses with zero value for filtering (no filter)
        ///</summary>
        public SelectList AddViewBagForSelectListOfTrainingFocusForFilter()
        {
           
            var trainingfocuses = db.TrainingFocuses.ToList();
            trainingfocuses.Insert(0, new TrainingFocuses { Id = 0, TrainingFocusName = "-- Vyber tréninkové zaměření --" });
            var trainingfocuslist = new SelectList(trainingfocuses, "Id", "TrainingFocusName");
            return (trainingfocuslist);
        }
        ///<summary>
        /// Generates select list values of Training Location with zero value for filtering (no filter)
        ///</summary>
        public SelectList AddViewBagForSelectListOfTrainingLocationForFilter()
        {
            var traininglocations = db.TrainingLocations.ToList();
            traininglocations.Insert(0, new TrainingLocations { Id = 0, TrainingLocationName = "-- Vyber tréninkovou lokaci --" });
            var traininglocationlist = new SelectList(traininglocations, "Id", "TrainingLocationName");
            return (traininglocationlist);
        }
        ///<summary>
        /// Generates select list values of Training Scheme Model with zero value for filtering (no filter)
        ///</summary>
        public SelectList AddViewBagForSelectListOfTrainingSchemeModelForFilter()
        {
            var trainingschememodels = db.TrainingSchemeModels.ToList();
            trainingschememodels.Insert(0, new TrainingSchemeModels { Id = 0, TrainingSchemeName = "-- Vyber tréninkové schéma --" });
            var trainingschememodelslist = new SelectList(trainingschememodels, "Id", "TrainingSchemeName");
            return (trainingschememodelslist);
        }

        // GET: Trainings
        public ActionResult Index(int season, int team, int? seasonpart, int? trainingfocus)
        {
            var trainings = db.Trainings.Include(t => t.SeasonParts).Include(t => t.Seasons).Include(t => t.Teams).Include(t => t.TrainingFocuses).Include(t => t.TrainingLocations).Include(t => t.TrainingSchemeModels);
            trainings = FilterBySeason(trainings, season);
            trainings = FilterByTeam(trainings, team);
            trainings = FilterBySeasonPart(trainings, seasonpart);
            trainings = FilterByTrainingFocus(trainings, trainingfocus);            
            trainings.OrderBy(t => t.TrainingDate);

            return View(trainings.ToList());
        }

        public ActionResult Getnext10Trainings(int season, int team)
        {
            var trainings = db.Trainings.Include(t => t.SeasonParts).Include(t => t.Seasons).Include(t => t.Teams).Include(t => t.TrainingFocuses).Include(t => t.TrainingLocations).Include(t => t.TrainingSchemeModels);
            trainings = trainings.Where(t => t.Season == season);
            trainings = trainings.Where(t => t.Team == team);
            trainings = trainings.Where(t => t.TrainingDate >= DateTime.Now);
            trainings = trainings.OrderBy(t => t.TrainingDate);
            trainings = trainings.Take(10);

            return View(trainings.ToList());
        }

        public ActionResult List(int selectedseason, int selectedteam)
        {
            var trainings = db.Trainings.Include(t => t.SeasonParts).Include(t => t.Seasons).Include(t => t.Teams).Include(t => t.TrainingFocuses).Include(t => t.TrainingLocations).Include(t => t.TrainingSchemeModels);
            // filtrování na základě vstupního parametru - tým a sezóna
            trainings = FilterBySeason(trainings, selectedseason);
            trainings = FilterByTeam(trainings, selectedteam);
            
            // odeslání parametru vybrané sezóny a týmu do view
            ViewBag.selectedseason = selectedseason;
            ViewBag.selectedteam = selectedteam;
            // odeslání dat pro select list pro season part
            ViewBag.seasonpart = AddViewBagForSelectListOfSeasonPartsForFilter();
            // odeslání dat pro select list pro zaměření tréninku
            ViewBag.trainingfocus = AddViewBagForSelectListOfTrainingFocusForFilter();
            // odeslání dat pro select list pro tréninkovou lokaci
            ViewBag.traininglocation = AddViewBagForSelectListOfTrainingLocationForFilter();
            // odeslání dat pro selec list tréninkového modelu
            ViewBag.trainingschememodel = AddViewBagForSelectListOfTrainingSchemeModelForFilter();
            return View(trainings.Distinct().OrderBy(t => t.TrainingDate).ToList());
        }
        public PartialViewResult GetTrainings(int selectedseason, int selectedteam, int seasonpart, int traininglocation, int trainingfocus, int trainingschememodel)
        {
            var trainings = db.Trainings.Include(t => t.SeasonParts).Include(t => t.Seasons).Include(t => t.Teams).Include(t => t.TrainingFocuses).Include(t => t.TrainingLocations).Include(t => t.TrainingSchemeModels);
            trainings = FilterBySeason(trainings, selectedseason);
            trainings = FilterByTeam(trainings, selectedteam);
            trainings = FilterBySeasonPart(trainings, seasonpart);
            trainings = FilterByTrainingLocation(trainings, traininglocation);
            trainings = FilterByTrainingFocus(trainings, trainingfocus);
            trainings = FilterByTrainingSchemeModel(trainings, trainingschememodel);
            // odeslání parametru vybrané sezóny a týmu do view
            ViewBag.selectedseason = selectedseason;
            ViewBag.selectedteam = selectedteam;
            
            return PartialView("_TrainingsList", trainings.Distinct().OrderBy(t => t.TrainingDate).ToList());
        }
        // GET: Trainings/Details/5
        public PartialViewResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainings trainings = db.Trainings.Find(id);
            if (trainings == null)
            {
                //return HttpNotFound();
            }
            ViewBag.Id = trainings.Id;

            ViewBag.CurrentPlayer = GetPlayerID(User.Identity.GetUserId());
            return PartialView(trainings);
        }
        public int GetPlayerID(string userid)
        {
            var players = db.Players.Where(t => (t.User == userid)).FirstOrDefault();
            return players.Id;
        }

       

        // GET: Trainings/Create
        public ActionResult Create(int selectedseason, int selectedteam)
        {
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName");
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName");
            ViewBag.TrainingFocus = new SelectList(db.TrainingFocuses, "Id", "TrainingFocusName");            
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName");
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName");
            ViewBag.SelectedSeason = selectedseason;
            ViewBag.SelectedTeam = selectedteam;
            
            return View();
        }

        // POST: Trainings/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingDate,MeetDate,SigningLimitDate,TrainingLocation,Team,Season,SeasonPart,TrainingFocus,TrainingSchemeModel,TrainingLength,PublishTraining,PublishExcersises, TrainingClosed, TrainingCanceled, AttendanceClosed")] Trainings trainings)
        {
            if (ModelState.IsValid)
            {
                int SeasonId = trainings.Season;
                int TeamId = trainings.Team;
                db.Trainings.Add(trainings);
                db.SaveChanges();
                return RedirectToAction("List", new { selectedseason = SeasonId, selectedteam = TeamId });
            }

            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainings.SeasonPart);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", trainings.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", trainings.Team);
            ViewBag.TrainingFocus = new SelectList(db.TrainingFocuses, "Id", "TrainingFocusName", trainings.TrainingFocus);
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName", trainings.TrainingLocation);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainings.TrainingSchemeModel);
            return View(trainings);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id, int selectedseason, int selectedteam)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainings trainings = db.Trainings.Find(id);
            if (trainings == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainings.SeasonPart);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", trainings.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", trainings.Team);
            ViewBag.TrainingFocus = new SelectList(db.TrainingFocuses, "Id", "TrainingFocusName", trainings.TrainingFocus);
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName", trainings.TrainingLocation);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainings.TrainingSchemeModel);
            ViewBag.SelectedSeason = selectedseason;
            ViewBag.SelectedTeam = selectedteam;
            return View(trainings);
        }

        // POST: Trainings/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingDate,MeetDate,SigningLimitDate,TrainingLocation,Team,Season,SeasonPart,TrainingFocus,TrainingSchemeModel,TrainingLength,PublishTraining,PublishExcersises, TrainingClosed, TrainingCanceled, AttendanceClosed")] Trainings trainings)
        {
            if (ModelState.IsValid)
            {
                int SeasonId = trainings.Season;
                int TeamId = trainings.Team;
                db.Entry(trainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List", new { selectedseason = SeasonId, selectedteam = TeamId });
            }
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName", trainings.SeasonPart);
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName", trainings.Season);
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName", trainings.Team);
            ViewBag.TrainingFocus = new SelectList(db.TrainingFocuses, "Id", "TrainingFocusName", trainings.TrainingFocus);
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName", trainings.TrainingLocation);
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName", trainings.TrainingSchemeModel);
            return View(trainings);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id, int selectedseason, int selectedteam)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainings trainings = db.Trainings.Find(id);
            if (trainings == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedSeason = selectedseason;
            ViewBag.SelectedTeam = selectedteam;
            return View(trainings);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainings trainings = db.Trainings.Find(id);
            int SeasonId = trainings.Season;
            int TeamId = trainings.Team;
            db.Trainings.Remove(trainings);
            db.SaveChanges();
            return RedirectToAction("List", new { selectedseason = SeasonId, selectedteam = TeamId });
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
