using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput
    {
        public di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList =
                new List<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumns>
            di_PopulateDailyReportPastApptScheduleEntriesWithNoBiometricsOutputColumnsList { get; set; }
    }
}
