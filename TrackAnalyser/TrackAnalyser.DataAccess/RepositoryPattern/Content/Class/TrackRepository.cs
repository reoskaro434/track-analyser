using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<Track> FindEager(int trackId)
        {
            return await _db.Tracks.Include(p => p.Artist).Include(p => p.Canals).FirstOrDefaultAsync(p=>p.Id == trackId);
        }
    }
}
