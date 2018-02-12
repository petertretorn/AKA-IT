using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FormManager.Domain;
using FormManager.Interfaces;
using FormManager.Dto;

namespace FormManager.API.Controllers
{
    [Route("api/[controller]")]
    public class FormsController : Controller
    {
        private IFormService _formService;

        public FormsController(IFormService formService)
        {
            this._formService = formService;
        }

        [HttpGet]
        public IEnumerable<FormDto> GetForms(FormQueryParams queryParams)
        {
            return _formService.GetFormDtos(queryParams);
        }
    }
}