﻿using System;
using System.Collections.Generic;
using System.Text;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Domain.Models.Radicals;

namespace AOIS2.Core.Domain.Models.JoinModels
{
    public class KanjiWithReadingRadical
    {
        public int RadicalId { get; set; }
        public int KanjiWithReadingId { get; set; }
        public Radical Radical { get; set; }
        public KanjiWithReading KanjiWithReading  { get; set; }
    }
}
