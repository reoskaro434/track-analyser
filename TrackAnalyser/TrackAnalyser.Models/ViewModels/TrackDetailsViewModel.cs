using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.ViewModels
{
    public class TrackDetailsViewModel
    {
        public string Author { get; set; }
        public Canal CurrentCanal { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public DateTime Begin { get; set; }
        public IEnumerable<int> LastPlayedWeek { get; set; }
        public IEnumerable<Canal> Canals { get; set; }
    }
}
