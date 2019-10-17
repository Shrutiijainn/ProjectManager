using Exceptions;
using ProjectmanagerBLL;
using ProjectManagerBLL;
using ProjectManagerDAL;
using ProjectManagerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerUI.Controllers
{
    public class ProjectTaskController : Controller
    {
         TaskService TaskServ = null;

        public ProjectTaskController()
        {
            TaskServ = new TaskService();
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DisplayProjectTask(int id)
        {
            var pservice = new ProjectService();
            var project = pservice.Find(id);

            var tservice = new TaskService();
            var tasks = tservice.GetTasks(id);

            var viewmodel = new ProjectTaskViewModel();
            viewmodel.ProjectId = project.ProjectId;
            viewmodel.ProjectTitle = project.ProjectTitle;
            viewmodel.ProjectStartDate = project.ProjectStartDate;
            viewmodel.ProjectEndDate = project.ProjectEndDate;
            viewmodel.EmployeeId = project.EmployeeId;

            viewmodel.Tasks = tasks;

            return View(viewmodel);
        }

        public ActionResult ProjectTaskByStatus(int id)
        {
            var pservice = new ProjectService();
            var project = pservice.Find(id);

            var tservice = new TaskService();
            var tasks = tservice.GetTasks(id);

            var viewmodel = new ProjectTaskViewModel();
            viewmodel.ProjectId = project.ProjectId;
            viewmodel.ProjectTitle = project.ProjectTitle;
            viewmodel.ProjectStartDate = project.ProjectStartDate;
            viewmodel.ProjectEndDate = project.ProjectEndDate;
            viewmodel.EmployeeId = project.EmployeeId;

            viewmodel.Tasks = tasks;

            return View(viewmodel);
        }

        public ActionResult AddTask()
        {
            var item = new ProjectTaskViewModel();
            item.Employeess = new SelectList(TaskServ.Displaypendingtasks(), "EmployeeId", "EmployeeName", "EmployeeDesignation");
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ProjectTask/AddTask/{Id}")]
        public ActionResult AddTask(TaskViewModel item, int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var Task = new TaskN()
                    {
                        TaskId = item.TaskId,
                        TaskName = item.TaskName,
                        TaskDescription = item.TaskDescription,
                        TaskStartDate = item.TaskStartDate,
                        TaskEndDate = item.TaskEndDate,
                        TaskStatus = item.TaskStatus,
                        ProjectId = Id,
                        EmployeeId = item.EmployeeId,
                        TaskPriority=item.TaskPriority
                    };
                    var Added = TaskServ.AddTask(Task);
                    if (Added)
                    {
                        return RedirectToAction("DisplayProjectTask" + "/" + Id);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to add");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "One or More validation failed");
                    return View();
                }
            }
            catch (ProjectManagerException e)
            {
                return Content("Error" + e.Message);
            }
        }
    }
}