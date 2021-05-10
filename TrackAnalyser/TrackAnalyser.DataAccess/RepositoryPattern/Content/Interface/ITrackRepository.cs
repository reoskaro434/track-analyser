using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface
{
    public interface ITrackRepository : IRepository<Track>
    {
        public Task<Track> FindEagerAsync(int trackId);
     //   public Track FindEager(int trackId);
    }
}
