using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
{
    public class TrackStatistic
    {
        public int Id { get; set; }
        public Track Track { get; set; }
        public int PlayedTimes { get; set; }
    }
}
