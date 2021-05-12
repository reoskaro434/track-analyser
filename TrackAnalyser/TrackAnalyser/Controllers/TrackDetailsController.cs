﻿
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Models.ChartModel;
using Newtonsoft.Json;
using TrackAnalyser.Models.ChartModel.BarModel;
using TrackAnalyser.Models.ChartModel.PieModel;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Utilities.Charts.BarChart;
using TrackAnalyser.Utilities.Charts.PieChart;

namespace TrackAnalyser.Controllers
{

    public class TrackDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBarChart<IUnitOfWork> _barChart;
        private readonly IPieChart<IUnitOfWork> _pieChart;

        public TrackDetailsController(IUnitOfWork unitOfWork,
            IBarChart<IUnitOfWork> barChart,
            IPieChart<IUnitOfWork> pieChart)
        {
            _unitOfWork = unitOfWork;
            _barChart = barChart;
            _pieChart = pieChart;
        }
    
        private async Task<TrackDetailsViewModel> GetModel(int trackId)
        {
            Track track = await _unitOfWork.Tracks.FindEagerAsync(trackId);
            
            return new TrackDetailsViewModel()
            {
                Author = track.Artist.Name,
                Description = track.Description,
                Version = track.Version,
                LastPlayedWeek = _barChart.GetTrackData(trackId,_unitOfWork),
                Canals = await _pieChart.GetTrackDataAsync(trackId, _unitOfWork),
                Duration = track.Duration.ToString(StaticDetails.TIME_FORMAT)
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
