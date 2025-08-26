using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportEmployeesInAssetFilesThisYearOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string SystolicBP { get; set; }
        public string DiastolicBP { get; set; }
        public string HeightInches { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string WaistInches { get; set; }
        public string AroundWrist { get; set; }
        public string HipsInches { get; set; }
        public string BiometricScreenDate { get; set; }
        public string LabDate { get; set; }
        public string Chol { get; set; }
        public string HDL { get; set; }
        public string TCOverHDL { get; set; }
        public string LDL { get; set; }
        public string LDLCholesterolCOrD { get; set; }
        public string Triglycerides { get; set; }
        public string FastingBloodGlucoseMGOverDL { get; set; }
        public string GGTIUOverL { get; set; }
        public string HemoglobinA1C { get; set; }
        public string CreatedDate { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
