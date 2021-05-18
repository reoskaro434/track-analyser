using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class CanalRepository :Repository<Canal>, ICanalRepository
    { 
        public CanalRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
