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
    public class TrainingExcersisesController : Controller
    {
        private Entities db = new Entities();

        // GET: TrainingExcersises
        public ActionResult Index()
        {
            var trainingExcersises = db.TrainingExcersises.Include(t => t.Excersises).Include(t => t.Trainings).Include(t => t.TrainingSchemePartModels);
            return View(trainingExcersises.ToList());
        }

        public PartialViewResult ListForTraining(int Training, int TrainingSchemePart)
        {

            /*Načtení všech cvičení k tréninku*/
            var trainingExcersises = db.TrainingExcersises.Include(t => t.Excersises).Include(t => t.Trainings).Include(t => t.TrainingSchemePartModels);
            trainingExcersises = trainingExcersises.Where(t => t.Training == Training);
            trainingExcersises = trainingExcersises.Where(t => t.TrainingSchemePartModel == TrainingSchemePart);

            /*Odeslání hodnot tréninkové části a tréninku do view jako viewbag*/
            ViewBag.TrainingSchemePart = TrainingSchemePart;
            ViewBag.Training = Training;

            /*Načtení všech cvičení spadajících do tréninkové části*/
            var trainingschemeparts = db.TrainingSchemePartModels.Include(t => t.ExcersiseCategories).Where(t => t.Id == TrainingSchemePart).FirstOrDefault();
            var excersises = db.Excersises.Include(t => t.ExcersiseBelongsToCategory);
            List<Excersises> excersiselist = new List<Excersises>();

            foreach (Excersises excersise in excersises)
            {
                int i = 0;
                if (excersise.ExcersiseBelongsToCategory.Any(t => t.ExcersiseCategory == trainingschemeparts.ExcersiseCategory))
                {

                    excersiselist.Insert(i, new Excersises() { Id = excersise.Id, Description = excersise.Description, ExcersiseName = excersise.ExcersiseName, ShortDescript = excersise.ShortDescript });
                    i = i + 1;

                }

            }

            //excersises = excersiselist.ToDictionary(x=>x.Id , x => x );
            ViewBag.ExcersiseList = new SelectList(excersiselist, "Id", "ExcersiseName");

            return PartialView(trainingExcersises);
        }

        public PartialViewResult GetTrainingExcersises(int Training, int TrainingSchemePart, int? ExcersiseList)
        {
            if (ExcersiseList != null)
            {
                TrainingExcersises trainingExcersisesAdd = new TrainingExcersises();
                trainingExcersisesAdd.Training = Training;
                trainingExcersisesAdd.Excersise = ExcersiseList.Value;
                trainingExcersisesAdd.TrainingSchemePartModel = TrainingSchemePart;
                db.TrainingExcersises.Add(trainingExcersisesAdd);
                db.SaveChanges();

            }
            var trainingExcersises = db.TrainingExcersises.Include(t => t.Excersises).Include(t => t.Trainings).Include(t => t.TrainingSchemePartModels);
            trainingExcersises = trainingExcersises.Where(t => t.Training == Training);
            trainingExcersises = trainingExcersises.Where(t => t.TrainingSchemePartModel == TrainingSchemePart);
            ViewBag.TrainingSchemePart = TrainingSchemePart;
            ViewBag.Training = Training;
            return PartialView("_TrainingExcersisesList", trainingExcersises.ToList());
        }

        
        public PartialViewResult DeltTrainingExcersises(int Training, int TrainingSchemePart, int? excersise)
        {
            if (excersise != null)
            {
                TrainingExcersises te = db.TrainingExcersises.Find(excersise);
                db.TrainingExcersises.Remove(te);
                db.SaveChanges();

            }
            var trainingExcersises = db.TrainingExcersises.Include(t => t.Excersises).Include(t => t.Trainings).Include(t => t.TrainingSchemePartModels);
            trainingExcersises = trainingExcersises.Where(t => t.Training == Training);
            trainingExcersises = trainingExcersises.Where(t => t.TrainingSchemePartModel == TrainingSchemePart);
            ViewBag.TrainingSchemePart = TrainingSchemePart;
            ViewBag.Training = Training;
            return PartialView("_TrainingExcersisesList", trainingExcersises.ToList());
        }

        // GET: TrainingExcersises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingExcersises trainingExcersises = db.TrainingExcersises.Find(id);
            if (trainingExcersises == null)
            {
                return HttpNotFound();
            }
            return View(trainingExcersises);
        }

        // GET: TrainingExcersises/Create
        public ActionResult Create()
        {
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName");
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id");
            ViewBag.TrainingSchemePartModel = new SelectList(db.TrainingSchemePartModels, "Id", "ExcersiseCategories.ExcersiseCategoryName");
            return View();
        }

        // POST: TrainingExcersises/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Training,Excersise,TrainingSchemePartModel")] TrainingExcersises trainingExcersises)
        {
            if (ModelState.IsValid)
            {
                db.TrainingExcersises.Add(trainingExcersises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", trainingExcersises.Excersise);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", trainingExcersises.Training);
            ViewBag.TrainingSchemePartModel = new SelectList(db.TrainingSchemePartModels, "Id", "PartLength", trainingExcersises.TrainingSchemePartModel);
            return View(trainingExcersises);
        }

        // GET: TrainingExcersises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingExcersises trainingExcersises = db.TrainingExcersises.Find(id);
            if (trainingExcersises == null)
            {
                return HttpNotFound();
            }
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", trainingExcersises.Excersise);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", trainingExcersises.Training);
            ViewBag.TrainingSchemePartModel = new SelectList(db.TrainingSchemePartModels, "Id", "PartLength", trainingExcersises.TrainingSchemePartModel);
            return View(trainingExcersises);
        }

        // POST: TrainingExcersises/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Training,Excersise,TrainingSchemePartModel")] TrainingExcersises trainingExcersises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingExcersises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Excersise = new SelectList(db.Excersises, "Id", "ExcersiseName", trainingExcersises.Excersise);
            ViewBag.Training = new SelectList(db.Trainings, "Id", "Id", trainingExcersises.Training);
            ViewBag.TrainingSchemePartModel = new SelectList(db.TrainingSchemePartModels, "Id", "PartLength", trainingExcersises.TrainingSchemePartModel);
            return View(trainingExcersises);
        }

        // GET: TrainingExcersises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingExcersises trainingExcersises = db.TrainingExcersises.Find(id);
            if (trainingExcersises == null)
            {
                return HttpNotFound();
            }
            return View(trainingExcersises);
        }

        // POST: TrainingExcersises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingExcersises trainingExcersises = db.TrainingExcersises.Find(id);
            db.TrainingExcersises.Remove(trainingExcersises);
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
