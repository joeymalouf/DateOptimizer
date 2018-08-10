using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dateOptimizer.domain.contracts;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore;
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
        [Route("/api/Days/GetRangeByFip/{fip:int}")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(DayRangeDto))]
        public async Task<ObjectResult> GetDatesByFipAsync(int fip) {
            DayRangeDto result = await _dateService.GetDatesByFipAsync(fip).ConfigureAwait(false);
            return new OkObjectResult(result);          
        }

        [HttpPost]   
        [Route("/api/Days/GetRangeByCounty/")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(DayRangeDto))]
        public async Task<ObjectResult> GetDatesByFipAsync([Bind][FromBody] CountyDto county) {
            DayRangeDto result = await _dateService.GetDatesByCountyAsync(county).ConfigureAwait(false);
            return new OkObjectResult(result);          
        }
    }


}