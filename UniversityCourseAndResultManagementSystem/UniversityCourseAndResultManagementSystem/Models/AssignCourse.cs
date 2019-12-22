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

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Teacher")]
        [Required(ErrorMessage = "Please select Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [NotMapped]
        [Display(Name = "Credit to be taken")]
        public virtual float CreditToBeTaken { get; set; }

        [NotMapped]
        [DefaultValue(0.0)]
        [Display(Name = "Remaining Credit")]
        public virtual float RemainingCredit { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Please select Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [NotMapped]
        [Display(Name ="Credit")]
        public virtual float Credit { get; set; }

    }
}