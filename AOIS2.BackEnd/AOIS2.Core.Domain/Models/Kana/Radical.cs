using AOIS2.Core.Domain.Models.Kanji;
using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Domain.Models.JoinModels;
namespace AOIS2.Core.Domain.Models.Radicals
{
    public class Radical
    {
        public int Id { get; }
        public string Character { get; set; }
        public int Strokes { get; set; }
        public IEnumerable<KanjiWithReadingRadical> KanjiWithReadingRadicals { get; set; }
        public IEnumerable<KanjiWithWordsRadical> KanjiWithWordsRadicals { get; set; }
        public IEnumerable<KanjiWithReadingAndWordsRadical> KanjiWithReadingAndWordsRadicals { get; set; }
    }
}
