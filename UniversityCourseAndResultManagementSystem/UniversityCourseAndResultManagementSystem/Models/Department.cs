using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be 2-7 characters long")]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Code")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please enter department Name")]
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Name")]
        public string DepartmentName { get; set; }
    }
}