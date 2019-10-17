using Exceptions;
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
        TaskRepository TaskRepo = new TaskRepository();
        // GET: ProductTask
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DisplayProjectTask(int id)
        {
            var prepository = new ProjectRepository();
            var project = prepository.Find(id);

            var trepository = new TaskRepository();
            var tasks = trepository.GetTasks(id);

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
            return View();
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
                        EmployeeId = item.EmployeeId
                    };
                    var Added = TaskRepo.Add(Task);
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