using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOIS2.API.Contracts.Models.Kanjis;
using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.API.Contracts.Models.SearchModels;
using AOIS2.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace AOIS2.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SearchController : ControllerBase
    {
        private IDataFetchService _dataFetchService;
        private ISearchService _searchService;
        public SearchController(IDataFetchService dataFetchService,
            ISearchService searchService)
        {
            _dataFetchService = dataFetchService;
            _searchService = searchService;
        }
        [HttpPost]
        public async Task<IActionResult> SearchForKanji(SearchModel searchModel)
        {
            IEnumerable<KanjiResult> kanjis =
                await _searchService.KanjiSearch(searchModel);
            return Ok(kanjis);
        }

    }
}
