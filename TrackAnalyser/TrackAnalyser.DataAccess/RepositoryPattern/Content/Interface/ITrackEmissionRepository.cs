using System.Collections.Generic;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface
{
    public interface ITrackEmissionRepository :IRepository<TrackEmission>
    {
        public IEnumerable<TrackEmission> GetEagerAll();
    }
}
