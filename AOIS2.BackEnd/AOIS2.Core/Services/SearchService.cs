using AOIS2.API.Contracts.Models.Kanjis;
using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.API.Contracts.Models.SearchModels;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Domain.Models.SearchModels;
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
    public class SearchService : ISearchService
    {
        private IKanjiRepository _kanjiRepository;
        private IRadicalRepository _radicalRepository;
        private IMapper _mapper;

        public SearchService(IKanjiRepository kanjiRepository,
            IRadicalRepository radicalRepository,
            IMapper mapper)
        {
            _kanjiRepository = kanjiRepository;
            _radicalRepository = radicalRepository;
            _mapper = mapper;
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
            for(int i = 0; i < kanjis.Count; i++)
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
            // Fetch kanjis again
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

            IEnumerable<KanjiSearchModel> kanjis = new List<KanjiSearchModel>();
            kanjis.Concat(
                kanjisWithReading.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                )
            );
            kanjis.Concat(
                kanjisWithWords.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                )
            );
            kanjis.Concat(
                kanjisWithReadingAndWords.Select(
                    k => _mapper.Map<KanjiSearchModel>(k)
                )
            );
            return kanjis;
        }
    }
}
