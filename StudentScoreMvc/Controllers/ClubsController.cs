using StudentScoreMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentScoreMvc.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Clubs
        DBMvcSchoolEntities db = new DBMvcSchoolEntities();
        public ActionResult Index()
        {
            var clubs = db.TBLCLUBS.ToList();
            return View(clubs);
        }
        [HttpGet]
        public ActionResult NewClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClub(TBLCLUBS c2)
        {
            db.TBLCLUBS.Add(c2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteClub(int id)
        {
            var club = db.TBLCLUBS.Find(id);
            db.TBLCLUBS.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //önce getirip sonra güncelleme
        public ActionResult BringClub(int id)
        {
            var club = db.TBLCLUBS.Find(id);
            return View("BringClub", club);
        }

        public ActionResult UpdateClub(TBLCLUBS c2)
        {
            var clb = db.TBLCLUBS.Find(c2.CLUBID);
            clb.CLUBNAME = c2.CLUBNAME;
            db.SaveChanges();
            return RedirectToAction("Index", "Clubs");
        }
    }
}