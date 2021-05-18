using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class ArtistRepository :Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
