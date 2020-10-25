using AOIS2.Core.Domain.Models.Kanji;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AOIS2.Core.Repositories.Contracts
{
    public interface IKanjiRepository
    {
        Task<IEnumerable<KanjiWithReading>> GetAllKanjisWithReadingAsync();
        Task<IEnumerable<KanjiWithWords>> GetAllKanjisWithWordsAsync();
        Task<IEnumerable<KanjiWithReadingAndWords>> GetAllKanjisWithReadingAndWordsAsync();
    }
}
