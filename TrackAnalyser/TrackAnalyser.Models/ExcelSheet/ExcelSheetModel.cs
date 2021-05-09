using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Models.ExcelSheet
{
    public class ExcelSheetModel
    {
        public string TrackDescription { get; set; }
        public string CanalName { get; set; }
        public string EmissionDate { get; set; }
        public string EmissionTime { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
    }
}
