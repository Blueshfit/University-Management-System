using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        [Display(Name = "Student Reg No")]
        [Required(ErrorMessage = "Please select Student Reg No.")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please select Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Display(Name ="Grade")]
        [Required(ErrorMessage = "Please select Grade Letter")]
        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public virtual Grade Grade { get; set; }

    }
}