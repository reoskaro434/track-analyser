using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models;
using TrackAnalyser.DataAccess.RepositoryPattern;

namespace TrackAnalyser.Controllers
{
    public class BroadcastList : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private BroadcastListViewModel GetModel()
        {
            IEnumerable<TrackEmission> trackEmissions = _unitOfWork.TrackEmissions.GetEagerAll();
            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {

               Track track = _unitOfWork.Tracks.FindEager(element.TrackId);
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

        public BroadcastList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            TrackAnalyser.Utilities.DataInitializer.SetDatabase(_unitOfWork);

            return View(GetModel());
        }

        public IActionResult SortByDuration()
        {
            BroadcastListViewModel model = GetModel();
            model.TrackEmissions.OrderBy(o => o.EmissionTime);
            model.TrackEmissions = model.TrackEmissions.OrderBy(o => o.EmissionTime).ToList();
            return PartialView( "_ShowTracks",model);
        }
    }
}
