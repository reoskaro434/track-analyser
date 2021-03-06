using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<Track> FindEagerAsync(int trackId)
        {
            return await _db.Tracks.Include(p => p.Artist).Include(p => p.Canals).FirstOrDefaultAsync(p=>p.Id == trackId);
        }
    }
}
