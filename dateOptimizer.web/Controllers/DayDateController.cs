using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dateOptimizer.domain.contracts;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.SwaggerGen;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.web
{
    public class DayDateController : Controller
    {
        private IDateService _dateService;
        public DayDateController(IDateService dateService) 
        {
            _dateService = dateService ?? throw new ArgumentNullException();
        }


        [HttpGet]
        [Route("/api/Days/GetRange/{fip:int}")]
        public ObjectResult GetDates(int fip) {
            DayRangeDto result = _dateService.GetDatesByFip(fip);
            return new OkObjectResult(result);          
        }
    }
}