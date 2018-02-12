using FormManager.Domain;
using FormManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FormManager.Interfaces
{
    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<Form> All();
        IEnumerable<Form> All(IEnumerable<Expression<Func<Form, bool>>> queries);
        IEnumerable<Form> GetFormsByPredicate(Expression<Func<Form, bool>> predicate);
    }
}
