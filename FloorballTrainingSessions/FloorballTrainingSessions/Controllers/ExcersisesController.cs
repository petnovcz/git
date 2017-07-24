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
    public class ExcersisesController : Controller
    {
        private Entities db = new Entities();
        [AllowHtml]
        public string HtmlContent { get; set; }

        ///<summary>
        ///Returns list of excersises.
        ///</summary>
        public ActionResult Index()
        {

            return View(db.Excersises.ToList());
        }



        ///<summary>
        ///This is a description of my function.
        ///</summary>
        public ActionResult List()
        {
            var excersisecategories = db.ExcersiseCategories.ToList();
            excersisecategories.Insert(0, new ExcersiseCategories { Id = 0, ExcersiseCategoryName = "-- Vyber kategorii cvičení --" });
            ViewBag.excersisecategories = new SelectList(excersisecategories, "Id", "ExcersiseCategoryName");

            var seasonparts = db.SeasonParts.ToList();
            seasonparts.Insert(0, new SeasonParts { Id = 0, SeasonPartName = "-- Vyber část sezóny --" });
            ViewBag.seasonparts = new SelectList(seasonparts, "Id", "SeasonPartName");

            var excersises = db.Excersises.Include(t => t.ExcersiseBelongsToCategory).Include(t => t.ExcersiseBelongsToSeasonParts);


            return View(db.Excersises.ToList());
        }

        ///<summary>
        /// Function returnes set of excersises filtered by category.
        ///</summary>
        public static  IQueryable<Excersises> FilterByBelongsToCategory(IQueryable<Excersises> ex, int excersisecategories)
        {
            if (excersisecategories != 0)
            {
                ex = ex.Where(t => t.ExcersiseBelongsToCategory.Any(x => x.ExcersiseCategory == excersisecategories));
            }
            return (ex);
        }

        ///<summary>
        /// Function returnes set of excersises filtered by season pars.
        ///</summary>
        public static IQueryable<Excersises> FilterByBelongsToSeasonPart(IQueryable<Excersises> ex, int seasonparts)
        {
            if (seasonparts != 0)
            {
                ex = ex.Where(t => t.ExcersiseBelongsToSeasonParts.Any(x => x.SeasonPart == seasonparts));
            }
            return (ex);
        }

        ///<summary>
        /// Function returnes set of excersises filtered by season pars.
        ///</summary>
        public static IQueryable<Excersises> FilterByExcersiseNameConains(IQueryable<Excersises> ex, string excersisename)
        {
            if (excersisename != "")
            {
                ex = ex.Where(t => t.ExcersiseName.Contains(excersisename));
            }
            return (ex);
        }

        ///<summary>
        ///GetExcersises function returnes list of excersises filtered by parameters ordered by excersise name. Returns it to partial view.
        ///</summary>
        public PartialViewResult GetExcersises(int excersisecategories, int seasonparts, string excersisename)
        {
            var excersises = db.Excersises.Include(t => t.ExcersiseBelongsToCategory).Include(t => t.ExcersiseBelongsToSeasonParts);
            // provede otestování nenulové hodnoty parametru a filtrování dle excersisecategories
            excersises = FilterByBelongsToCategory(excersises, excersisecategories);
            // provede otestování nenulové hodnoty parametru a filtrování dle seasonparts
            excersises = FilterByBelongsToSeasonPart(excersises, seasonparts);
            // provede otestování nenulové hodnoty parametru a filtrování dle excersisename
            excersises = FilterByExcersiseNameConains(excersises, excersisename);

            return PartialView("_ExcersisesList", excersises.Distinct().OrderBy(t => t.ExcersiseName).ToList());
        }

        // GET: Excersises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        public PartialViewResult DetailsModal(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                //return HttpNotFound();
            }
            return PartialView(excersises);
        }

        // GET: Excersises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excersises/Create
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExcersiseName,Description,ShortDescript")] Excersises excersises)
        {
            if (ModelState.IsValid)
            {
                
                db.Excersises.Add(excersises);
                db.SaveChanges();
                int excersiseId = excersises.Id;
                return RedirectToAction("Details","Excersises", new { Id = excersiseId});
            }

            return View(excersises);
        }

        // GET: Excersises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        // POST: Excersises/Edit/5
        // Chcete-li zajistit ochranu před útoky typu OVERPOST, povolte konkrétní vlastnosti, k nimž chcete vytvořit vazbu. 
        // Další informace viz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExcersiseName,Description,ShortDescript")] Excersises excersises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excersises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excersises);
        }

        // GET: Excersises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excersises excersises = db.Excersises.Find(id);
            if (excersises == null)
            {
                return HttpNotFound();
            }
            return View(excersises);
        }

        // POST: Excersises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excersises excersises = db.Excersises.Find(id);
            db.Excersises.Remove(excersises);
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
