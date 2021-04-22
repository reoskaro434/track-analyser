using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models;

namespace TrackAnalyser.Controllers
{
    public class BroadcastList : Controller
    {
        public IActionResult Index()
        {
            //Test
            List<TrackEmissionViewModel> trackEmissionList = new List<TrackEmissionViewModel>();
            TrackEmissionViewModel trackEmission = new TrackEmissionViewModel() { 
            CanalName = "Radio-Zet",
            TrackPicturePath = "/pictures/poison__the_parish.jpg",
            TrackDescription = "description description description description description",
            EmissionDate = "10.06.2021",
            EmissionTime = "5:32",
            TrackId = 13
            };
            trackEmissionList.Add(trackEmission);
            BroadcastListViewModel model = new BroadcastListViewModel() {
                TrackEmissions = trackEmissionList
            };
            return View(model);
        }
    }
}
