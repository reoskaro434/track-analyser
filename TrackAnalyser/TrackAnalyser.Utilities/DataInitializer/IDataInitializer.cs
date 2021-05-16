using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.DataInitializer
{
    public interface IDataInitializer<TUnitOfWork> where TUnitOfWork : class
    {
        /// <summary>
        /// Initialize DB for program presentation.
        /// </summary>
        public void SetDatabase();
    }
}
