using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models.ExcelSheet;

namespace TrackAnalyser.Utilities.ExcelSheet
{
    public class ExcelSheetCreator : IExcelSheetCreator<ExcelSheetModel>
    {
        public void CreateExcelSheet(IEnumerable<ExcelSheetModel> models, string path)
        {
            throw new NotImplementedException();
        }
    }
}
