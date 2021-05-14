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
        public async void CreateExcelSheetAsync(BroadcastListViewModel model, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);

            if (file.Exists)
                file.Delete();

            var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var excelSheetList = CreateModel(model);
            var range = ws.Cells["A1"].LoadFromCollection(excelSheetList, true);
          
            range.AutoFitColumns();
            await package.SaveAsync();
        }
    }
}
