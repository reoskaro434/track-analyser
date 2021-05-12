using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities;
using TrackAnalyser.Utilities.Rank;

namespace TrackAnalyser.Controllers
{
    public class RankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRank<RankViewModel, IUnitOfWork> _rank;
        public RankController(IUnitOfWork unitOfWork,IRank<RankViewModel,IUnitOfWork> rank)
        {
             _unitOfWork = unitOfWork;
            _rank = rank;
        }
       
        public IActionResult Index()
        {
            return View(_rank.GetRank(_unitOfWork, StaticDetails.RANK_MAX_TRACKS_AMOUNT));
        }
    }
}
