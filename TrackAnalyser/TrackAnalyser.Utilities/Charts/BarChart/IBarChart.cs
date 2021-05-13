using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Charts.BarChart
{
    public interface IBarChart<TUnitOfWork> where TUnitOfWork : class
    {
        public string GetTrackData(int id, int amoun, string dateFormat);
    }
}
