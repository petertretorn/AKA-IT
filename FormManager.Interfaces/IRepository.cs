using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FormManager.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
    }
}
