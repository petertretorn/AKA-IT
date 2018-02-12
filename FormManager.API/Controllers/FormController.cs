using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FormManager.Domain;
using FormManager.Interfaces;
using FormManager.Dto;

namespace FormManager.API.Controllers
{
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        private IFormService _formService;

        public FormController(IFormService formService)
        {
            this._formService = formService;
        }

        [HttpGet]
        public IEnumerable<FormDto> All()
        {
            return _formService.GetFormDtos();
        }

        [HttpGet("ProcessedForms")]
        public IEnumerable<FormDto> ProcessedForms()
        {
            return _formService.GetFormDtosByPredicate(f => f.IsProcessed);
        }

        [HttpGet("SearchBy")]
        public IEnumerable<FormDto> ProcessedForms(FormQueryParams queryParams)
        {
            return _formService.GetFormDtos(queryParams);
        }
    }
}