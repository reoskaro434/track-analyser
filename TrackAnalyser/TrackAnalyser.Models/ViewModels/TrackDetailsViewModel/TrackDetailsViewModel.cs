using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models;

namespace TrackAnalyser.Models.ViewModels
{
    public class TrackDetailsViewModel
    {
        public string TrackName { get; set; }
        public string Author { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string LastPlayed { get; set; }
        public string Canals { get; set; }
        public string Version { get; set; }
    }
}
