using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class Information_TechnologyModel
    {
        [Key]

        public int id { get; set; }


        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Display(Name = "StudentNo")]

        public string StudentNo { get; set; }

        [Display(Name = "Development Software")]

        public double DS { get; set; }
        [Display(Name = "Technical Programming")]

        public double TP { get; set; }
        [Display(Name = "System Software")]

        public double SS { get; set; }
        [Display(Name = "Information System")]

        public double IS { get; set; }
    }
}