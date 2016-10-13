using FinalDutExpressSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDutExpressSystem.Controllers
{
    [Authorize]
    public class BlackboardController : Controller
    {
       

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Blackboard
        [Authorize]
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
                    return RedirectToAction("IT", "Blackboard");
                }
                if (m.CourseName == "Chemical Engineering")
                {
                    return RedirectToAction("ChemEng", "Blackboard");
                }
                if (m.CourseName == "Social Science")
                {
                    return RedirectToAction("SocialScience", "Blackboard");
                }
                if (m.CourseName == "Aerospace Studies")
                {
                    return RedirectToAction("Aerospace", "Blackboard");
                }
            }
            return View();
        }
        public ActionResult IT()
        {
            return View();
        }
        public ActionResult AeroSpace()
        {
            return View();
        }
        public ActionResult SocialScience()
        {
            return View();
        }
        public ActionResult ChemEng()
        {
            return View();
        }

    }
}