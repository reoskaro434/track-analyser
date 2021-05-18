using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class CanalTrackRepository :Repository<CanalTrack>, ICanalTrackRepository
    {
        public CanalTrackRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
