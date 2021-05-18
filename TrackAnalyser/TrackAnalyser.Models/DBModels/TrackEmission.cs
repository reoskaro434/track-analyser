using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackAnalyser.Models.DBModels
{
    public class TrackEmission
    {
        public int Id { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EmissionTime { get; set; }
        public int CanalId { get; set; }
        [ForeignKey("CanalId")]
        public Canal Canal { get; set; }
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track Track { get; set; }
    }
}
