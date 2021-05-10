using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet
{
    public class ExcelSheetConverter : IExcelSheetConverter
    {
        public FileStream ConvertToFileStream(string path)
        {
            var file = new FileInfo(path);

            if (file.Exists)
                return new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
            else
                return null;
        }
    }
}
