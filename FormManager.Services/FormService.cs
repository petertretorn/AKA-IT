using FormManager.Domain;
using FormManager.Dto;
using FormManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FormManager.Services
{
    public class FormService : IFormService
    {
        private IFormRepository _repository;

        public FormService(IFormRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<FormDto> GetFormDtos() => 
            _repository
                .All()
                .Select(MapToDto);

        public IEnumerable<FormDto> GetFormDtos(FormQueryParams queryParams)
        {
            var queries = queryParams.BuildQuery();

            return _repository.All(queries).Select(MapToDto);
        }
        
        public IEnumerable<FormDto> GetFormDtosByPredicate(Expression<Func<Form, bool>> predicate)
        {
            return _repository.GetFormsByPredicate(predicate).Select(MapToDto);
        }
        
        private FormDto MapToDto(Form form) => new FormDto()
        {
            Id = form.Id,
            DateProcessed = form.DateProcessed.ToString("dd/MM/yyyy"),
            DateSubmitted = form.DateSubmitted.ToString("dd/MM/yyyy"),
            IsProcessed = form.IsProcessed,
            Member = $"{form.Member.FirstName} {form.Member.LastName}",
            ProcessedBy = $"{form.CaseWorker.Name}, {form.CaseWorker.Location}"
        };
    }
}
