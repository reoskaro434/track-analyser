using System;
using System.Collections.Generic;
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
        public Canal Canal { get; set; }
    }
}
