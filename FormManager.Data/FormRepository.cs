using FormManager.Domain;
using FormManager.Dto;
using FormManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FormManager.Data
{
    public class FormRepository : Repository<Form>, IFormRepository
    {
        public FormRepository(DbContext context) : base(context) { }

        private IQueryable<Form> GetGraph() => this.GetAllIncluding(f => f.Member, f => f.CaseWorker);

        public IEnumerable<Form> All() => this.GetGraph().ToList();

        public IEnumerable<Form> GetFormsByPredicate(Expression<Func<Form, bool>> predicate)
        {
            return this.GetGraph().Where(predicate).ToList();
        }

        public IEnumerable<Form> All(IEnumerable<Expression<Func<Form, bool>>> queries)
        {
            var queryable = GetGraph();

            queryable = queries.Aggregate(queryable, (current, query) => current.Where(query));

            var list = queryable.ToList();

            return list;
        }
    }
}
