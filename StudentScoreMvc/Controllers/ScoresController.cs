using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentScoreMvc.Models.EntityFramework;
using StudentScoreMvc.Models;

namespace StudentScoreMvc.Controllers
{
    public class ScoresController : Controller
    {
        // GET: Scores
        DBMvcSchoolEntities db = new DBMvcSchoolEntities();
        public ActionResult Index()
        {
            var scores = db.TBLSCORES.ToList();
            return View(scores);
        }

        [HttpGet]
        public ActionResult NewScore()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewScore(TBLSCORES tbs)
        {
            db.TBLSCORES.Add(tbs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringScore(int id)
        {
            var score = db.TBLSCORES.Find(id);
            return View("BringScore", score);
        }
        [HttpPost]
        public ActionResult BringScore(Class1 model, TBLSCORES s, int EXAM1=0, int EXAM2=0, int EXAM3=0, int PROJECT=0)
        {
            if(model.operation=="CALCULATE")
            {
                int MEAN = (EXAM1 + EXAM2 + EXAM3 + PROJECT) / 4;
                ViewBag.mn = MEAN;
            }

            if(model.operation=="UPDATESCORE")
            {
                var exm = db.TBLSCORES.Find(s.SCOREID);
                exm.EXAM1 = s.EXAM1;
                exm.EXAM2 = s.EXAM2;
                exm.EXAM3 = s.EXAM3;
                exm.PROJECT = s.PROJECT;
                exm.MEAN = s.MEAN;
                db.SaveChanges();
                return RedirectToAction("Index", "Scores");
            }
            return View();
        }
    }
}