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

        private BroadcastListViewModel getModel()
        {
            IEnumerable<TrackEmission> trackEmissions = _unitOfWork.TrackEmissions.GetAll();
            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {
                viewModelList.Add(new TrackEmissionViewModel()
                {
                    CanalName = element.Canal.Name,
                    TrackPicturePath = element.Track.CoverPicturePath,
                    TrackDescription = element.Track.Description,
                    EmissionDate = element.BeginDateTime.ToString("dd/MM/yyyy"),
                    EmissionTime = element.EmissionTime.ToString("mm:ss"),
                    TrackId = element.Track.Id
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
            //Test
/*            List<TrackEmissionViewModel> trackEmissionList = new List<TrackEmissionViewModel>();
            TrackEmissionViewModel trackEmission = new TrackEmissionViewModel()
            {
                CanalName = "Radio-Zet",
                TrackPicturePath = "/pictures/poison__the_parish.jpg",
                TrackDescription = "description description description description description",
                EmissionDate = "10.06.2021",
                EmissionTime = "5:32",
                TrackId = 13
            };
            trackEmissionList.Add(trackEmission);
            BroadcastListViewModel model = new BroadcastListViewModel()
            {
                TrackEmissions = trackEmissionList
            };
            return View(model);*/

            TrackAnalyser.Utilities.DataInitializer.SetDatabase(_unitOfWork);

            return View(getModel());
        }
    }
}
