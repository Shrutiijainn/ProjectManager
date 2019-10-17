using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerUI.ViewModels
{
    public class ProjectTaskViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        [Display(Name ="Select Employee")]
        public int EmployeeId { get; set; }
        public SelectList Employeess { get; set; }
        public List<TaskN> Tasks { get; set; }
        public int TaskId { get; set; }
        [Required]
        [Display(Name = "Enter Task Title")]

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        [Required]
        [Display(Name = "Select Start Title")]

        public DateTime TaskStartDate { get; set; }
        [Required]
        [Display(Name = "Select End Title")]

        public DateTime TaskEndDate { get; set; }
        [Required]
        [Display(Name = "Select Task Priority[1-5]")]

        public int TaskPriority { get; set; }
        [Required]
        [Display(Name = "Select Task Status")]

        public string TaskStatus { get; set; }
        
    }
}