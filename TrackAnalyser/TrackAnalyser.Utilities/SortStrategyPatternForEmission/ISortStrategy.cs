using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.SortStrategy
{
    public interface ISortStrategy
    {
        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModel);
    }
}
