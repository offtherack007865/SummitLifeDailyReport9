using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput
    {
        public di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList =
                new List<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumns>
            di_PopulateDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList
            { get; set; }
    }
}
