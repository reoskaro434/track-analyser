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
        public FileStream ConvertToFileStream(string path);
    }
}
