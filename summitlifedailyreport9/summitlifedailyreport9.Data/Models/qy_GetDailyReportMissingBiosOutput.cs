using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportMissingBiosOutput
    {
        public qy_GetDailyReportMissingBiosOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportMissingBiosOutputColumnsList =
                new List<qy_GetDailyReportMissingBiosOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportMissingBiosOutputColumns>
            qy_GetDailyReportMissingBiosOutputColumnsList
            { get; set; }
    }
}
