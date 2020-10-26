using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Core.Domain.Models.SearchModels
{
    public class RadicalSearchModel
    {
        public int Id { get; set; }
        public IEnumerable<KanjiSearchModel> Kanjis { get; set; }
        public IEnumerable<KanjiSearchModel> KanjisWithReading { get; set; }
        public IEnumerable<KanjiSearchModel> KanjisWithWords { get; set; }
        public IEnumerable<KanjiSearchModel> KanjisWithReadingAndWords { get; set; }
    }
}
