using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Controllers
{
    public class RankController : Controller
    {
        public IActionResult Index()
        {
            List<RankElementViewModel> rankElements = new List<RankElementViewModel>();

            rankElements.Add(new RankElementViewModel() {TrackArtist = "Armin Van Buuren",TrackName = "Save My Night" });
            rankElements.Add(new RankElementViewModel() {TrackArtist = "Savant",TrackName = "Slasher" });
            rankElements.Add(new RankElementViewModel() {TrackArtist = "Infected Mushrooms", TrackName = " Becoming Insane" });
            rankElements.Add(new RankElementViewModel() {TrackArtist = "Mark Forster", TrackName= "Kogon" });
            rankElements.Add(new RankElementViewModel() {TrackArtist = "Five Finger Death Punch", TrackName = "I Apologize" });
            RankViewModel rankViewModel = new RankViewModel() { 
                RankElements = rankElements
            };
            return View(rankViewModel);
        }
    }
}
