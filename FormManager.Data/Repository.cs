using FormManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FormManager.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            this._dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

        protected IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetById(int id) => _dbSet.Find(id);

        public IEnumerable<T> GetByPredicate(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();
    }
}
