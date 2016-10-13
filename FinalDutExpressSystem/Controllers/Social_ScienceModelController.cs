using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalDutExpressSystem.Models;

namespace FinalDutExpressSystem.Controllers
{
    [Authorize]
    public class Social_ScienceModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Social_ScienceModel
        public ActionResult Index(string searchString)
        {
            try
            {
                var student = from m in db.Social_ScienceModel
                              select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    student = student.Where(s => s.StudentNo.Contains(searchString));
                }
                return View(student);
            }
            catch
            {
                return RedirectToAction("Create", "itsModels");
            }
        }

        // GET: Social_ScienceModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social_ScienceModel social_ScienceModel = db.Social_ScienceModel.Find(id);
            if (social_ScienceModel == null)
            {
                return HttpNotFound();
            }
            return View(social_ScienceModel);
        }

        // GET: Social_ScienceModel/Create
        public ActionResult Create()
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

        // POST: Social_ScienceModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Course,StudentNo,Anthropology,Philosophy,Psychology,Sociology")] Social_ScienceModel social_ScienceModel)
        {
            if (ModelState.IsValid)
            {
                db.Social_ScienceModel.Add(social_ScienceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(social_ScienceModel);
        }

        // GET: Social_ScienceModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social_ScienceModel social_ScienceModel = db.Social_ScienceModel.Find(id);
            if (social_ScienceModel == null)
            {
                return HttpNotFound();
            }
            return View(social_ScienceModel);
        }

        // POST: Social_ScienceModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Course,StudentNo,Anthropology,Philosophy,Psychology,Sociology")] Social_ScienceModel social_ScienceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social_ScienceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(social_ScienceModel);
        }

        // GET: Social_ScienceModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social_ScienceModel social_ScienceModel = db.Social_ScienceModel.Find(id);
            if (social_ScienceModel == null)
            {
                return HttpNotFound();
            }
            return View(social_ScienceModel);
        }

        // POST: Social_ScienceModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Social_ScienceModel social_ScienceModel = db.Social_ScienceModel.Find(id);
            db.Social_ScienceModel.Remove(social_ScienceModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
