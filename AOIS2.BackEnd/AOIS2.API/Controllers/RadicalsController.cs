using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AOIS2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RadicalsController : ControllerBase
    {
        private IDataFetchService _dataFetchService;
        public RadicalsController(IDataFetchService dataFetchService)
        {
            _dataFetchService = dataFetchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRadicals()
        {
            IEnumerable<RadicalModel> radicals =
                await _dataFetchService.GetAllRadicalsAsync();
            return Ok(radicals);
        }

    }
}
