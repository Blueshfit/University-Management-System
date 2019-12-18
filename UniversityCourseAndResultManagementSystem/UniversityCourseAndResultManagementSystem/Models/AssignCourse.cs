using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class AssignCourse
    {
        [Key]
        public int AssignId { get; set; }

        [Required(ErrorMessage = "Please select any Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Please select Teacher")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [DefaultValue(0.0)]
        [Display(Name = "Credit to be taken")]
        public virtual double CreditToBeTaken { get; set; }

        [DefaultValue(0.0)]
        [Display(Name = "Remaining Credit")]
        public virtual double RemainingCredit { get; set; }

        [Required(ErrorMessage = "Please select any Course")]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}