using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportSsnsNotListedInAllEmployeesListOutputColumns : qy_GetDailyReportBaseOutputColumns
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Ssn { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string HeightInches { get; set; }
        public string Weight { get; set; }
        public string Bmi { get; set; }
        public string WristInches { get; set; }
        public string WaistInches { get; set; }
        public string HipsInches { get; set; }
        public string BloodPressure { get; set; }
        public string SystolicBloodPressure { get; set; }
        public string DiastolicBloodPressure { get; set; }
        public string RepeatBloodPressure { get; set; }
        public string RepeatSystolicBloodPressure { get; set; }
        public string RepeatDiastolicBloodPressure { get; set; }
        public string NameOfExaminer { get; set; }
        public string DateOfHealthScreen { get; set; }
        public string ParticipantInitials { get; set; }
        public string EmployeeId { get; set; }
        public string SubmissionDate { get; set; }
        public string IsPregnant { get; set; }
        public string EmailAddress { get; set; }
        public string DataGatheredOnTimestamp { get; set; }
    }
}
