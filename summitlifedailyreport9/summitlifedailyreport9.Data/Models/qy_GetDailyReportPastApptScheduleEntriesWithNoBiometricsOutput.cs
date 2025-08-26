using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
    {
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList =
                new List<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList
            { get; set; }
    }
}
