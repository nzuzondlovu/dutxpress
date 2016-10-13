using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class Aerospace_StudiesModel
    {
        [Key]

        public int id { get; set; }


        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Display(Name = "StudentNo")]

        public string StudentNo { get; set; }

        [Display(Name = "Communication_Skills")]

        public double Communication_Skills { get; set; }
        [Display(Name = "Aviation")]

        public double Aviation { get; set; }
        [Display(Name = "Leadership_Studies")]

        public double Leadership_Studies { get; set; }
        [Display(Name = "Security_Studies")]

        public double Security_Studies { get; set; }

    }
}
