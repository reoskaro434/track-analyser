using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities.SortStrategy.Strategy;

namespace TrackAnalyser.Utilities.SortStrategy
{
    public class SortStrategyContext
    {
        private ISortStrategy _sortStrategy;

        public SortStrategyContext(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public SortStrategyContext()
        {
        }

        void SetStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public BroadcastListViewModel Sort(BroadcastListViewModel broadcastListViewModels, int sortNumber,int sortType)
        {
            switch(sortNumber)
            {
                case StaticDetails.SORT_BY_CANAL:
                    SetStrategy(new SortByCanal());
                    break;
                case StaticDetails.SORT_BY_DURATION:
                    SetStrategy(new SortByDuration());
                    break;
                case StaticDetails.SORT_BY_EMISSION_DATE:
                    SetStrategy(new SortByEmissionDate());
                    break;
                case StaticDetails.SORT_BY_DESCRIPTION:
                    SetStrategy(new SortByDescription());
                    break;
                default:
                    SetStrategy(new SortByNone());
                    break;
            }

            if (sortType == StaticDetails.SORT_DESCENDING)
            {
                broadcastListViewModels.TrackEmissions =_sortStrategy.Sort(broadcastListViewModels).TrackEmissions.Reverse();
                return broadcastListViewModels;
            }
           return _sortStrategy.Sort(broadcastListViewModels);

        }
    }
}
