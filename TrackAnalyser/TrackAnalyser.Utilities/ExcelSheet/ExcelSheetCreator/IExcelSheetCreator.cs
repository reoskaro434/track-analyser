using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator
{
    public interface IExcelSheetCreator<TModel,TExcelSheetModel> where TModel : class
    {
        public void CreateExcelSheetAsync(TModel models, string path);
    }
}
