using TrackAnalyser.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Class;

namespace TrackAnalyser.DataAccess.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ITrackStatisticRepository TrackStatistics { get; private set; }

        public ITrackRepository Tracks { get; private set; }

        public ITrackEmissionRepository TrackEmissions { get; private set; }

        public ICanalRepository Canals { get; private set; }

        public IArtistRepository Artists { get; private set; }

        public IDayStatisticRepository DayStatistics { get; private set; }
        public ICanalTrackRepository CanalTracks { get; private set; }
        public IApplicationUserRepository ApplicationUsers { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TrackStatistics = new TrackStatisticRepository(db);
            Tracks = new TrackRepository(db);
            TrackEmissions = new TrackEmissionRepository(db);
            Canals = new CanalRepository(db);
            Artists = new ArtistRepository(db);
            DayStatistics = new DayStatisticRepository(db);
            CanalTracks = new CanalTrackRepository(db);
            ApplicationUsers = new ApplicationUserRepository(db);
        }
        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
