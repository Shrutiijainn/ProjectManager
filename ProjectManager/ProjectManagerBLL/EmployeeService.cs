using Exceptions;
using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBLL
{
    public class EmployeeService
    {
        static EmployeeRepository EmpRepo = null;
        public EmployeeService()
        {
            EmpRepo = new EmployeeRepository();
        }
        public List<Employee> Display()
        {
            try
            {
                return EmpRepo.Display().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public bool AddEmployee(Employee emp)
        {
            try
            {
                return EmpRepo.Add(emp);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public List<Employee> DisplayDesignation()
        {
            try
            {
                return EmpRepo.DisplayDesignation().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
    }
}