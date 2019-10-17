using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerUI.ViewModels
{
    public class TaskViewModel
    {

        [Key]
        public int TaskId { get; set; }
        [StringLength(100)]
        [Required]

        public string TaskName { get; set; }
        [StringLength(300)]

        public string TaskDescription { get; set; }
        [Required]

        public DateTime TaskStartDate { get; set; }
        [Required]

        public DateTime TaskEndDate { get; set; }
        //[RegularExpression("^[1 - 5]{1}$")]

        public int TaskPriority { get; set; }

        [Required]
        public string TaskStatus { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }
        public SelectList Employees { get; set; }

    }
}