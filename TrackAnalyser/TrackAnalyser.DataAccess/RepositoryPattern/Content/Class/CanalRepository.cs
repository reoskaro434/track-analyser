using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models;
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
