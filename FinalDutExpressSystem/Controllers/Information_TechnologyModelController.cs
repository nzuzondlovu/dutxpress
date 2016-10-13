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
    public class Information_TechnologyModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Information_TechnologyModel
        public ActionResult Index(string searchString)
        {
            try
            {
                var student = from m in db.Information_TechnologyModel
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
        // GET: Information_TechnologyModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information_TechnologyModel information_TechnologyModel = db.Information_TechnologyModel.Find(id);
            if (information_TechnologyModel == null)
            {
                return HttpNotFound();
            }
            return View(information_TechnologyModel);
        }

        // GET: Information_TechnologyModel/Create
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
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CourseName,StudentNo,DS,TP,SS,IS")]
        Information_TechnologyModel information_TechnologyModel)
        {

            if (ModelState.IsValid)
            {
                

                db.Information_TechnologyModel.Add(information_TechnologyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(information_TechnologyModel);
        }

        // GET: Information_TechnologyModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information_TechnologyModel information_TechnologyModel = db.Information_TechnologyModel.Find(id);
            if (information_TechnologyModel == null)
            {
                return HttpNotFound();
            }
            return View(information_TechnologyModel);
        }

        // POST: Information_TechnologyModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CourseName,StudentNo,DS,TP,SS,IS")] Information_TechnologyModel information_TechnologyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(information_TechnologyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(information_TechnologyModel);
        }

        // GET: Information_TechnologyModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Information_TechnologyModel information_TechnologyModel = db.Information_TechnologyModel.Find(id);
            if (information_TechnologyModel == null)
            {
                return HttpNotFound();
            }
            return View(information_TechnologyModel);
        }

        // POST: Information_TechnologyModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Information_TechnologyModel information_TechnologyModel = db.Information_TechnologyModel.Find(id);
            db.Information_TechnologyModel.Remove(information_TechnologyModel);
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
