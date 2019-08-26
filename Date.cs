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
        /// note: CEST does not work using .net core on mac(!)
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

        static TimeZoneInfo ret = null;
        public static TimeZoneInfo GetSthlmTimeZone()
        {
            if (ret != null)
            {
                return ret;
            }

            /* eur/sthlm first 
            then cest
             */
            var possibleTZs = new[]{
                "Europe/Stockholm", 
                "Central European Standard Time"
            };
            

            foreach (var tz in possibleTZs)
            {
                try
                {
                    ret = TimeZoneInfo.FindSystemTimeZoneById(tz);
                }
                catch (Exception e)
                {
                    /* well well */                    
                }
                if (ret != null)
                {
                    break;
                }
            }

            return ret;
        }
    }
}
