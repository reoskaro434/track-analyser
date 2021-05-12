﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.ChartModel;
using TrackAnalyser.Models.ChartModel.BarModel;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.Utilities.Charts.BarChart
{
    public class BarChart : IBarChart<IUnitOfWork>
    {
        public string GetTrackData(int id, IUnitOfWork unitOfWork)
        {
            IEnumerable<TrackStatistic> trackStatistics = unitOfWork.TrackStatistics.Find(p => p.TrackId == id);

            SortedList<string, BarDateCount> barDateCountList = new SortedList<string, BarDateCount>();

            foreach (var trackStat in trackStatistics)
            {
                IEnumerable<DayStatistic> dayStatistics = new List<DayStatistic>(
                   unitOfWork.DayStatistics.Find(p => p.TrackStatisticId == trackStat.Id));

                foreach (var dayStat in dayStatistics)
                {
                    var newBarDateCount = new BarDateCount()
                    {
                        Date = dayStat.Day.ToString(StaticDetails.DATE_FORMAT),
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

            return JsonConvert.SerializeObject(new BarChartModel() { BarDateCounts = barDateCountList.Values.ToArray() });
        }
    }
}
