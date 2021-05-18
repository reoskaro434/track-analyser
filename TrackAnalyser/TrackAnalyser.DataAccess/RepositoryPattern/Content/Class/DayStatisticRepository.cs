using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class DayStatisticRepository : Repository<DayStatistic>, IDayStatisticRepository
    {
        public DayStatisticRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
