﻿using System;
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

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public DateTime Date { get; set; }
    }
}