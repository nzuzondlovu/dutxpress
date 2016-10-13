using FinalDutExpressSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDutExpressSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize( Roles="Admin")]
        public ActionResult Index()
        {
            
            var courseList = new List<SelectListItem>();
            var courseQuery = from c in db.CourseModels select c;
            foreach (var m in courseQuery)
            {
                courseList.Add(new SelectListItem
                {
                    Value = m.CourseName
                    ,
                    Text = m.CourseName
                });
                ViewBag.CoursesList = courseList;
              

            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(CourseModel m)
        {
            if (ModelState.IsValid)
            {



                if (m.CourseName == "Information Technology")
                {
                    return RedirectToAction("Index", "Results");
                }
                if (m.CourseName == "Chemical Engineering")
                {
                    return RedirectToAction("Index1", "Results");
                }
                if (m.CourseName == "Social Science")
                {
                    return RedirectToAction("Index2", "Results");
                }
                if (m.CourseName == "Aerospace Studies")
                {
                    return RedirectToAction("Index3", "Results");
                }
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}