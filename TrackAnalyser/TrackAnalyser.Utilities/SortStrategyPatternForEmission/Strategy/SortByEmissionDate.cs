using System.Linq;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.SortStrategy.Strategy
{
    public class SortByEmissionDate : ISortStrategy
    {
        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModel)
        {
            broadcastListViewModel.TrackEmissions =
                broadcastListViewModel.TrackEmissions.OrderBy(o => o.EmissionDate);
            return broadcastListViewModel;
        }
    }
}
