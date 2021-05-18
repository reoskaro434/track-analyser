using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Charts.PieChart
{
    public interface IPieChart<TUnitOfWork> where TUnitOfWork : class
    {
        /// <summary>
        /// Return JSON string which contain data for creating chart.
        /// </summary>
        /// <param name="id">Id of track.</param>
        /// <returns>JSON data for chart creation.</returns>
        public Task<string> GetTrackDataAsync(int id);
    }
}
