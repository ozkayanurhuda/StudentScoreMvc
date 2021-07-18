using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentScoreMvc.Controllers
{
    public class CalculationTestController : Controller
    {
        // GET: CalculationTest
        public ActionResult Index(int number1=0, int number2=0)
        {
            int result = number1 + number2;
            //controller tarafındaki değerleri view tarafına taşır (İndex)
            ViewBag.rslt = result;
            return View();
        }
    }
}