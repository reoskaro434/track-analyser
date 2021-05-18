using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using System;

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
        IApplicationUserRepository ApplicationUsers { get; }
        int Save();
        public void Migrate();
    }
}
