using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloorballTrainingSessions
{
    public class CategoriesListExcersisesLinkedController : Controller
    {
        private Entities db = new Entities();
        // GET: CategoriesListExcersisesLinked
        public ActionResult Index(int excersises)
        {
            var excersisescategories = db.ExcersiseCategories;

            return View();
        }
    }
}