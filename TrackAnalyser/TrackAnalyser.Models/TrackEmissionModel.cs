using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
{
    public class TrackEmissionModel
    {
        public int Id { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EmissionTime { get; set; }
        public CanalModel Canal { get; set; }
    }
}
