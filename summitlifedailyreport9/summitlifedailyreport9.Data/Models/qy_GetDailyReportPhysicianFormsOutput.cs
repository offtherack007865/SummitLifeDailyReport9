using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportPhysicianFormsOutput
    {
        public qy_GetDailyReportPhysicianFormsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportPhysicianFormsOutputColumnsList =
                new List<qy_GetDailyReportPhysicianFormsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }

        public List<qy_GetDailyReportPhysicianFormsOutputColumns>
            qy_GetDailyReportPhysicianFormsOutputColumnsList
            { get; set; }
    }
}
