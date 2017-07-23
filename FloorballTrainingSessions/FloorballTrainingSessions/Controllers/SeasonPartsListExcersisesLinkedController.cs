using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloorballTrainingSessions
{
    public class SeasonPartsListExcersisesLinkedController : Controller
    {
        private Entities db = new Entities();
        // GET: SeasonPartsListExcersisesLinked
        public ActionResult Index(int excersise)
        {
            var seasonparts = db.SeasonParts.ToList();
            SeasonPartsListExcersisesLinkedModel seasonpartslist = new SeasonPartsListExcersisesLinkedModel();
            List<SeasonPartsListExcersisesLinkedModel> seasonpartslists = new List<SeasonPartsListExcersisesLinkedModel>();
            var id = 0;
            foreach (SeasonParts seasonpart in seasonparts)
            {

                var excersiselinked = db.ExcersiseBelongsToSeasonParts.Where(t => t.Excersise == excersise).Where(t => t.SeasonPart == seasonpart.Id).Count();
                var linked = false;
                if (excersiselinked > 0) { linked = true; }
                if (excersiselinked == 0) { linked = false; }
                seasonpartslists.Insert(id, new SeasonPartsListExcersisesLinkedModel() { SeasonPart = seasonpart.Id, Excersise = excersise, Available = false, Linked = linked, SeasonPartName = seasonpart.SeasonPartName });
                id = id + 1;
            }
            return View(seasonpartslists);
        }

        public PartialViewResult test(int excersise, int seasonpart, string seasonpartname, bool linked)
        {
            SeasonPartsListExcersisesLinkedModel seasonpartslist = new SeasonPartsListExcersisesLinkedModel();
            seasonpartslist.SeasonPart = seasonpart;
            seasonpartslist.SeasonPartName = seasonpartname;
            seasonpartslist.Excersise = excersise;
            seasonpartslist.Linked = linked;
            return PartialView("test", seasonpartslist);
        }
    }
}