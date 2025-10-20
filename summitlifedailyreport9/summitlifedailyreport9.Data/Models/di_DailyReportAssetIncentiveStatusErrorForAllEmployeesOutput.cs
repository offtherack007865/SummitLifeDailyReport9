using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
    {
        public di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList =
                new List<di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>
            di_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList
            { get; set; }
    }
}
