using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Enroll
    {
        [Key]
        public int EnrollId { get; set; }

        [Display(Name = "Student Reg No")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required(ErrorMessage = "Please select a Course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Required]
        [Display(Name ="Date")]
        [DataType(DataType.DateTime)]
        public DateTime EnrollDate { get; set; }

        public virtual string GradeLetter { set; get; }
        public bool IsEnroll { get; set; }

    }
}