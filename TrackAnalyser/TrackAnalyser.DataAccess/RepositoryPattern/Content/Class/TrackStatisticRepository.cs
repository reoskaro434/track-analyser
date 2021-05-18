using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class TrackStatisticRepository : Repository<TrackStatistic>, ITrackStatisticRepository
    {
        public TrackStatisticRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
