using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class Chemical_EngineeringModel
    {
        [Key]

        public int id { get; set; }


        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Display(Name = "StudentNo")]

        public string StudentNo { get; set; }

        [Display(Name = "Mathematics")]

        public double Mathematics { get; set; }
        [Display(Name = "Chemistry")]

        public double Chemistry { get; set; }
        [Display(Name = "Engineering science")]

        public double EngineeringScience { get; set; }
        [Display(Name = "Chemical Engineering")]

        public double ChemicalEngineering { get; set; }
    }
}
