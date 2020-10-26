using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Repositories.Contracts;
using AOIS2.Core.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Services
{
    public class DataFetchService : IDataFetchService
    {
        private IRadicalRepository _radicalRepository;
        private IMapper _mapper;
        public DataFetchService(IRadicalRepository radicalRepository,
            IMapper mapper)
        {
            _radicalRepository = radicalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RadicalModel>> GetAllRadicalsAsync()
        {
            IEnumerable<Radical> radicals =
                await _radicalRepository.GetAllRadicalsAsync();
            IEnumerable<RadicalModel> radicalModels =
                radicals.Select(r => _mapper.Map<RadicalModel>(r));
            return radicalModels;
        }
    }
}
