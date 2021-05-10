using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities.SortStrategy;
using TrackAnalyser.Utilities;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TrackAnalyser.Utilities.SortStrategyPatternForEmission;
using TrackAnalyser.Utilities.BroadcastFilter;
using TrackAnalyser.Models.DBModels;

namespace TrackAnalyser.Controllers
{
    public class BroadcastListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortStrategyContext<BroadcastListViewModel> _sortStrategyContext;
        private readonly IWebHostEnvironment _environment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBroadcastFilter<BroadcastListViewModel, IUnitOfWork> _broadcastFilter;

        public BroadcastListController(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment environment,
            SignInManager<ApplicationUser> signInManager,
            ISortStrategyContext<BroadcastListViewModel> sortStrategyContext,
            IBroadcastFilter<BroadcastListViewModel,IUnitOfWork> broadcastFilter
            )
        {
            _unitOfWork = unitOfWork;
            _sortStrategyContext = sortStrategyContext;
            _environment = environment;
            _signInManager = signInManager;
            _broadcastFilter = broadcastFilter;
        }

        public async Task<IActionResult> Index()
        {
            DataInitializer.SetDatabase(_unitOfWork);

            return View(await _broadcastFilter.GetModelAsync(_unitOfWork));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmissionList(int sortNumber, int sortType, string text)
        {
            if (text == null)
                text = "";

            return PartialView(
                "_ShowTracks",
                _sortStrategyContext.Sort(await _broadcastFilter.GetModelAsync(_unitOfWork,text), sortNumber, sortType));
        }

        [HttpGet]
        public async Task GetEmissionList(int sortNumber, int sortType, string text)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var user = _signInManager.Context.User.Identity.Name;
            var file = new FileInfo(_environment.WebRootPath + @"\excel\" + user + ".xlsx");

            if (file.Exists)
                file.Delete();

            if (text == null)
                text = "";

            var rawModel = await _broadcastFilter.GetModelAsync(_unitOfWork, text);

            var viewModel = _sortStrategyContext.Sort(rawModel, sortNumber, sortType);

            using var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var range = ws.Cells["A1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.ArtistName),true);
            ws.Cells["B1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.CanalName), true);
            ws.Cells["C1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.EmissionDate), true);
            ws.Cells["D1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.EmissionTime), true);
            ws.Cells["E1"].LoadFromCollection(viewModel.TrackEmissions.Select(p => p.TrackName), true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadEmissionList()
        {
            var user = _signInManager.Context.User.Identity.Name;
            var file = new FileInfo(_environment.WebRootPath + @"\excel\" + user + ".xlsx");


            if (file.Exists)
            {
                FileStream RptStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                return File(RptStream, "application/vnd.ms-excel", "excel.xlsx");
            }
            return RedirectToAction("Index");
        }
    }
}
