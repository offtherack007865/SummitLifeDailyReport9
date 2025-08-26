using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportDupEmpNbrSsnCombosOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string EmployeeNumber { get; set; }
        public string Ssn { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
