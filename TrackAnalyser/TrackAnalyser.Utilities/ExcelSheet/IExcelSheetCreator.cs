using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet
{
    public interface IExcelSheetCreator<TModel> where TModel : class
    {
        public void CreateExcelSheet(IEnumerable<TModel> models, string path);
    }
}
