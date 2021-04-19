﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
{
    public class CanalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TrackStatistic> TrackStatistics { get; set; }
    }
}
