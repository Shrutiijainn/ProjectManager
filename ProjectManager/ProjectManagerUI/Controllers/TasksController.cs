using ProjectManagerDAL;
using ProjectManagerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagerUI.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayProjectTask(int id)
        {
            var prepository = new ProjectRepository();
            var project = prepository.Find(id);

            var trepository = new TaskRepository();
            var tasks = trepository.GetTasks(project.ProjectId);

            var viewmodel = new TaskViewModel();
            viewmodel.ProjectId = project.ProjectId;
            viewmodel.ProjectTitle = project.ProjectTitle;
           // viewmodel.Description = product.Description;

            viewmodel.Tasks = tasks;

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddTask(TaskViewModel model)
        {
            return Content(model.TaskName);

            //return RedirectToAction("Display", "Products", new { id = model.Id });
        }

    }
}