using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentScoreMvc.Models.EntityFramework;

namespace StudentScoreMvc.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Student
        DBMvcSchoolEntities db = new DBMvcSchoolEntities();
        public ActionResult Index()
        {
            var students = db.TBLSTUDENTS.ToList();
            return View(students);
        }
        [HttpGet]
        public ActionResult NewStudent()
        {
            //for dropdown list 
            List<SelectListItem> values = (from i in db.TBLCLUBS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CLUBNAME,
                                               Value = i.CLUBID.ToString()
                                           }).ToList();
            ViewBag.val = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(TBLSTUDENTS s)
        {
            var clb = db.TBLCLUBS.Where(m => m.CLUBID == s.TBLCLUBS.CLUBID).FirstOrDefault();
            s.TBLCLUBS = clb;
            db.TBLSTUDENTS.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            var student = db.TBLSTUDENTS.Find(id);
            db.TBLSTUDENTS.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringStudent(int id)
        {
            var student = db.TBLSTUDENTS.Find(id);

            //for dropdown list 
            List<SelectListItem> values = (from i in db.TBLCLUBS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CLUBNAME,
                                               Value = i.CLUBID.ToString()
                                           }).ToList();
            ViewBag.val = values;
            return View("BringStudent", student);
        }
        public ActionResult UpdateStudent(TBLSTUDENTS s)
        {
            var stu = db.TBLSTUDENTS.Find(s.STUID);
            stu.STUNAME = s.STUNAME;
            stu.STUSURNAME = s.STUSURNAME;
            stu.STUPHOTO = s.STUPHOTO;
            stu.STUGENDER = s.STUGENDER;
            stu.STUCLUB = s.STUCLUB;
            db.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
    }
}