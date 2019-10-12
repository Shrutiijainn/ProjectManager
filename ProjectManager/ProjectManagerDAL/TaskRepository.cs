using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ProjectManagerDAL
{
    public class TaskRepository : IRepository<Task>
    {
        ProjectMgrModel _dbContext;

        public TaskRepository()
        {
            _dbContext = new ProjectMgrModel();
        }

        public bool Add(Task id)
        {
            throw new ProjectManagerException();
        }

        public Task Find(int id)
        {
            try
            {
                return _dbContext.Tasks.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<Task> GetAll()
        {
            try
            {
                return _dbContext.Tasks.ToList();
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