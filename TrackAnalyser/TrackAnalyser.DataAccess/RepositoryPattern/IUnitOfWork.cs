using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.DataAccess.RepositoryPattern
{
    public interface IUnitOfWork : IDisposable
    {
        ITrackStatisticRepository TrackStatistics { get; }
        ITrackRepository Tracks { get; }
        ITrackEmissionRepository TrackEmissions { get; }
        ICanalRepository Canals { get; }
        IArtistRepository Artists { get; }
        IDayStatisticRepository DayStatistics  { get; }
        ICanalTrackRepository CanalTracks { get; }
        int Save();
    }
}
