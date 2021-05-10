using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
