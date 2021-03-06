using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.BroadcastFilter
{
    public class BroadcastFilter : IBroadcastFilter<BroadcastListViewModel, IUnitOfWork>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BroadcastFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IEnumerable<TrackEmission> GetTrackEmissions(string text)
        {
            return _unitOfWork.
                TrackEmissions.GetEagerAll().
                Where(x => x.Track.Title.Contains(text, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<BroadcastListViewModel> GetModelAsync(string text = "")
        {
            IEnumerable<TrackEmission> trackEmissions = GetTrackEmissions(text);

            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {

                Track track = await _unitOfWork.Tracks.FindEagerAsync(element.TrackId);
                viewModelList.Add(new TrackEmissionViewModel()
                {
                    CanalName = element.Canal.Name,
                    TrackPicturePath = element.Track.CoverPicturePath,
                    TrackDescription = element.Track.Description,
                    EmissionDate = element.BeginDateTime.ToString(StaticDetails.DATE_TIME_FORMAT),
                    EmissionTime = element.EmissionTime.ToString(StaticDetails.TIME_FORMAT),
                    TrackId = element.Track.Id,
                    ArtistName = track.Artist.Name,
                    TrackName = track.Title
                });
            }

            return new BroadcastListViewModel() { TrackEmissions = viewModelList };
        }
    }
}
