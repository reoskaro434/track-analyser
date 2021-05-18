using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.SortStrategy.Strategy
{
    public class SortByNone : ISortStrategy
    {
        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModel)
        {
            return broadcastListViewModel;
        }
    }
}
