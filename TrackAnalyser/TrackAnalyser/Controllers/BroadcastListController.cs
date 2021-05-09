using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities.SortStrategy;
using TrackAnalyser.Utilities;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace TrackAnalyser.Controllers
{
    public class BroadcastListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SortStrategyContext _sortStrategyContext;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BroadcastListController(IUnitOfWork unitOfWork, IWebHostEnvironment env, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _sortStrategyContext = new SortStrategyContext();
            _env = env;
            _signInManager=signInManager;
        }
        private async Task<BroadcastListViewModel> GetModelAsync(string text = "")
        {
            IEnumerable<TrackEmission> trackEmissions = _unitOfWork.
                TrackEmissions.GetEagerAll().
                Where(x => x.Track.Title.Contains(text, StringComparison.OrdinalIgnoreCase));

            List<TrackEmissionViewModel> viewModelList = new List<TrackEmissionViewModel>();

            foreach (var element in trackEmissions)
            {

                Track track = await _unitOfWork.Tracks.FindEagerAsync(element.TrackId);
                viewModelList.Add(new TrackEmissionViewModel()
                {
                    CanalName = element.Canal.Name,
                    TrackPicturePath = element.Track.CoverPicturePath,
                    TrackDescription = element.Track.Description,
                    EmissionDate = element.BeginDateTime.ToString(StaticDetails.DATE_TIME_FORMAT),
                    EmissionTime = element.EmissionTime.ToString(StaticDetails.TIME_FORMAT),
                    TrackId = element.Track.Id,
                    ArtistName = track.Artist.Name,
                    TrackName = track.Title
                });
            }

            return new BroadcastListViewModel() { TrackEmissions = viewModelList };
        }

        public async Task<IActionResult> Index()
        {
            DataInitializer.SetDatabase(_unitOfWork);

            return View(await GetModelAsync());
        }

        public async Task<IActionResult> UpdateEmissionList(int sortNumber, int sortType, string text)
        {
            if (text == null)
                text = "";

            return PartialView(
                "_ShowTracks",
                _sortStrategyContext.Sort(await GetModelAsync(text), sortNumber, sortType));
        }

        [HttpGet]
        public async Task GetEmissionList(int sortNumber, int sortType, string text)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var user = _signInManager.Context.User.Identity.Name;
            var file = new FileInfo(_env.WebRootPath + @"\excel\" + user + ".xlsx");

            if (file.Exists)
                file.Delete();

            if (text == null)
                text = "";

            var rawModel = await GetModelAsync(text);

            var viewModel = _sortStrategyContext.Sort(rawModel, sortNumber, sortType);

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var range = ws.Cells["A1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.ArtistName), true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadEmissionList()
        {
            var user = _signInManager.Context.User.Identity.Name;
            var file = new FileInfo(_env.WebRootPath + @"\excel\" + user + ".xlsx");


            if (file.Exists)
            {
                FileStream RptStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                return File(RptStream, "application/vnd.ms-excel", "excel.xlsx");
            }
            return RedirectToAction("Index");
        }
    }
}
