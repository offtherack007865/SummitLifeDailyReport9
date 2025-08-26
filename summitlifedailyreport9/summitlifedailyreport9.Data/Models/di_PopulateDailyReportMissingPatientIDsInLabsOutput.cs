using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportMissingPatientIDsInLabsOutput
    {
        public di_PopulateDailyReportMissingPatientIDsInLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportMissingPatientIDsInLabsOutputColumnsList =
                new List<di_PopulateDailyReportMissingPatientIDsInLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportMissingPatientIDsInLabsOutputColumns>
            di_PopulateDailyReportMissingPatientIDsInLabsOutputColumnsList
            { get; set; }
    }
}
