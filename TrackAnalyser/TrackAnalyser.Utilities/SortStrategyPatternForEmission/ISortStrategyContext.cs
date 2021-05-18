using System;
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
        /// <summary>
        /// Sorts model using parameters given by user.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="sortNumber">Determines parameter which model is sorting by.</param>
        /// <param name="sortType">Determines which kind of sort it is, ascending or descending.</param>
        /// <returns></returns>
        public TModel Sort(TModel model, int sortNumber, int sortType);
    }
}
