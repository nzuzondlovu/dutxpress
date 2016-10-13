using FinalDutExpressSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalDutExpressSystem.Controllers
{
    [Authorize]
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index(string studentNo,Information_TechnologyModel model)
        {
            double Agg = (model.DS + model.IS + model.IS + model.TP) / 4;
           ApplicationDbContext db = new ApplicationDbContext();
            List<Information_TechnologyModel> IT = db.Information_TechnologyModel.Where(s => s.StudentNo == studentNo).ToList();
            return View(IT);

        }
        public ActionResult Index1(string studentNo)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Chemical_EngineeringModel> chemResults = db.Chemical_EngineeringModel.Where(s => s.StudentNo == studentNo).ToList();
            return View(chemResults);

        }
        public ActionResult Index2(string studentNo)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Social_ScienceModel> SocialResults = db.Social_ScienceModel.Where(s => s.StudentNo == studentNo).ToList();
           
            return View(SocialResults);

        }
        public ActionResult Index3(string studentNo)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Aerospace_StudiesModel> AAS = db.Aerospace_StudiesModel.Where(s => s.StudentNo == studentNo).ToList();
            return View(AAS);

        }

    }
}