using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagerDAL;
using ProjectManagerUI.ViewModels;
namespace ProjectManagerUI.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        IRepository<Project> ProjectRepo;

        public ProjectsController()
        {
            ProjectRepo = new ProjectRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Add(ProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var Project = new Project() {ProjectId=vm.ProjectId,ProjectTitle=vm.ProjectTitle,ProjectStartDate=vm.ProjectStartDate,ProjectEndDate=vm.ProjectEndDate,EmployeeId=vm.EmployeeId};
                var Added=ProjectRepo.Add(Project);
                if (Added)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add");
                    return View(vm);
                }
            }
            else
            {
                ModelState.AddModelError("","One or More validation failed");
                return View(vm);
            }
        }
    }
}