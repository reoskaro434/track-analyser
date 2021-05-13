using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.ChartModel;
using TrackAnalyser.Models.ChartModel.BarModel;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.Utilities.Charts.BarChart
{
    public class BarChart : IBarChart<IUnitOfWork>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BarChart(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string GetTrackData(int id, int amount,string dateFormat)
        {
            IEnumerable<TrackStatistic> trackStatistics = _unitOfWork.TrackStatistics.Find(p => p.TrackId == id);

            SortedList<string, BarDateCount> barDateCountList = new SortedList<string, BarDateCount>();

            foreach (var trackStat in trackStatistics)
            {
                IEnumerable<DayStatistic> dayStatistics = new List<DayStatistic>(
                   _unitOfWork.DayStatistics.Find(p => p.TrackStatisticId == trackStat.Id));

                foreach (var dayStat in dayStatistics)
                {
                    var newBarDateCount = new BarDateCount()
                    {
                        Date = dayStat.Day.ToString(dateFormat),
                        Count = dayStat.PlayedTimes
                    };

                    var oldBarDateCount = barDateCountList.Where(p => p.Key == newBarDateCount.Date);

                    if (oldBarDateCount.FirstOrDefault().Key == null)
                        barDateCountList.Add(newBarDateCount.Date, newBarDateCount);
                    else
                        barDateCountList[oldBarDateCount.FirstOrDefault().Key].Count =
                            oldBarDateCount.FirstOrDefault().Value.Count + newBarDateCount.Count;
                }
            }
 
            return JsonConvert.SerializeObject(new BarChartModel() { BarDateCounts = barDateCountList.Values.Take(amount).ToArray() });
        }
    }
}
