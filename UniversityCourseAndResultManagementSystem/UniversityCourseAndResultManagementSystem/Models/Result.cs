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
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Display(Name ="Grade")]
        public int GradeId { get; set; }
        [ForeignKey("GradeId")]
        public virtual Grade Grade { get; set; }

    }
}