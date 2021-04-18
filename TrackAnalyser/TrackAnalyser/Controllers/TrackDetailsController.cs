﻿
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Controllers
{
    public class TrackDetailsController : Controller
    {
        public IActionResult Index()
        {
            TrackDetailsViewModel model = new TrackDetailsViewModel() {
                Author = "Johny Silverhand",
                Begin = DateTime.Now,
                Canals = "JSON JSON",
                CurrentCanal = new Models.Canal() { Name = "Radio-Zet" },
                Description = "This is simple description about track which is being showed to user",
                LastPlayedWeek = "JSON JSON",
                Duration = DateTime.Now.ToLongTimeString()
        };
            return View(model);

        }
    }
}
