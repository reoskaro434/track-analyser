using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities;
using TrackAnalyser.Utilities.Rank;

namespace TrackAnalyser.Controllers
{
    public class RankController : Controller
    {
        private readonly IRank<RankViewModel, IUnitOfWork> _rank;
        public RankController(IRank<RankViewModel,IUnitOfWork> rank)
        {
            _rank = rank;
        }
       
        public IActionResult Index()
        {
            return View(_rank.GetRank(StaticDetails.RANK_MAX_TRACKS_AMOUNT));
        }
    }
}
