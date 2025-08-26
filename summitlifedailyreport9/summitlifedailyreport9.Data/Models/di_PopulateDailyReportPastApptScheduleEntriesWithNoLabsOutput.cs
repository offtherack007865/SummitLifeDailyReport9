using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput
    {
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList =
                new List<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns>
            di_PopulateDailyReportPastApptScheduleEntriesWithNoLabsOutputColumnsList
            { get; set; }
    }
}
