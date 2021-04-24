
using Microsoft.AspNetCore.Mvc;
using System;
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
         //   IEnumerable<Canal> canals = _unitOfWork.Canals.Find(p => p.TrackStatistics == trackId);
            TrackStatistic trackStatistic = _unitOfWork.TrackStatistics.Find(p => p.TrackId == trackId).FirstOrDefault();
            List<BarDateCount> barDateCountList = new List<BarDateCount>();

            foreach (var element in trackStatistic.DayStatistics)
            {
                barDateCountList.Add(new BarDateCount() {Date = element.Day.ToString("dd / MM / yyyy"), Count = element.PlayedTimes});
            }

            return JsonConvert.SerializeObject(new BarChartModel() { BarDateCounts = barDateCountList.ToArray() });
        }
        private string GetPieChartData(int trackId)
        {
            TrackStatistic trackStatistic = _unitOfWork.TrackStatistics.Find(p => p.TrackId == trackId).FirstOrDefault();
            PieNameCount[] pieChartCounts = new PieNameCount[3];
            PieChartModel pieChartModel = new PieChartModel()
            {
                PieNameCounts = pieChartCounts
            };
            return JsonConvert.SerializeObject(pieChartModel);
        }
        private TrackDetailsViewModel GetModel(int trackId)
        {
            Track track = _unitOfWork.Tracks.Find(p => p.Id == trackId).FirstOrDefault();
            
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
            //TEST
            
/*            BarDateCount barDateCount0 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 12 };
            BarDateCount barDateCount1 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 51 };
            BarDateCount barDateCount2 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 31 };
            BarDateCount barDateCount3 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 44 };
            BarDateCount barDateCount4 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 114 };
      
            BarDateCount[] barDateCounts = new BarDateCount[5];
            barDateCounts[0] = barDateCount0;
            barDateCounts[1] = barDateCount1;
            barDateCounts[2] = barDateCount2;
            barDateCounts[3] = barDateCount3;
            barDateCounts[4] = barDateCount4;

            BarChartModel barChartModel = new BarChartModel() {
                BarDateCounts = barDateCounts 
            };

            PieNameCount pieNameCount0 = new PieNameCount() { Name = "Radio-Zet", Count = 32 };
            PieNameCount pieNameCount1 = new PieNameCount() { Name = "Radio-Eska", Count = 15 };
            PieNameCount pieNameCount2 = new PieNameCount() { Name = "RMF-FM", Count = 4 };
            PieNameCount[] pieChartCounts = new PieNameCount[3];

            pieChartCounts[0] = pieNameCount0;
            pieChartCounts[1] = pieNameCount1;
            pieChartCounts[2] = pieNameCount2;

            PieChartModel pieChartModel = new PieChartModel() {
                PieNameCounts = pieChartCounts
            };

            TrackDetailsViewModel model = new TrackDetailsViewModel() {
                Author = "Johny Silverhand",
                Begin = DateTime.Now, 
                CurrentCanal = new Canal() { Name = "Radio-Zet" },
                Description = "This is simple description about track which is being showed to user",
                LastPlayedWeek = JsonConvert.SerializeObject(barChartModel),
                Canals = JsonConvert.SerializeObject(pieChartModel),
                Duration = DateTime.Now.ToLongTimeString()
        };
            return View(model);*/



            if (trackId != null)
                return View(GetModel((int)trackId));
            else
                return View(new ErrorViewModel());
        }
    }
}
