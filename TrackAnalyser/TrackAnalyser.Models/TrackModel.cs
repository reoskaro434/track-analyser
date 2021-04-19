using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models
{
    public class TrackModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ArtistModel Artist { get; set; }
        public DateTime Duration { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string CoverPicturePath { get; set; }
    }
}
