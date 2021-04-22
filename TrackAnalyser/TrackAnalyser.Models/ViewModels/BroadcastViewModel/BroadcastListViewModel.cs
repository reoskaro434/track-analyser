using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.ViewModels
{
    public class BroadcastListViewModel
    {
        public IEnumerable<TrackEmissionViewModel> TrackEmissions { get; set; }
    }

}
