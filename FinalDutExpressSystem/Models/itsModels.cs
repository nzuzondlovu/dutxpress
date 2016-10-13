using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class itsModel
    {
        private ApplicationDbContext context;

        [Key]

        public int id { get; set; }


        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Display(Name = "StudentNo")]
        [Required]
        public string StudentNo { get; set; }

        [Display(Name = "Subject1 Mark")]
        [Required]
        public double Mark1 { get; set; }
        [Display(Name = "Subject2  Mark")]
        [Required]
        public double Mark2 { get; set; }
        [Display(Name = "Subject3  Mark")]
        [Required]
        public double Mark3 { get; set; }
        [Display(Name = "Subject4  Mark")]
        [Required]
        public double Mark4 { get; set; }
    }
}