using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.Data.Models
{
    public class qy_GetDailyReportConfigOutputColumns
    {
        public string WriteDirectory { get; set; }
        public string ArchiveDirectory { get; set; }
        public string ExcelTemplateFullFilename { get; set; }
        public string DailyReportsBaseWebApiUrl { get; set; }
        public string EmailBaseWebApiUrl { get; set; }
        public string EmailSubject { get; set; }
        public string EmailFromAddress { get; set; }
        public string Emailees { get; set; }

    }
}
