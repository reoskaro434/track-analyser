using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities.ExcelSheet.ExcelSheetConverter
{
    public class ExcelSheetConverter : IExcelSheetConverter
    {
        public byte[] ConvertToByteArray(string path)
        {
            var file = new FileInfo(path);

            if (file.Exists)
                return File.ReadAllBytes(path);
            else
                return null;
        }
    }
}
