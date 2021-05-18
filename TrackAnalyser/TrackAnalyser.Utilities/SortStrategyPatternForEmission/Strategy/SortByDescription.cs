using System.Linq;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.SortStrategy.Strategy
{
    public class SortByDescription : ISortStrategy
    {
        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModel)
        {
            broadcastListViewModel.TrackEmissions =
                           broadcastListViewModel.TrackEmissions.OrderBy(o => o.TrackDescription);
            return broadcastListViewModel;
        }
    }
}
