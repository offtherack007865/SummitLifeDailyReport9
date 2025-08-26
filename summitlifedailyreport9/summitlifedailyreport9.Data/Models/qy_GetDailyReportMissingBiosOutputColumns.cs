using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportMissingBiosOutputColumns : qy_GetDailyReportBaseOutputColumns
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
        public string Status { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
