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
    public class DayStatisticRepository : Repository<DayStatistic>, IDayStatisticRepository
    {
        public DayStatisticRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
