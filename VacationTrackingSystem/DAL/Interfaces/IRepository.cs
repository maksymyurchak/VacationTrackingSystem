using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        //IEnumerable<T> Get(long Id);
        IEnumerable<T> Get(
            System.Linq.Expressions.Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
        );

        T Insert(T entity);

        void Update(T entity);

        //void SetStateModified(T entity);


    }
}
