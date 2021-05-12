using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.DataInitializer
{
    public interface IDataInitializer<TUnitOfWork> where TUnitOfWork : class
    {
        public void SetDatabase();
    }
}
