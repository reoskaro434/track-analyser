using OfficeOpenXml;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackAnalyser.Models.ExcelSheetModel;
using TrackAnalyser.Models.ViewModels;
using TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator;

namespace TrackAnalyser.Utilities.ExcelSheetCreator
{
    public class ExcelSheetCreator : IExcelSheetCreator<BroadcastListViewModel, ExcelSheetModel>
    {
        private IEnumerable<ExcelSheetModel> CreateModel(BroadcastListViewModel broadcastListViewModel)
        {
            var trackEmissions = broadcastListViewModel.TrackEmissions;
            int counter = 1;

            List<ExcelSheetModel> excelSheetList = new List<ExcelSheetModel>();

            foreach (var emission in trackEmissions)
            {
                excelSheetList.Add(new ExcelSheetModel()
                {
                    CanalName = emission.CanalName,
                    EmissionDate = emission.EmissionDate,
                    EmissionDuration = emission.EmissionTime,
                    TrackArtist = emission.ArtistName,
                    TrackName = emission.TrackName,
                    Number = counter
                });
                counter++;
            }

            return excelSheetList;
        }
        public async Task<byte[]> CreateExcelSheetByteArrayAsync(BroadcastListViewModel model)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var package = new ExcelPackage();

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var excelSheetList = CreateModel(model);
            var range = ws.Cells["A1"].LoadFromCollection(excelSheetList, true);

            range.AutoFitColumns();

            return await package.GetAsByteArrayAsync();
        }
    }
}
