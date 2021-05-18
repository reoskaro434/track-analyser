using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackAnalyser.Models.DBModels
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
