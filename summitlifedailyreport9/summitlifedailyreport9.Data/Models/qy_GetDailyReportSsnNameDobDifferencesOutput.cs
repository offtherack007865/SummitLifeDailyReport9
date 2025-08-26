using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportSsnNameDobDifferencesOutput
    {
        public qy_GetDailyReportSsnNameDobDifferencesOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList =
                new List<qy_GetDailyReportSsnNameDobDifferencesOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportSsnNameDobDifferencesOutputColumns>
            qy_GetDailyReportSsnNameDobDifferencesOutputColumnsList
            { get; set; }
    }
}
