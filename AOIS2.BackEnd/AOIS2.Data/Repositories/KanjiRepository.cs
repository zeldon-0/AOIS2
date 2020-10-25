using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Repositories.Contracts;
using AOIS2.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AOIS2.Data.Repositories
{
    public class KanjiRepository : IKanjiRepository
    {
        private DataStorageContext _context;
        public KanjiRepository(DataStorageContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KanjiWithReadingAndWords>> GetAllKanjisWithReadingAndWordsAsync()
        {
            IEnumerable<KanjiWithReadingAndWords> kanjis =
                await _context
                .KanjisWithReadingAndWords
                .Include(k => k.KanjiWithReadingAndWordsRadicals)
                .ThenInclude(kr => kr.Radical)
                .ToListAsync();

            return kanjis;

        }

        public async Task<IEnumerable<KanjiWithReading>> GetAllKanjisWithReadingAsync()
        {
            IEnumerable<KanjiWithReading> kanjis =
                await _context
                .KanjisWithReading
                .Include(k => k.KanjiWithReadingRadicals)
                .ThenInclude(kr => kr.Radical)
                .ToListAsync();

            return kanjis;
        }

        public async Task<IEnumerable<KanjiWithWords>> GetAllKanjisWithWordsAsync()
        {
            IEnumerable<KanjiWithWords> kanjis =
                await _context
                .KanjisWithWords
                .Include(k => k.KanjiWithWordsRadicals)
                .ThenInclude(kr => kr.Radical)
                .ToListAsync();

            return kanjis;
        }
    }
}
