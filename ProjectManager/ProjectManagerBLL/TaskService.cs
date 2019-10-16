using Exceptions;
using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ProjectmanagerBLL
{
    public class TaskService
    {
        static TaskRepository TaskRepo = null;
        public TaskService()
        {
            TaskRepo = new TaskRepository();
        }
        public List<TaskN> Display()
        {
            try
            {
                return TaskRepo.Display().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public bool AddTask(TaskN proj)
        {
            try
            {
                return TaskRepo.Add(proj);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
    }
}