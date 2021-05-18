using System.Threading.Tasks;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface
{
    public interface ITrackRepository : IRepository<Track>
    {
        public Task<Track> FindEagerAsync(int trackId);
    }
}
