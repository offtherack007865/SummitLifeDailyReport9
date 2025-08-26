using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
 {
    public class qy_GetDailyReportPastApptScheduleEntriesWithNoLabsOutputColumns : qy_GetDailyReportBaseOutputColumns
     {
      public string EventLocation { get; set; }
      public DateTime EventTimestamp { get; set; }
      public DateTime AppointmentStartTimestamp { get; set; }
      public DateTime AppointmentEndTimestamp { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public string EmployeeID { get; set; }
      public string SSN { get; set; }
      public DateTime DOB { get; set; }
      public string Location { get; set; }
      public string Department { get; set; }
	  public string PatientID { get; set; }
      public string SystolicBP { get; set; }
      public string DiastolicBP { get; set; }
      public string HeightInches { get; set; }
      public string Weight { get; set; }
      public string BMI { get; set; }
      public string WaistInches { get; set; }
      public string AroundWrist { get; set; }
      public string HipsInches { get; set; }
      public string IsPregnant { get; set; }
      public string BiometricScreenDate { get; set; }
      public string Status { get; set; }
      public string DataGatheredOnTimestamp { get; set; }
    }
}
