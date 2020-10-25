using AOIS2.Core.Domain.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Repositories.Contracts
{
    public interface IRadicalRepository
    {
        Task<IEnumerable<Radical>> GetAllRadicalsAsync();
    }
}
