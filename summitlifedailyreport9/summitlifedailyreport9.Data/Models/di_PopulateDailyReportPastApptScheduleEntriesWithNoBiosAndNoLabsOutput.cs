using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput
    {
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList =
                new List<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumns>
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiosAndNoLabsOutputColumnsList
                { get; set; }
    }
}
