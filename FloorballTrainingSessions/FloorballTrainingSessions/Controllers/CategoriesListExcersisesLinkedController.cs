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
        // GET: SeasonPartsListExcersisesLinked
        public ActionResult Index(int excersise, int? categoryparam)
        {
            if (categoryparam != null)
            {
                var count = db.ExcersiseBelongsToCategory.Where(t => t.Excersise == excersise).Where(t => t.ExcersiseCategory == categoryparam).Count();
                if (count > 0)
                {
                    ExcersiseBelongsToCategory excersiseBelongsToCategory = db.ExcersiseBelongsToCategory.Where(t => t.Excersise == excersise).Where(t => t.ExcersiseCategory == categoryparam).FirstOrDefault();
                    db.ExcersiseBelongsToCategory.Remove(excersiseBelongsToCategory);
                    db.SaveChanges();
                }
                if (count == 0)
                {
                    ExcersiseBelongsToCategory excersiseBelongsToCategory = new ExcersiseBelongsToCategory();
                    excersiseBelongsToCategory.Excersise = excersise;
                    excersiseBelongsToCategory.ExcersiseCategory = categoryparam.Value;

                    db.ExcersiseBelongsToCategory.Add(excersiseBelongsToCategory);
                    db.SaveChanges();
                }
            }
            var excersisecategories = db.ExcersiseCategories.ToList();
            CategoriesListExcersisesLinkedModel categorieslist = new CategoriesListExcersisesLinkedModel();
            List<CategoriesListExcersisesLinkedModel> categorieslists = new List<CategoriesListExcersisesLinkedModel>();
            var id = 0;
            foreach (ExcersiseCategories excersisecategory in excersisecategories)
            {

                var excersiselinked = db.ExcersiseBelongsToCategory.Where(t => t.Excersise == excersise).Where(t => t.ExcersiseCategory == excersisecategory.Id).Count();
                var linked = false;
                if (excersiselinked > 0) { linked = true; }
                if (excersiselinked == 0) { linked = false; }
                categorieslists.Insert(id, new CategoriesListExcersisesLinkedModel() { ExcersiseCategory = excersisecategory.Id, Excersise = excersise, Available = false, Linked = linked, ExcerciseCaegoryName = excersisecategory.ExcersiseCategoryName });
                id = id + 1;
            }
            return View(categorieslists);
        }

        public PartialViewResult categoriesajax(int excersise, int excersisecategory, string excersisecategoryname, bool linked)
        {
            CategoriesListExcersisesLinkedModel categorieslist = new CategoriesListExcersisesLinkedModel();
            categorieslist.ExcersiseCategory = excersisecategory;
            categorieslist.ExcerciseCaegoryName = excersisecategoryname;
            categorieslist.Excersise = excersise;
            categorieslist.Linked = linked;
            return PartialView("categoriesajax", categorieslist);
        }
    }
}