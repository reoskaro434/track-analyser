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
        /// Creates excel sheet using models and 
        /// puts it in location given by user.
        /// </summary>
        /// <param name="models">Models whose create sheet.</param>
        /// <param name="path">Location where sheet will be saved.</param>
        public void CreateExcelSheetAsync(TModel models, string path);
    }
}
