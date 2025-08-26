using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportMissingLabsOutput
    {
        public di_PopulateDailyReportMissingLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportMissingLabsOutputColumnsList =
                new List<di_PopulateDailyReportMissingLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportMissingLabsOutputColumns>
            di_PopulateDailyReportMissingLabsOutputColumnsList
                {  get; set; }  
    }
}
