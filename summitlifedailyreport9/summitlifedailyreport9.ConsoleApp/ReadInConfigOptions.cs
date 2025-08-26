using Microsoft.Extensions.Configuration;
using summitlifedailyreport9.Data;
using summitlifedailyreport9.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summitlifedailyreport9.ConsoleApp
{
    public class ReadInConfigOptions
    {
        public ReadInConfigOptions(Microsoft.Extensions.Configuration.IConfiguration myConfig)
        {
            MyConfig = myConfig;
        }

        public Microsoft.Extensions.Configuration.IConfiguration MyConfig { get; set; }



        public summitlifedailyreport9.Data.Models.ConfigOptions ReadIn()
        {
            summitlifedailyreport9.Data.Models.ConfigOptions
                returnConfigOptions =
                new summitlifedailyreport9.Data.Models.ConfigOptions();

            returnConfigOptions.BaseWebUrl =
                MyConfig.GetValue<string>(summitlifedailyreport9.Data.MyConstants.BaseWebUrl);

            return returnConfigOptions;
        }
    }
}
