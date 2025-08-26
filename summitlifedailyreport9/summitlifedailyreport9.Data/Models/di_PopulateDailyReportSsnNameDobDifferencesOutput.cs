using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportSsnNameDobDifferencesOutput
    {
        public di_PopulateDailyReportSsnNameDobDifferencesOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportSsnNameDobDifferencesOutputColumnsList =
                new List<di_PopulateDailyReportSsnNameDobDifferencesOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportSsnNameDobDifferencesOutputColumns>
            di_PopulateDailyReportSsnNameDobDifferencesOutputColumnsList
            { get; set; }
    }
}
