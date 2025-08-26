using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportConfigOutput
    {
        public qy_GetDailyReportConfigOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportConfigOutputColumnsList =
                new List<qy_GetDailyReportConfigOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportConfigOutputColumns>
            qy_GetDailyReportConfigOutputColumnsList 
            { get; set; }
    }
}
