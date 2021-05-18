using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.ExcelSheetModel;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator
{
    public class ExcelSheetCreator : IExcelSheetCreator<BroadcastListViewModel,ExcelSheetModel>
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
