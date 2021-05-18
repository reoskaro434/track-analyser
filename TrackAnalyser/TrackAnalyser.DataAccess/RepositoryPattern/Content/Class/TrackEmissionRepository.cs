using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class TrackEmissionRepository : Repository<TrackEmission>, ITrackEmissionRepository
    {
        public TrackEmissionRepository(ApplicationDbContext db) : base(db)
        {

        }
        public IEnumerable<TrackEmission> GetEagerAll()
        {
            return _db.TrackEmissions.Include(p => p.Track).Include(p => p.Canal).ToList();
        }
    }
}
