using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.ExcelTabs
{
    public static class ExcelTabsClass
    {
        public static List<string> ExcelTabNameList = new List<string>
        {
            "001_MissingBios"
            ,"002_MissingLabs"
            ,"003_MissingPatientIDsInLabs"
            ,"004_ScheduledWithNoBios"
            ,"005_ScheduledWithNoBiosNoLabs"
            ,"006_ScheduledWithNoLabs"
            ,"007_PhysicianForms"
        };
        public static bool TabNameInList(string inputTabName)
        {
            return ExcelTabNameList.Contains(inputTabName);
        }
    }

}
