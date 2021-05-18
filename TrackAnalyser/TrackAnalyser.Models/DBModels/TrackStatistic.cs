using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackAnalyser.Models.DBModels
{
    public class TrackStatistic
    {
        public int Id { get; set; }

        [ForeignKey("TrackId")]
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public IEnumerable<DayStatistic> DayStatistics { get; set; }

        [ForeignKey("CanalId")]
        public int CanalId { get; set; }
        public Canal Canal { get; set; }
    }
}
