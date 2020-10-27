using AOIS2.API.Contracts.Models.Kanjis;
using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.API.Contracts.Models.SearchModels;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Domain.Models.SearchModels;
using AOIS2.Core.Repositories.Contracts;
using AOIS2.Core.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Services
{
    public class SearchService : ISearchService
    {
        private IKanjiRepository _kanjiRepository;
        private IRadicalRepository _radicalRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public SearchService(IKanjiRepository kanjiRepository,
            IRadicalRepository radicalRepository,
            IMapper mapper,
            ILogger<KanjiSearchModel> logger)
        {
            _kanjiRepository = kanjiRepository;
            _radicalRepository = radicalRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<KanjiResult>> KanjiSearch(SearchModel searchModel)
        {
            List<KanjiSearchModel> kanjis = (await GetAllKanjisCombined()).ToList();
            List<RadicalSearchModel> radicals = new List<RadicalSearchModel>();

            foreach(RadicalModel radical in searchModel.Radicals)
            {
                Radical radicalEntity =
                    await _radicalRepository.GetRadicalByIdAsync(radical.Id);
                radicals.Add(_mapper.Map<RadicalSearchModel>(radicalEntity));
                
            }

            for (int i = 0; i < kanjis.Count; i++)
            {
                foreach(var radical in radicals)
                {
                    if (radical.Kanjis
                        .Any(k => k.Id == kanjis[i].Id))
                    {
                        kanjis[i].Probability += Math.Log(kanjis.Count() /
                            radical.Kanjis.Count());
                    }
                    else
                    {
                        kanjis[i].Probability = 0;
                        break;
                    }
                }
            }

            kanjis = kanjis.Where(k => k.Probability != 0).ToList();
            kanjis = kanjis.OrderByDescending(k => k.Probability).ToList();
            foreach (var kanji in kanjis)
            {
                _logger.LogInformation($"{kanji.Id} probability: {kanji.Probability}");
            }
            return kanjis.Select(k => _mapper.Map<KanjiResult>(k));
            
        }
        private async Task<IEnumerable<KanjiSearchModel>> GetAllKanjisCombined()
        {
            IEnumerable<KanjiWithReading> kanjisWithReading =
                await _kanjiRepository.GetAllKanjisWithReadingAsync();
            IEnumerable<KanjiWithWords> kanjisWithWords =
                await _kanjiRepository.GetAllKanjisWithWordsAsync();
            IEnumerable<KanjiWithReadingAndWords> kanjisWithReadingAndWords =
                await _kanjiRepository.GetAllKanjisWithReadingAndWordsAsync();



            List<KanjiSearchModel> kanjis = new List<KanjiSearchModel>() { new KanjiSearchModel()};
            kanjis = kanjis.Concat(
                kanjisWithReading.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                )
            ).ToList();

            kanjis = kanjis.Concat(
                kanjisWithWords.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                ).ToList()
            ).ToList();
            
            kanjis = kanjis.Concat(
                kanjisWithReadingAndWords.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                ).ToList()
            ).ToList();
            return kanjis;
        }
    }
}
