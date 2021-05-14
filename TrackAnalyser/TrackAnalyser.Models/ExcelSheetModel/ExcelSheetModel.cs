using System.ComponentModel;

namespace TrackAnalyser.Models.ExcelSheetModel
{
    public class ExcelSheetModel
    {        
        [DisplayName("No.")]
        public int Number { get; set; }
        [DisplayName("Track Name")]
        public string TrackName { get; set; }
        [DisplayName("Track Artist")]
        public string TrackArtist { get; set; }
        [DisplayName("Canal Name")]
        public string CanalName { get; set; } 
        [DisplayName("Emission Date")]
        public string EmissionDate { get; set; }
        [DisplayName("Emission Duration")]
        public string EmissionDuration { get; set; }
    }
}
