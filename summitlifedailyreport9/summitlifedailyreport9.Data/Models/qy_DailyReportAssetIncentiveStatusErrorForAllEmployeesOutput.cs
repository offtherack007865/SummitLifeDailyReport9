using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput
    {
        public qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList =
                new List<qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns>
            qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumnsList
            { get; set; }
    }
}
