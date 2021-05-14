using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TrackAnalyser.Utilities.SortStrategyPatternForEmission;
using TrackAnalyser.Utilities.BroadcastFilter;
using TrackAnalyser.Models.DBModels;
using Microsoft.AspNetCore.Authorization;
using TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator;
using TrackAnalyser.Utilities.ExcelSheet.ExcelSheetConverter;
using TrackAnalyser.Models.ExcelSheetModel;
using System.IO;

namespace TrackAnalyser.Controllers
{
    [Authorize]
    public class BroadcastListController : Controller
    {
        private readonly ISortStrategyContext<BroadcastListViewModel> _sortStrategyContext;
        private readonly IWebHostEnvironment _environment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBroadcastFilter<BroadcastListViewModel, IUnitOfWork> _broadcastFilter;
        private readonly IExcelSheetCreator<BroadcastListViewModel,ExcelSheetModel> _excelSheetCreator;
        private readonly IExcelSheetConverter _excelSheetConverter;

        public BroadcastListController(
            IWebHostEnvironment environment,
            SignInManager<ApplicationUser> signInManager,
            ISortStrategyContext<BroadcastListViewModel> sortStrategyContext,
            IBroadcastFilter<BroadcastListViewModel,IUnitOfWork> broadcastFilter,
            IExcelSheetCreator<BroadcastListViewModel, ExcelSheetModel> excelSheetCreator,
            IExcelSheetConverter excelSheetConverter
            )
        {
            _sortStrategyContext = sortStrategyContext;
            _environment = environment;
            _signInManager = signInManager;
            _broadcastFilter = broadcastFilter;
            _excelSheetCreator = excelSheetCreator;
            _excelSheetConverter = excelSheetConverter;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _broadcastFilter.GetModelAsync());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmissionList(int sortNumber, int sortType, string text)
        {
            if (text == null)
                text = "";

            return PartialView(
                "_ShowTracks",
                _sortStrategyContext.Sort(await _broadcastFilter.GetModelAsync(text), sortNumber, sortType));
        }

        [HttpGet]
        public async Task GetEmissionList(int sortNumber, int sortType, string text)
        {  
            if (text == null)
                text = "";
            
            var user = _signInManager.Context.User.Identity.Name;

            var rawModel = await _broadcastFilter.GetModelAsync( text);

            var viewModel = _sortStrategyContext.Sort(rawModel, sortNumber, sortType);

            _excelSheetCreator.CreateExcelSheetAsync(viewModel, _environment.WebRootPath + @"\excel\" + user + ".xlsx");
        }


        [HttpGet]
        public IActionResult DownloadEmissionList()
        {
            var user = _signInManager.Context.User.Identity.Name;

            var path = _environment.WebRootPath + @"\excel\" + user + ".xlsx";

            var byteArray = _excelSheetConverter.ConvertToByteArray(path);

            if (byteArray != null)
            {
                new FileInfo(path).Delete();

                return File(byteArray, StaticDetails.EXCEL_SHEET_CONTENT_TYPE, StaticDetails.EXCEL_SHEET_NAME);
            }
            return RedirectToAction("Index");
        }
    }
}
