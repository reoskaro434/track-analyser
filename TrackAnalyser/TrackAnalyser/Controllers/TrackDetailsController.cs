
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

namespace TrackAnalyser.Controllers
{
    public class TrackDetailsController : Controller
    {
        public IActionResult Index()
        {
            //TEST

            BarDateCount barDateCount0 = new BarDateCount() { Date = DateTime.Now.ToString("dd/MM/yyyy"), Count = 12 };
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
            return View(model);

        }
    }
}
