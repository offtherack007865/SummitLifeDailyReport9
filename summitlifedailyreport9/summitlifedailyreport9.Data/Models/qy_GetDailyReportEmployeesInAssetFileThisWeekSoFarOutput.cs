using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput : qy_GetDailyReportBaseOutputColumns
    {
        public qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList =
                new List<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>
            qy_GetDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList
            { get; set; }
    }
}
