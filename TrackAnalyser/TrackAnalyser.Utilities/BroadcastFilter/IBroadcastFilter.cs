using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.BroadcastFilter
{
    public interface IBroadcastFilter<TModel,TDBContext>
        where TModel : class 
        where TDBContext : class     
    {

        public Task<TModel> GetModelAsync(TDBContext unitOfWork, string text = "");
    }
}
