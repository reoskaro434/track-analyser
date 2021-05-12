using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.BroadcastFilter
{
    public interface IBroadcastFilter<TModel,TUnitOfWork>
        where TModel : class 
        where TUnitOfWork : class     
    {

        public Task<TModel> GetModelAsync(string text = "");
    }
}
