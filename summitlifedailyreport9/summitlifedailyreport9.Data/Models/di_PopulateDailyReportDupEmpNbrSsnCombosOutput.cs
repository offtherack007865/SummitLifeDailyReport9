using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportDupEmpNbrSsnCombosOutput
    {
        public di_PopulateDailyReportDupEmpNbrSsnCombosOutput() 
        { 
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumnsList =
                new List<di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumns>
            di_PopulateDailyReportDupEmpNbrSsnCombosOutputColumnsList
            { get; set; }
    }
}
