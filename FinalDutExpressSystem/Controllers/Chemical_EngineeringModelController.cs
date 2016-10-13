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
    public class Chemical_EngineeringModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chemical_EngineeringModel
        public ActionResult Index(string searchString)
        {
            try
            {
                var student = from m in db.Chemical_EngineeringModel
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
        // GET: Chemical_EngineeringModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemical_EngineeringModel chemical_EngineeringModel = db.Chemical_EngineeringModel.Find(id);
            if (chemical_EngineeringModel == null)
            {
                return HttpNotFound();
            }
            return View(chemical_EngineeringModel);
        }

        // GET: Chemical_EngineeringModel/Create
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

        // POST: Chemical_EngineeringModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,CourseName,StudentNo,Mathematics,Chemistry,EngineeringScience,ChemicalEngineering")] Chemical_EngineeringModel chemical_EngineeringModel)
        {
            Chemical_EngineeringModel model1 = (from s in db.Chemical_EngineeringModel.ToList()
                                                where s.StudentNo == chemical_EngineeringModel.StudentNo select s).FirstOrDefault();
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

                        db.Chemical_EngineeringModel.Add(chemical_EngineeringModel);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");

                    }

                }


                return View(chemical_EngineeringModel);
            }
            catch (Exception n)
            {
                Response.Write(n.Message);
            }


            return View(chemical_EngineeringModel);
        }

        // GET: Chemical_EngineeringModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemical_EngineeringModel chemical_EngineeringModel = db.Chemical_EngineeringModel.Find(id);
            if (chemical_EngineeringModel == null)
            {
                return HttpNotFound();
            }
            return View(chemical_EngineeringModel);
        }

        // POST: Chemical_EngineeringModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CourseName,StudentNo,Mathematics,Chemistry,EngineeringScience,ChemicalEngineering")] Chemical_EngineeringModel chemical_EngineeringModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemical_EngineeringModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chemical_EngineeringModel);
        }

        // GET: Chemical_EngineeringModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chemical_EngineeringModel chemical_EngineeringModel = db.Chemical_EngineeringModel.Find(id);
            if (chemical_EngineeringModel == null)
            {
                return HttpNotFound();
            }
            return View(chemical_EngineeringModel);
        }

        // POST: Chemical_EngineeringModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chemical_EngineeringModel chemical_EngineeringModel = db.Chemical_EngineeringModel.Find(id);
            db.Chemical_EngineeringModel.Remove(chemical_EngineeringModel);
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
