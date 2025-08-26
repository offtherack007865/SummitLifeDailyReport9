using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportSsnNameDobDifferencesOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string FormLastName { get; set; }
        public string FormFirstName { get; set; }
        public string FormSSN { get; set; }
        public string FormBirthDate { get; set; }
        public string FormEmployeeId { get; set; }
        public string AllEmployeesLastName { get; set; }
        public string AllEmployeesFirstName { get; set; }
        public string AllEmployeesSSN { get; set; }
        public string AllEmployeesBirthDate { get; set; }
        public string AllEmployeesEmployeeId { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
