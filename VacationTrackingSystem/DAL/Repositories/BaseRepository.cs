using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        internal AppContext _context;
        internal DbSet<TEntity> _dbSet;
        public BaseRepository(AppContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> All
        {
            get
            {
                return _dbSet;
            }
        }

        //public virtual IEnumerable<TEntity> Get() { return null; }
        public virtual TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
            }
            catch { }
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
      
        public void SetStateModified(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
