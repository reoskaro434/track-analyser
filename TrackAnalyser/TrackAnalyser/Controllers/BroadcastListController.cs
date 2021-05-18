using Microsoft.AspNetCore.Mvc;
using TrackAnalyser.Models.ViewModels;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Utilities;
using TrackAnalyser.Utilities.SortStrategyPatternForEmission;
using TrackAnalyser.Utilities.BroadcastFilter;
using Microsoft.AspNetCore.Authorization;
using TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator;
using TrackAnalyser.Models.ExcelSheetModel;

namespace TrackAnalyser.Controllers
{
    [Authorize]
    public class BroadcastListController : Controller
    {
        private readonly ISortStrategyContext<BroadcastListViewModel> _sortStrategyContext;
        private readonly IBroadcastFilter<BroadcastListViewModel, IUnitOfWork> _broadcastFilter;
        private readonly IExcelSheetCreator<BroadcastListViewModel,ExcelSheetModel> _excelSheetCreator;

        public BroadcastListController(
            ISortStrategyContext<BroadcastListViewModel> sortStrategyContext,
            IBroadcastFilter<BroadcastListViewModel,IUnitOfWork> broadcastFilter,
            IExcelSheetCreator<BroadcastListViewModel, ExcelSheetModel> excelSheetCreator
            )
        {
            _sortStrategyContext = sortStrategyContext;
            _broadcastFilter = broadcastFilter;
            _excelSheetCreator = excelSheetCreator;
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
        public void InitializeDownload()
        {
            //necessary for proper excel sheet download
        }

        [HttpGet]
        public async  Task<IActionResult> DownloadExcel(int sortNumber, int sortType, string text)
        {

            if (text == null)
                text = "";

            var rawModel = await _broadcastFilter.GetModelAsync(text);

            var viewModel = _sortStrategyContext.Sort(rawModel, sortNumber, sortType);


            return File(await _excelSheetCreator.CreateExcelSheetByteArrayAsync(viewModel),
                StaticDetails.EXCEL_SHEET_CONTENT_TYPE, StaticDetails.EXCEL_SHEET_NAME);
        }

    }
}
