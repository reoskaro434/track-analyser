using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Utilities.ExcelSheet
{
    public class ExcelSheetCreator : IExcelSheetCreator<BroadcastListViewModel>
    {
        public async void CreateExcelSheetAsync(BroadcastListViewModel model, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);
            var emissionList = model.TrackEmissions;

            if (file.Exists)
                file.Delete();

            var package = new ExcelPackage(file);

            var ws = package.Workbook.Worksheets.Add("Emissions");

            var range = ws.Cells["A1"].LoadFromCollection(emissionList.Select(p => p.ArtistName), true);
            ws.Cells["B1"].LoadFromCollection(emissionList.Select(p => p.CanalName), true);
            ws.Cells["C1"].LoadFromCollection(emissionList.Select(p => p.EmissionDate), true);
            ws.Cells["D1"].LoadFromCollection(emissionList.Select(p => p.EmissionTime), true);
            ws.Cells["E1"].LoadFromCollection(emissionList.Select(p => p.TrackName), true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }
    }
}
