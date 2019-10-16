using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDAL
{
    public interface IRepository<T> : IDisposable
    {
        List<T> Display();
        T Find(int id);
        bool Add(T item);
    }
}