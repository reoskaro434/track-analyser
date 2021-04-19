using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.Data;
using TrackAnalyser.DataAccess.RepositoryPattern.Content.Interface;
using TrackAnalyser.Models;

namespace TrackAnalyser.DataAccess.RepositoryPattern.Content.Class
{
    public class ArtistRepository :Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
