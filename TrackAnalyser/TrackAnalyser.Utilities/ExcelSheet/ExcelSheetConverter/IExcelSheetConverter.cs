using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet.ExcelSheetConverter
{
    public interface IExcelSheetConverter
    {
        /// <summary>
        /// Converts excel sheet to byte array.
        /// </summary>
        /// <param name="path">Location of excel sheet.</param>
        /// <returns></returns>
        public byte[] ConvertToByteArray(string path);
    }
}
