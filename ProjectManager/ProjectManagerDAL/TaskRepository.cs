using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ProjectManagerDAL
{
    public class TaskRepository : IRepository<TaskN>
    {
        ProjectMgrModel objContext;

        public TaskRepository()
        {
            objContext = new ProjectMgrModel();
        }

        public bool Add(TaskN obj)
        {
            try
            {
                if (obj != null)
                {
                        objContext.Tasks.Add(obj);
                        return objContext.SaveChanges() > 0;
                }
                else
                {
                    throw new ProjectManagerException("No Project to add");
                }
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public TaskN Find(int id)
        {
            try
            {
                return objContext.Tasks.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<TaskN> Display()
        {
            try
            {
                    if (objContext.Tasks.Count() > 0)
                    {
                        return objContext.Tasks.ToList();
                    }
                    else
                    {
                        throw new ProjectManagerException("No Data To Display");
                    }
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }


        public List<TaskN> GetTasks(int projectId)
        {
            TaskN task = new TaskN();
            //return new List<Rating>() {
            //    new Rating(){ RatingValue=5, Customer="Jojo" },
            //    new Rating(){ RatingValue=3, Customer="Sam" }
            //};

            try
            {
                task= objContext.Tasks.Find(projectId);
                return objContext.Tasks.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }

        }

        public bool AddTask(TaskN obj)
        {
            return true;
        }

        public void Dispose()
        {
            objContext.Dispose();
        }

    }
}