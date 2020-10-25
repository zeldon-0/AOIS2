using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Domain.Models.Radicals;

namespace AOIS2.Core.Domain.Models.JoinModels
{
    public class KanjiWithWordsRadical
    {
        public int RadicalId { get; set; }
        public int KanjiWithWordsId { get; set; }
        public Radical Radical { get; set; }
        public KanjiWithWords KanjiWithWords { get; set; }
    }
}
