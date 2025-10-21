using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_DailyReportAssetIncentiveStatusErrorForAllEmployeesOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string EmployeeNumber {  get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeDob { get; set; }
        public string ErrorMessage { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
