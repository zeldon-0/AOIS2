using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Domain.Models.JoinModels;

namespace AOIS2.Core.Domain.Models.Kanji
{
    public class KanjiWithWords
    {
        public int Id { get; set; }
        public string Kanji { get; set; }
        public int TaughtInGrade { get; set; }
        public int Strokes { get; set; }
        public string Words { get; set; }
        public IEnumerable<KanjiWithWordsRadical> KanjiWithWordsRadicals { get; set; }
    }
}
