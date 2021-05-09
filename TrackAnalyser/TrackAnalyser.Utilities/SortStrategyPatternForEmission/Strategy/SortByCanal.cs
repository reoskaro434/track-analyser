using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.SortStrategy.Strategy
{
    public class SortByCanal : ISortStrategy
    {
        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModel)
        {
            broadcastListViewModel.TrackEmissions =
               broadcastListViewModel.TrackEmissions.OrderBy(o => o.CanalName);
            return broadcastListViewModel;

        }
    }
}
