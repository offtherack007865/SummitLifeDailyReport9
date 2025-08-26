using System;
using System.Collections.Generic;

namespace summitlifedailyreport9.Data.Models;

public partial class DailyReportMissingBio
{
    public int DailyReportMissingBiosId { get; set; }

    public string LastHireDate { get; set; } = null!;

    public string Ssn { get; set; } = null!;

    public string EmployeeNumber { get; set; } = null!;

    public string EmployeeEmail { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string EmploymentStatus { get; set; } = null!;

    public string FullPartTime { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string WellnessEnrolled { get; set; } = null!;

    public string? PatientId { get; set; }

    public string LabDate { get; set; } = null!;

    public string Chol { get; set; } = null!;

    public string Hdl { get; set; } = null!;

    public string TcoverHdl { get; set; } = null!;

    public string Ldl { get; set; } = null!;

    public string LdlcholesterolCorD { get; set; } = null!;

    public string Triglycerides { get; set; } = null!;

    public string FastingBloodGlucoseMgoverDl { get; set; } = null!;

    public string GgtiuoverL { get; set; } = null!;

    public string HemoglobinA1c { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime DataGatheredOnTimestamp { get; set; }
}
