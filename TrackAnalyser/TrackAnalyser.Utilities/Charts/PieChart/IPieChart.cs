using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.Charts.PieChart
{
    public interface IPieChart<TUnitOfWork> where TUnitOfWork : class
    {
        public Task<string> GetTrackDataAsync(int id, TUnitOfWork unitOfWork);
    }
}
