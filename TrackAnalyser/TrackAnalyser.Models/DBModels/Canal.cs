using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.DBModels
{
    public class Canal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TrackStatistic> TrackStatistics { get; set; }
        public IEnumerable<CanalTrack> Tracks { get; set; }
    }
}
