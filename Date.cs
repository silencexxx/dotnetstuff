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
        ///
        /// note: CEST does not work using .net code on mac(!)
        ///
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime GetFirstOfMonthAsUTC(int year, int month)
        {
            var ret = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(new DateTime(year, month, 1),
                //"Central European Standard Time", 
                "Europe/Stockholm",
                "UTC");
            DateTime.SpecifyKind(ret, DateTimeKind.Utc);
            return ret;
        }

        public static IEnumerable<string> GetAllTimeZones()
        {
             var tss =  TimeZoneInfo.GetSystemTimeZones();
            
            var q = from x in tss 
                orderby x.Id
                select x.Id;

            return q;
        }

        /* from date in string format to utc (datetime) */
        public static DateTime ConvertTimeToUTC(string sDate)
        {
            var dDate = DateTime.Parse(sDate); /* dDate gets unspecified kind - as it should be */

            var ts = TimeZoneInfo.FindSystemTimeZoneById("Europe/Stockholm");
            
            var r = TimeZoneInfo.ConvertTimeToUtc(dDate, ts);

            return r;
        }
    }
}
