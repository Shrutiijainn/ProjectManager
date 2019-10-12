using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ProjectManagerDAL
{
    public class ProjectRepository : IRepository<Project>
    {
        ProjectMgrModel _dbContext;

        public ProjectRepository()
        {
            _dbContext = new ProjectMgrModel();
        }

        public bool Add(Project item)
        {
            var IsAdded = false;
            try
            {
                _dbContext.Projects.Add(item);
                IsAdded = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error adding project" + ex);
            }
            return IsAdded;
        }

        public Project Find(int id)
        {
            try
            {
                return _dbContext.Projects.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Project" + ex);
            }
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            try
            {
                return _dbContext.Projects.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error getting data" + ex);
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}