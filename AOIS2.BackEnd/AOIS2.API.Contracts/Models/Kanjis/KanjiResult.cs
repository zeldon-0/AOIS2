using AOIS2.API.Contracts.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.API.Contracts.Models.Kanjis
{
    public class KanjiResult
    {
        public string Kanji { get; set; }
        public string Reading { get; set; }
        public int Strokes { get; set; }
        public string Words { get; set; }
        public IEnumerable<RadicalModel> Radicals { get; set; }
    }
}
