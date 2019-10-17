using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerDAL;
using Entities;
using Exceptions;

namespace ProjectManagerBLL
{
    public class ProjectService
    {
        static ProjectRepository ProjectRepo = null;
        public ProjectService()
        {
            ProjectRepo = new ProjectRepository();
        }
        public List<Project> Display()
        {
            try
            {
                return ProjectRepo.Display().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public bool AddProject(Project proj)
        {
            try
            {
                return ProjectRepo.Add(proj);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public Project Find(int id)
        {
            try
            {
                return ProjectRepo.Find(id);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
            throw new ProjectManagerException("Error finding Project");
        }

    }
}