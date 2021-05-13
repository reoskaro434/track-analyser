
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Utilities.Charts.BarChart;
using TrackAnalyser.Utilities.Charts.PieChart;
using Microsoft.AspNetCore.Authorization;

namespace TrackAnalyser.Controllers
{
    [Authorize]
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
                LastPlayedWeek = _barChart.GetTrackData(trackId),
                Canals = await _pieChart.GetTrackDataAsync(trackId),
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
