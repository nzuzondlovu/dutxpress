using FinalDutExpressSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDutExpressSystem.Controllers
{

    public class popupController : Controller
    {
        // GET: popup
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Popup(string searchString)
        {
            try
            {
                var student = from m in db.itsModels
                              select m;
                var student1 = from m in db.itsModels
                               select m;
                var student2 = from m in db.itsModels
                               select m;
                var student3 = from m in db.itsModels
                               select m;


                if (!String.IsNullOrEmpty(searchString))
                {
                    student = student.Where(s => s.StudentNo.Contains(searchString));
                    student1 = student.Where(s => s.StudentNo.Contains(searchString));
                    student2 = student.Where(s => s.StudentNo.Contains(searchString));
                    student3 = student.Where(s => s.StudentNo.Contains(searchString));
                }
                return View(student);
            }
            catch
            {
                return RedirectToAction("Index", "PopupController");
            }


        }
        public ActionResult PopupWithParameters(string parent, int p1, string a, string b, int id)
        {
            ViewData["parent"] = parent;
            ViewData["p1"] = p1;
            ViewData["a"] = a;
            ViewData["b"] = b;
            ViewData["id"] = id;

            return PartialView();
        }
    }
}