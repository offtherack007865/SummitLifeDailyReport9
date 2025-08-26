using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportMissingPatientIDsInLabsOutput
    {
        public qy_GetDailyReportMissingPatientIDsInLabsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportMissingPatientIDsInLabsOutputColumnsList =
                new List<qy_GetDailyReportMissingPatientIDsInLabsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }    
        public List<qy_GetDailyReportMissingPatientIDsInLabsOutputColumns>
            qy_GetDailyReportMissingPatientIDsInLabsOutputColumnsList
            { get; set; }
    }
}
