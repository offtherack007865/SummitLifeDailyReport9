using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_DailyReportAssetIncentiveStatusErrorOutput
    {
        public di_DailyReportAssetIncentiveStatusErrorOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_DailyReportAssetIncentiveStatusErrorOutputColumnsList =
                new List<di_DailyReportAssetIncentiveStatusErrorOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_DailyReportAssetIncentiveStatusErrorOutputColumns>
            di_DailyReportAssetIncentiveStatusErrorOutputColumnsList
            { get; set; }
    }
}
