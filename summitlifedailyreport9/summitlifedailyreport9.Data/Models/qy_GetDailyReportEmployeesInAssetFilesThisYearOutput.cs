using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportEmployeesInAssetFilesThisYearOutput
    {
        public qy_GetDailyReportEmployeesInAssetFilesThisYearOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList =
                new List<qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns>
            qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumnsList
            { get; set; }
    }
}
