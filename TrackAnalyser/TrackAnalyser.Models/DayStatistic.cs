using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
{
    public class DayStatistic
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int PlayedTimes { get; set; }
    }
}
