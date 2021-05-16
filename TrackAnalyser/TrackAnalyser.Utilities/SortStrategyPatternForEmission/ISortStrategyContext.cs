﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Utilities.SortStrategy;

namespace TrackAnalyser.Utilities.SortStrategyPatternForEmission
{
    public interface ISortStrategyContext<TModel> where TModel : class
    {
        /// <summary>
        /// Sets chosen strategy.
        /// </summary>
        /// <param name="sortStrategy">New strategy/</param>
        public void SetStrategy(ISortStrategy sortStrategy);
        public TModel Sort(TModel model, int sortNumber, int sortType);
    }
}
