using FormManager.Domain;
using FormManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FormManager.Interfaces
{
    public interface IFormService
    {
        IEnumerable<FormDto> GetFormDtos();
        IEnumerable<FormDto> GetFormDtos(FormQueryParams queryParams);
        IEnumerable<FormDto> GetFormDtosByPredicate(Expression<Func<Form, bool>> predicate);
    }
}
