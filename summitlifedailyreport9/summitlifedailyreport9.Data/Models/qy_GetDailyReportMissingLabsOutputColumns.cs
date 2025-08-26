using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportMissingLabsOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string LastHireDate { get; set; }
        public string SSN { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string EmploymentStatus { get; set; }
        public string FullPartTime { get; set; }
        public string Location { get; set; }
        public string WellnessEnrolled { get; set; }
        public string PatientID { get; set; }
        public string SystolicBP { get; set; }
        public string DiastolicBP { get; set; }
        public string HeightInches { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string WaistInches { get; set; }
        public string AroundWrist { get; set; }
        public string HipsInches { get; set; }
        public string BiometricScreenDate { get; set; }
        public string Status { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
