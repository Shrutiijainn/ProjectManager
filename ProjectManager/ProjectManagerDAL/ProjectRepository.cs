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
        ProjectMgrModel objContext;

        public ProjectRepository()
        {
            objContext = new ProjectMgrModel();
        }

        public bool Add(Project obj)
        {
            try
            {
                if (obj != null)
                {
                        objContext.Projects.Add(obj);
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

        public Project Find(int id)
        {
            try
            {
                return objContext.Projects.Find(id);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
            throw new ProjectManagerException("Error finding Project");
        }

        public List<Project> Display()
        {
            try
            {
                    if (objContext.Projects.Count() > 0)
                    {
                        return objContext.Projects.ToList();
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

            try
            {
                var q = from item in objContext.Tasks
                        where item.ProjectId == projectId
                        select item;
                return q.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<Employee> Displaypendigtasks()
        {
            ProjectMgrModel context = new ProjectMgrModel();
            var EmployeesWithFullTasks = from task in context.Tasks
                                         group task by task.EmployeeId into grp
                                         where grp.Count() >= 5
                                         select grp.Key;

            var query2 = from emp in context.Employees
                         from t in context.Tasks
                         where emp.EmployeeDesignation == "Developer" && !EmployeesWithFullTasks.Contains(emp.EmployeeId)
                        && t.TaskStatus == "pending" || t.EmployeeId == emp.EmployeeId
                         select emp;
            return query2.ToList().Distinct(new EmployeeComparer()).ToList();
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