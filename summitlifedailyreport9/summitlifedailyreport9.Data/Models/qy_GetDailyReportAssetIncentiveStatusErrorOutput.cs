using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportAssetIncentiveStatusErrorOutput
    {
        public qy_GetDailyReportAssetIncentiveStatusErrorOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetDailyReportAssetIncentiveStatusErrorOutputColumnsList =
                new List<qy_GetDailyReportAssetIncentiveStatusErrorOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetDailyReportAssetIncentiveStatusErrorOutputColumns>
                    qy_GetDailyReportAssetIncentiveStatusErrorOutputColumnsList
                    { get; set; }
    }
}
