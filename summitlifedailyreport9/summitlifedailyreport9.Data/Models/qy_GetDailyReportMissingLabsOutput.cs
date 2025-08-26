using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportMissingLabsOutput
    {
        public qy_GetDailyReportMissingLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportMissingLabsOutputColumnsList =
                new List<qy_GetDailyReportMissingLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }

        public List<qy_GetDailyReportMissingLabsOutputColumns>
            qy_GetDailyReportMissingLabsOutputColumnsList
            { get; set; }
    }
}
