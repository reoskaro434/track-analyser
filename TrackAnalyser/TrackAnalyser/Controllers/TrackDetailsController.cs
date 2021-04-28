
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Models;
using TrackAnalyser.Models.ChartModel;
using Newtonsoft.Json;
using TrackAnalyser.Models.ChartModel.BarModel;
using TrackAnalyser.Models.ChartModel.PieModel;
using TrackAnalyser.DataAccess.RepositoryPattern;

namespace TrackAnalyser.Controllers
{
   
    public class TrackDetailsController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TrackDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private string GetBarChartData(int trackId)
        {
            IEnumerable<TrackStatistic> trackStatistics = _unitOfWork.TrackStatistics.Find(p => p.TrackId == trackId);

            SortedList<string,BarDateCount> barDateCountList = new SortedList<string,BarDateCount>();

            foreach (var trackStat in trackStatistics)
            {
                IEnumerable<DayStatistic> dayStatistics = new List<DayStatistic>(
                    _unitOfWork.DayStatistics.Find(p => p.TrackStatisticId == trackStat.Id));

                foreach (var dayStat in dayStatistics)
                {
                    var newBarDateCount = new BarDateCount()
                    {
                        Date = dayStat.Day.ToString("dd / MM / yyyy"),
                        Count = dayStat.PlayedTimes
                    };
              
                    var oldBarDateCount = barDateCountList.Where(p=>p.Key==newBarDateCount.Date);

                    if (oldBarDateCount.FirstOrDefault().Key == null)
                        barDateCountList.Add(newBarDateCount.Date, newBarDateCount);
                    else
                        barDateCountList[oldBarDateCount.FirstOrDefault().Key].Count =
                            oldBarDateCount.FirstOrDefault().Value.Count + newBarDateCount.Count;
                }
            }
                
            return JsonConvert.SerializeObject(new BarChartModel() { BarDateCounts = barDateCountList.Values.ToArray() });
        }
        private string GetPieChartData(int trackId)
        {
            IEnumerable<CanalTrack> canalTracks = _unitOfWork.Tracks.FindEager(trackId).Canals;
            IEnumerable<TrackStatistic> trackStatistics = _unitOfWork.TrackStatistics.Find(p => p.TrackId == trackId);
            List<PieNameCount> pieNameCountList = new List<PieNameCount>();

            foreach (var trackStatistic in trackStatistics)
            {
                Canal canal = _unitOfWork.Canals.Find(p => p.Id == trackStatistic.CanalId).FirstOrDefault();
                IEnumerable<DayStatistic> dayStatistics = new List<DayStatistic>(
                    _unitOfWork.DayStatistics.Find(p1 => p1.TrackStatisticId == trackStatistic.Id));

                int sum = 0;
                foreach(var dayStat in dayStatistics)
                  sum+= dayStat.PlayedTimes;

                pieNameCountList.Add(new PieNameCount() {Name=canal.Name,Count=sum});
            }

            return JsonConvert.SerializeObject(new PieChartModel() { PieNameCounts = pieNameCountList.ToArray() });
            /*PieNameCount pieNameCount0 = new PieNameCount() { Name = "Radio-Zet", Count = 32 };
            PieNameCount pieNameCount1 = new PieNameCount() { Name = "Radio-Eska", Count = 15 };
            PieNameCount pieNameCount2 = new PieNameCount() { Name = "RMF-FM", Count = 4 };
            PieNameCount[] pieChartCounts = new PieNameCount[3];

            pieChartCounts[0] = pieNameCount0;
            pieChartCounts[1] = pieNameCount1;
            pieChartCounts[2] = pieNameCount2;

            PieChartModel pieChartModel = new PieChartModel()
            {
                PieNameCounts = pieChartCounts
            };

            return JsonConvert.SerializeObject(pieChartModel);*/
        }
        private TrackDetailsViewModel GetModel(int trackId)
        {
            Track track = _unitOfWork.Tracks.FindEager(trackId);
            
            return new TrackDetailsViewModel()
            {
                Author = track.Artist.Name,
                Description = track.Description,
                Version = track.Version,
                LastPlayedWeek = GetBarChartData(trackId),
                Canals = GetPieChartData(trackId),
                Duration = track.Duration.ToString("mm/ss")
           };
        }
        public IActionResult Index(int? trackId)
        {
            if (trackId != null)
                return View(GetModel((int)trackId));
            else
                return View(new ErrorViewModel());
        }
    }
}
