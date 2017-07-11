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
    public class TrainingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Trainings
        public ActionResult Index()
        {
            var trainings = db.Trainings.Include(t => t.SeasonParts).Include(t => t.Seasons).Include(t => t.Teams).Include(t => t.TrainingFocuses).Include(t => t.TrainingLocations).Include(t => t.TrainingSchemeModels);
            return View(trainings.ToList());
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
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
            return View(trainings);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            ViewBag.SeasonPart = new SelectList(db.SeasonParts, "Id", "SeasonPartName");
            ViewBag.Season = new SelectList(db.Seasons, "Id", "SeasonName");
            ViewBag.Team = new SelectList(db.Teams, "Id", "TeamName");
            ViewBag.TrainingFocus = new SelectList(db.TrainingFocuses, "Id", "TrainingFocusName");
            ViewBag.TrainingLocation = new SelectList(db.TrainingLocations, "Id", "TrainingLocationName");
            ViewBag.TrainingSchemeModel = new SelectList(db.TrainingSchemeModels, "Id", "TrainingSchemeName");
            return View();
        }

        // POST: Trainings/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingDate,MeetDate,SigningLimitDate,TrainingLocation,Team,Season,SeasonPart,TrainingFocus,TrainingSchemeModel,TrainingLength,PublishTraining,PublishExcersises")] Trainings trainings)
        {
            if (ModelState.IsValid)
            {
                db.Trainings.Add(trainings);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Edit(int? id)
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
            return View(trainings);
        }

        // POST: Trainings/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingDate,MeetDate,SigningLimitDate,TrainingLocation,Team,Season,SeasonPart,TrainingFocus,TrainingSchemeModel,TrainingLength,PublishTraining,PublishExcersises")] Trainings trainings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Delete(int? id)
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
            return View(trainings);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainings trainings = db.Trainings.Find(id);
            db.Trainings.Remove(trainings);
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
