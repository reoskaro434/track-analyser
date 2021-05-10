using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.DBModels
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("ArtistId")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime Duration { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string CoverPicturePath { get; set; }
        public IEnumerable<CanalTrack> Canals { get; set; }
    }
}
