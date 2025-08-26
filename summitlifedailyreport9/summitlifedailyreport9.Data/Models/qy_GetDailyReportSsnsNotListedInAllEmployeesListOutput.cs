using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput
    {
        public qy_GetDailyReportSsnsNotListedInAllEmployeesListOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList =
                new List<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns>
            qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumnsList
            { get; set; }
    }
}
