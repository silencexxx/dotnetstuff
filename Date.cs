using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateStuff
{
    public class Date
    {
        /// <summary>
        /// US Eastern Standard Time
        /// Central European Standard Time
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime GetFirstOfMonthAsUTC(int year, int month)
        {
            var ret = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(new DateTime(year, month, 1),
                "Central European Standard Time", 
                "UTC");
            DateTime.SpecifyKind(ret, DateTimeKind.Utc);
            return ret;
        }
    }
}
