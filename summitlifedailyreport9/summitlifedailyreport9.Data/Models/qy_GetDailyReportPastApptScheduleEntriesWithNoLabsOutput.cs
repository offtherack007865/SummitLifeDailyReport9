using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput
    {
        public qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList = 
               new List<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>
            qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList 
            { get; set; }
    }
}
