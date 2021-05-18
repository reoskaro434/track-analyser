using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet.ExcelSheetCreator
{
    public interface IExcelSheetCreator<TModel,TExcelSheetModel> where TModel : class
    {
        /// <summary>
        /// Creates excel sheet using models.
        /// </summary>
        /// <param name="models">Models whose create sheet.</param>
        public Task<byte[]> CreateExcelSheetByteArrayAsync(TModel models);
    }
}
