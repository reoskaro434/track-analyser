using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Charts.PieChart
{
    public interface IPieChart<TUnitOfWork> where TUnitOfWork : class
    {
        /// <summary>
        /// Return JSON string which contain data for creating chart.
        /// </summary>
        /// <param name="id">Id of track.</param>
        /// <returns></returns>
        public Task<string> GetTrackDataAsync(int id);
    }
}
