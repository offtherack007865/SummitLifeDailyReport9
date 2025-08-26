using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput
    {
        public di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList =
                new List<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>(); 
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumns>
            di_PopulateDailyReportEmployeesInAssetFileThisWeekSoFarOutputColumnsList
            { get; set; }
    }
}
