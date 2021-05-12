using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Rank
{
    public interface IRank<TModel, TUnitOfWork> 
        where TModel : class
        where TUnitOfWork : class
    {
        public TModel GetRank(TUnitOfWork unitOfWork,int maxSize);
    }
}
