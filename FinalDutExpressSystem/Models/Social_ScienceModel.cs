using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class Social_ScienceModel
    {
        [Key]

        public int id { get; set; }


        [Display(Name = "Course Name")]
        public string Course { get; set; }

        [Display(Name = "StudentNo")]

        public string StudentNo { get; set; }

        [Display(Name = "Anthropology")]

        public double Anthropology { get; set; }
        [Display(Name = "Philosophy")]

        public double Philosophy { get; set; }
        [Display(Name = "Psychology")]

        public double Psychology { get; set; }
        [Display(Name = "Sociology")]

        public double Sociology { get; set; }
    }
}
