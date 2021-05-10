using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.DBModels
{
    public class CanalTrack
    {
        public int CanalId { get; set; }
        public Canal Canal { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
    }
}
