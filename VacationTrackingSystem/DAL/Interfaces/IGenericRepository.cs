using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> : IRepository<T>
     where T : class
    {
        //void Delete(T entityToDelete);

        T GetByID(object id);

        //void Delete(object id);
    }
}
