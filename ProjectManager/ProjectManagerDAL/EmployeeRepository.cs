﻿using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDAL
{
    public class EmployeeRepository : IRepository<Employee>
    {
        ProjectMgrModel _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new ProjectMgrModel();
        }

        public bool Add(Employee item)
        {
            var IsAdded = false;
            try
            {
                _dbContext.Employees.Add(item);
                IsAdded = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("error adding data" + ex);
            }
            return IsAdded;
        }

        public Employee Find(int id)
        {
            try
            {
                return _dbContext.Employees.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<Employee> Display()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error getting data" + ex);
            }
        }

        public List<Employee> DisplayDesignation()
        {
            try
            {
                ProjectMgrModel context = new ProjectMgrModel();

                var Query = from item in context.Projects
                            select item.EmployeeId;
                var q = from Employee in context.Employees
                        where Employee.EmployeeDesignation == "ProjectManager" && !Query.Contains(Employee.EmployeeId)
                        select Employee;
                return q.ToList();
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