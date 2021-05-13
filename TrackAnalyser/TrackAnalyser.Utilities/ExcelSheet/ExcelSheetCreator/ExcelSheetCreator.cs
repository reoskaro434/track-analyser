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
                });
            }

            return excelSheetList;
        }
        public async void CreateExcelSheetAsync(BroadcastListViewModel model, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);
            var emissionList = model.TrackEmissions;

            if (file.Exists)
                file.Delete();

            var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var excelSheetList = CreateModel(model);
            var range = ws.Cells["A1"].LoadFromCollection(excelSheetList, true);
            /*
                        var range = ws.Cells["A1"].LoadFromCollection(emissionList.Select(p => p.ArtistName), true);
                        ws.Cells["B1"].LoadFromCollection(emissionList.Select(p => p.CanalName), true);
                        ws.Cells["C1"].LoadFromCollection(emissionList.Select(p => p.EmissionDate), true);
                        ws.Cells["D1"].LoadFromCollection(emissionList.Select(p => p.EmissionTime), true);
                        ws.Cells["E1"].LoadFromCollection(emissionList.Select(p => p.TrackName), true);
            */         //   
            range.AutoFitColumns();
            await package.SaveAsync();
        }
    }
}
