using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface
{
    public interface ITrackEmissionRepository :IRepository<TrackEmission>
    {
        public IEnumerable<TrackEmission> GetEagerAll();
    }
}
