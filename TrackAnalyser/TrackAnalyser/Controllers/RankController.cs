using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAnalyser.Controllers
{
    public class RankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
