using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.ChartModel;
using TrackAnalyser.Models.ChartModel.PieModel;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.Utilities.Charts.PieChart
{
    public class PieChart : IPieChart<IUnitOfWork>
    {
        IUnitOfWork _unitOfWork;

        public PieChart(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> GetTrackDataAsync(int id)
        {
            Track track = await _unitOfWork.Tracks.FindEagerAsync(id);
            IEnumerable<CanalTrack> canalTracks = track.Canals;
            IEnumerable<TrackStatistic> trackStatistics = _unitOfWork.TrackStatistics.Find(p => p.TrackId == id);
            List<PieNameCount> pieNameCountList = new List<PieNameCount>();

            foreach (var trackStatistic in trackStatistics)
            {
                Canal canal = _unitOfWork.Canals.Find(p => p.Id == trackStatistic.CanalId).FirstOrDefault();
                IEnumerable<DayStatistic> dayStatistics = new List<DayStatistic>(
                    _unitOfWork.DayStatistics.Find(p1 => p1.TrackStatisticId == trackStatistic.Id));

                int sum = 0;
                foreach (var dayStat in dayStatistics)
                    sum += dayStat.PlayedTimes;

                pieNameCountList.Add(new PieNameCount() { Name = canal.Name, Count = sum });
            }

            return JsonConvert.SerializeObject(new PieChartModel() { PieNameCounts = pieNameCountList.ToArray() });
        }
    }
}
