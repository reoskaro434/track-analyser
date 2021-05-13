using System;
using System.Linq;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities.SortStrategy.Strategy;
using TrackAnalyser.Utilities.SortStrategyPatternForEmission;

namespace TrackAnalyser.Utilities.SortStrategy
{
    public class SortStrategyContext : ISortStrategyContext<BroadcastListViewModel>
    {
        private ISortStrategy _sortStrategy;

        public SortStrategyContext(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public SortStrategyContext()
        {
        }

        public void SetStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public BroadcastListViewModel Sort(BroadcastListViewModel model, int sortNumber, int sortType)
        {
            switch (sortNumber)
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
                model.TrackEmissions = _sortStrategy.Sort(model).TrackEmissions.Reverse();
                return model;
            }
            return _sortStrategy.Sort(model);

        }
    }
}
