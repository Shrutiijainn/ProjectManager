using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ProjectManagerException: ApplicationException
    {
        public ProjectManagerException() : base()
        {

        }
        public ProjectManagerException(string message) : base(message)
        {

        }
        public ProjectManagerException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
