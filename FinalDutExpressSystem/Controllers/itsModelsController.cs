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
    public class itsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: itsModels
        public ActionResult Index(string searchString)
        {
            try
            {
                var student = from m in db.itsModels
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

        // GET: itsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itsModel itsModel = db.itsModels.Find(id);
            if (itsModel == null)
            {
                return HttpNotFound();
            }
            return View(itsModel);
        }

        // GET: itsModels/Create
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

        // POST: itsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = 
            "id,CourseName,StudentNo,Mark1,Mark2,Mark3,Mark4")] itsModel itsModel,Information_TechnologyModel IT,
            Chemical_EngineeringModel chem,Aerospace_StudiesModel aero,Social_ScienceModel socScie)
        {

            itsModel model1 = (from s in db.itsModels.ToList()
                               where s.StudentNo == itsModel.StudentNo
                               select s).FirstOrDefault();


            try
            {

                if (ModelState.IsValid)
                {
                    
                    if(itsModel.CourseName=="Information Technology")
                    {
                            db.Information_TechnologyModel.Add(IT);
                            db.SaveChanges();
                        }

                    
                    if (itsModel.CourseName == "Chemical Engineering")
                    {
                       
                        
                            db.Chemical_EngineeringModel.Add(chem);
                            db.SaveChanges();
                        
                    }

                    if (itsModel.CourseName == "Social Science")
                    {
                        
                         

                        
                            db.Social_ScienceModel.Add(socScie);
                            db.SaveChanges();
                        
                    }

                    if (itsModel.CourseName == "Aerospace Studies")
                    {
                       
                            db.Aerospace_StudiesModel.Add(aero);
                            db.SaveChanges();
                        
                    }
                    else
                    {

                        db.itsModels.Add(itsModel);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Index");

                    }

                }


                return View(itsModel);
            }
            catch (Exception n)
            {
                Response.Write(n.Message);
            }


            return View(itsModel);
        }

        // GET: itsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itsModel itsModel = db.itsModels.Find(id);
            if (itsModel == null)
            {
                return HttpNotFound();
            }
            return View(itsModel);
        }

        // POST: itsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CourseName,StudentNo,Mark1,Mark2,Mark3,Mark4")] itsModel itsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itsModel);
        }

        // GET: itsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            itsModel itsModel = db.itsModels.Find(id);
            if (itsModel == null)
            {
                return HttpNotFound();
            }
            return View(itsModel);
        }

        // POST: itsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            itsModel itsModel = db.itsModels.Find(id);
            db.itsModels.Remove(itsModel);
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
