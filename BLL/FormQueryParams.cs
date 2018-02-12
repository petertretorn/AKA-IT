using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace FormManager.Domain
{
    public class FormQueryParams
    {
        public string SubmittedBefore { get; set; }
        public string SubmittedAfter { get; set; }
        public string CaseWorker { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }

        public IEnumerable<Expression<Func<Form, bool>>> BuildQuery()
        {
            var queries = new List<Expression<Func<Form, bool>>>();

            if (SubmittedAfter != null)
            {
                var date = ParseDate(SubmittedAfter);
                queries.Add(f => f.DateSubmitted > date);
            }

            if (SubmittedBefore != null)
            {
                var date = ParseDate(SubmittedBefore);
                queries.Add(f => f.DateSubmitted < date);
            }

            if (MemberFirstName != null)
            {
                queries.Add(f => f.Member.FirstName.Contains(MemberFirstName));
            }

            if (MemberLastName != null)
            {
                queries.Add(f => f.Member.FirstName.Contains(MemberLastName));
            }

            if (CaseWorker != null)
            {
                queries.Add(f => f.CaseWorker.Name.Contains(CaseWorker));
            }

            return queries;
        }

        private static DateTime ParseDate(string dateString) => 
            DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

    }
}