using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace ProjectManagerUI.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        [StringLength(50, ErrorMessage = "Minimum 3 characters and Maximum 50")]
        [Required]
        [Display(Name = "Enter Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Enter Start Date")]
        public DateTime ProjectStartDate { get; set; }
        [Required]
        [Display(Name = "Enter End Date")]

        public DateTime ProjectEndDate { get; set; }
        [Display(Name = "Select Project Manager")]
        public int EmployeeId { get; set; }


        public SelectList Employees { get; set; }


    }
}