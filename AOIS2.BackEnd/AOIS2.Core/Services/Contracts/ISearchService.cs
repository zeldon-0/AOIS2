using AOIS2.API.Contracts.Models.Kanjis;
using AOIS2.API.Contracts.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Services.Contracts
{
    public interface ISearchService
    {
        Task<IEnumerable<KanjiResult>> KanjiSearch(SearchModel searchModel);
    }
}
