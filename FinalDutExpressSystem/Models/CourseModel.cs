using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalDutExpressSystem.Models
{
    public class CourseModel
    {
        [Key]
        public int CourseID { get; set; }
        [Display(Name = "CourseName")]
        [Required]
        public string CourseName { get; set; }
        //public CourseModel Course { get; set; }

        
        //public IEnumerable<CourseModel> Courses { get; set; }

    }
}
