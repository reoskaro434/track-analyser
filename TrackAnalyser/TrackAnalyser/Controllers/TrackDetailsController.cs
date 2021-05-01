
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
        private async Task<string> GetPieChartDataAsync(int trackId)
        {
            Track track = await _unitOfWork.Tracks.FindEagerAsync(trackId);
            IEnumerable<CanalTrack> canalTracks = track.Canals;
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
        }
        private async Task<TrackDetailsViewModel> GetModel(int trackId)
        {
            Track track = await _unitOfWork.Tracks.FindEagerAsync(trackId);
            
            return new TrackDetailsViewModel()
            {
                Author = track.Artist.Name,
                Description = track.Description,
                Version = track.Version,
                LastPlayedWeek = GetBarChartData(trackId),
                Canals = GetPieChartDataAsync(trackId).Result,
                Duration = track.Duration.ToString("mm/ss")
           };
        }
        public async Task<IActionResult> Index(int? trackId)
        {
            if (trackId != null)
                return View(await GetModel((int)trackId));
            else
                return View(new ErrorViewModel());
        }
    }
}
