using AOIS2.Core.Domain.Models.Radicals;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOIS2.Core.Domain.Models.SearchModels
{
    public class KanjiSearchModel
    {
        public int Id { get; set; }
        public string Kanji { get; set; }
        public string Reading { get; set; }
        public int Strokes { get; set; }
        public string Words { get; set; }
        public double Probability { get; set; }
        public IEnumerable<Radical> Radicals { get; set; }
    }
}
