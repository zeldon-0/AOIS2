using AOIS2.API.Contracts.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.API.Contracts.Models.SearchModels
{
    public class SearchModel
    {
        public IEnumerable<RadicalModel> Radicals { get; set; }
    }
}
