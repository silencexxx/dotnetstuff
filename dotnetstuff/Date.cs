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
        ///
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime GetFirstOfMonthAsUTC(int year, int month)
        {
            return ConvertTimeToUTC($"{year:D4}-{month:D2}-01");
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

            var ts = GetSthlmTimeZone();
            
            var r = TimeZoneInfo.ConvertTimeToUtc(dDate, ts);

            return r;
        }

        public static TimeZoneInfo GetSthlmTimeZone()
        {
            /* 
                eur/sthlm first 
                then cet
             */

            var possibleTZs = new[]{
                "Europe/Stockholm", /* this Id has DisplayName "W. Europe Standard Time" in .net6.0 */
                "W. Europe Standard Time", /* ... ok then try this */
                "Central European Standard Time",
                "Central Europe Standard Time"                
            };

            // Func<string, TimeZoneInfo> g = (tzname) => {
            //     try {
            //         return TimeZoneInfo.FindSystemTimeZoneById(tzname);
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e);
            //     }
            //     return null;
            // };

            // var tzs = from x in possibleTZs
            //     select g(x);
            
            foreach (var tz in possibleTZs)
            {
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(tz);                    
                }
                catch (Exception e)
                {
                    /* well well - try next then */                    
                }
            }

            return null;
        }
    }
}
