using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerDAL;
namespace ProjectManagerDAL
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.EmployeeId == y.EmployeeId;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.EmployeeId;
        }
    }
}