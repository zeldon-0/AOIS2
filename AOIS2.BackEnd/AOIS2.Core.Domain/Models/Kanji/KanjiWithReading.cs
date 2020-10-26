using AOIS2.Core.Domain.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Domain.Models.JoinModels;

namespace AOIS2.Core.Domain.Models.Kanji
{
    public class KanjiWithReading
    {
        public int Id { get; set; }
        public string Kanji { get; set; }
        public string Reading { get; set; }
        public int JLPTLevel { get; set; }
        public IEnumerable<KanjiWithReadingRadical> KanjiWithReadingRadicals { get; set; }

    }
}
