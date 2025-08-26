using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput
    {
        public di_PopulateDailyReportEmployeesInAssetFilesThisYearOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumnsList =
                new List<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumns>
            di_PopulateDailyReportEmployeesInAssetFilesThisYearOutputColumnsList
            { get; set; }
    }
}
