using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentScoreMvc.Models.EntityFramework;

namespace StudentScoreMvc.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Default
        //ekleme silme güncelleme ve listeleme yazılan yer controller
        DBMvcSchoolEntities db = new DBMvcSchoolEntities();
        public ActionResult Index()
        {
            var courses = db.TBLCOURSES.ToList();
            return View(courses);
        }

        //courseları alma
        [HttpGet]
        public ActionResult NewCourse()
        {
            return View();
        }
        //Yeni ders ekleme işlemi 
        [HttpPost]
        public ActionResult NewCourse(TBLCOURSES c)
        {
            db.TBLCOURSES.Add(c);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCourse(int id)
        {
            var course = db.TBLCOURSES.Find(id);
            db.TBLCOURSES.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //update ekranında düzenlemek istediğim metni getir
        public ActionResult BringCourse(int id)
        {
            var course = db.TBLCOURSES.Find(id);
            return View("BringCourse", course);

        }
        public ActionResult UpdateCourse(TBLCOURSES c)
        {
            var crs = db.TBLCOURSES.Find(c.COURSEID);
            crs.COURSENAME = c.COURSENAME;
            db.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}