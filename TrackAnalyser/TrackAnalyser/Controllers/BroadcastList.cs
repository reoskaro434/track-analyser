using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities.SortStrategy;

namespace TrackAnalyser.Controllers
{
    public class BroadcastList : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SortStrategyContext _sortStrategyContext;
        private async Task<BroadcastListViewModel> GetModelAsync()
        {
            IEnumerable<TrackEmission> trackEmissions = _unitOfWork.TrackEmissions.GetEagerAll();
            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {

               Track track = await _unitOfWork.Tracks.FindEagerAsync(element.TrackId);
                viewModelList.Add(new TrackEmissionViewModel()
                {
                    CanalName = element.Canal.Name,
                    TrackPicturePath = element.Track.CoverPicturePath,
                    TrackDescription = element.Track.Description,
                    EmissionDate = element.BeginDateTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    EmissionTime = element.EmissionTime.ToString("mm:ss"),
                    TrackId = element.Track.Id,
                    ArtistName = track.Artist.Name,
                    TrackName = track.Title
                });
            }

            return new BroadcastListViewModel() {TrackEmissions = viewModelList};
        }
/*        private BroadcastListViewModel GetModel()
        {
            IEnumerable<TrackEmission> trackEmissions = _unitOfWork.TrackEmissions.GetEagerAll();
            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {

                Track track =  _unitOfWork.Tracks.FindEager(element.TrackId);
                viewModelList.Add(new TrackEmissionViewModel()
                {
                    CanalName = element.Canal.Name,
                    TrackPicturePath = element.Track.CoverPicturePath,
                    TrackDescription = element.Track.Description,
                    EmissionDate = element.BeginDateTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    EmissionTime = element.EmissionTime.ToString("mm:ss"),
                    TrackId = element.Track.Id,
                    ArtistName = track.Artist.Name,
                    TrackName = track.Title
                });
            }

            return new BroadcastListViewModel() { TrackEmissions = viewModelList };
        }*/

        public BroadcastList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sortStrategyContext = new SortStrategyContext();
        }

        public async Task<IActionResult> Index()
        {
            TrackAnalyser.Utilities.DataInitializer.SetDatabase(_unitOfWork);

            return View(await GetModelAsync());
        }

        public async Task<IActionResult> SortByDuration(int sortNumber, int sortType)
        {
            return  PartialView(
                "_ShowTracks", _sortStrategyContext.Sort(await GetModelAsync(), sortNumber,sortType));
        }
    }
}
