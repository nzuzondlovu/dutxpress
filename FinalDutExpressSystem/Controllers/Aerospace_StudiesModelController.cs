using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalDutExpressSystem.Models;
using Microsoft.AspNet.Identity;

namespace FinalDutExpressSystem.Controllers
{
    [Authorize]
    public class Aerospace_StudiesModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aerospace_StudiesModel
        public ActionResult Index(string searchString)
        {
            try
            {
                var student = from m in db.Aerospace_StudiesModel
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

        // GET: Aerospace_StudiesModel/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aerospace_StudiesModel aerospace_StudiesModel = db.Aerospace_StudiesModel.Find(id);
            if (aerospace_StudiesModel == null)
            {
                return HttpNotFound();
            }
            return View(aerospace_StudiesModel);
        }

        // GET: Aerospace_StudiesModel/Create
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
        // POST: Aerospace_StudiesModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CourseName,StudentNo,Communication_Skills,Aviation,Leadership_Studies,Security_Studies")] Aerospace_StudiesModel aerospace_StudiesModel)
        {
            Aerospace_StudiesModel model1 = (from s in db.Aerospace_StudiesModel.ToList()
                                             where s.StudentNo == aerospace_StudiesModel.StudentNo
                                             select s).FirstOrDefault();
            try
            {

                if (ModelState.IsValid)
                {

                    if (model1 != null)
                    {

                        ViewBag.m = "Student already exist";

                    }
                    else
                    {

                        db.Aerospace_StudiesModel.Add(aerospace_StudiesModel);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");

                    }

                }


                return View(aerospace_StudiesModel);
            }
            catch (Exception n)
            {
                Response.Write(n.Message);
            }


            return View(aerospace_StudiesModel);
        }

        // GET: Aerospace_StudiesModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aerospace_StudiesModel aerospace_StudiesModel = db.Aerospace_StudiesModel.Find(id);
            if (aerospace_StudiesModel == null)
            {
                return HttpNotFound();
            }
            return View(aerospace_StudiesModel);
        }

        // POST: Aerospace_StudiesModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CourseName,StudentNo,Communication_Skills,Aviation,Leadership_Studies,Security_Studies")] Aerospace_StudiesModel aerospace_StudiesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aerospace_StudiesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aerospace_StudiesModel);
        }

        // GET: Aerospace_StudiesModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aerospace_StudiesModel aerospace_StudiesModel = db.Aerospace_StudiesModel.Find(id);
            if (aerospace_StudiesModel == null)
            {
                return HttpNotFound();
            }
            return View(aerospace_StudiesModel);
        }

        // POST: Aerospace_StudiesModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aerospace_StudiesModel aerospace_StudiesModel = db.Aerospace_StudiesModel.Find(id);
            db.Aerospace_StudiesModel.Remove(aerospace_StudiesModel);
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
