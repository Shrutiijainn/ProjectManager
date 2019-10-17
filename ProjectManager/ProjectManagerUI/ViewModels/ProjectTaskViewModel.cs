using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerUI.ViewModels
{
    public class ProjectTaskViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public int EmployeeId { get; set; }
        public List<TaskN> Tasks { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public int TaskPriority { get; set; }
        public string TaskStatus { get; set; }

    }
}