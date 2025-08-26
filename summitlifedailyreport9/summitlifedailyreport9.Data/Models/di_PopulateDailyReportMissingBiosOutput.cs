using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportMissingBiosOutput
    {
        public di_PopulateDailyReportMissingBiosOutput()
        {
            IsOk = true;    
            ErrorMessage = string.Empty;
            di_PopulateDailyReportMissingBiosOutputColumnsList =
                new List<di_PopulateDailyReportMissingBiosOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportMissingBiosOutputColumns>
            di_PopulateDailyReportMissingBiosOutputColumnsList
            { get; set; }
    }
}
