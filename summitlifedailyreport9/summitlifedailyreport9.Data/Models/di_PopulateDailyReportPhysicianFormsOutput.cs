using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class di_PopulateDailyReportPhysicianFormsOutput
    {
        public di_PopulateDailyReportPhysicianFormsOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            di_PopulateDailyReportPhysicianFormsOutputColumnsList =
                new List<di_PopulateDailyReportPhysicianFormsOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<di_PopulateDailyReportPhysicianFormsOutputColumns>
            di_PopulateDailyReportPhysicianFormsOutputColumnsList
            { get; set; }
    }
}
