using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
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
