using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FloorballTrainingSessions
{
    public class MyTrainingsController : Controller
    {
        private Entities db = new Entities();
        // GET: MyTrainings
        public int GetPlayerID(string userid)
        {
            var players = db.Players.Where(t => (t.User == userid)).FirstOrDefault();
            return players.Id;
        }
        public ActionResult Index()
        {
            MyTrainingsModel mytrainings = new MyTrainingsModel();
            mytrainings.CurrentUser = User.Identity.GetUserId(); 
            mytrainings.CurrentPlayer = GetPlayerID(mytrainings.CurrentUser);
            mytrainings.Trainings = db.Trainings.ToList();
            return View(mytrainings);
        }
        
        // GET: MyTrainings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyTrainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTrainings/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyTrainings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyTrainings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyTrainings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyTrainings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
