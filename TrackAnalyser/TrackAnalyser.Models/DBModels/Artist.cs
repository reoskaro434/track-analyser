using System.Collections.Generic;

namespace TrackAnalyser.Models.DBModels
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
