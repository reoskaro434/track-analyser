using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.Utilities
{
    public class StaticDetails
    {
        public const int SORT_BY_CANAL = 1;
        public const int SORT_BY_DURATION = 2;
        public const int SORT_BY_EMISSION_DATE = 3;
        public const int SORT_BY_DESCRIPTION = 4;
        
        public const int SORT_ASCENDING = 0;
        public const int SORT_DESCENDING = 1;

        public const int RANK_MAX_TRACKS_AMOUNT = 100;

        public const string DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        public const string TIME_FORMAT = "mm:ss";
        public const string DATE_FORMAT = "dd/MM/yyyy";

        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";

        public const string EXCEL_SHEET_CONTENT_TYPE = "application/vnd.ms-excel";
        public const string EXCEL_SHEET_NAME = "TrackAnalyserEmission.xlsx";
    
    }
}
