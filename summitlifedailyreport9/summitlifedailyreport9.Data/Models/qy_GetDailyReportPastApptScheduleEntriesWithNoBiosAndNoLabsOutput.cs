using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
    {
        public qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput()
        { 
            IsOk = true;    
            ErrorMessage = string.Empty;
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList =
                new List<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>
            qy_GetDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList
            { get; set; }
    }
}
