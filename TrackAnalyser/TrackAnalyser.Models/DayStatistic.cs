using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int TrackStatisticId { get; set; }

        [ForeignKey("TrackStatisticId")]
        public TrackStatistic TrackStatistic { get; set; }
    }
}
