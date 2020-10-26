using AOIS2.API.Contracts.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Services.Contracts
{
    public interface IDataFetchService
    {
        Task<IEnumerable<RadicalModel>> GetAllRadicalsAsync();

    }
}
