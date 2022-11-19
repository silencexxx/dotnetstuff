using System;

namespace dotnetstuff
{
    class Program
    {
        static void Main(string[] args)
        {
            /* test 1 */
            var d = DateStuff.Date.GetFirstOfMonthAsUTC(2019, 2);
            Console.WriteLine(d);

            /* test 2 */
            Console.WriteLine(string.Join("\n", DateStuff.Date.GetAllTimeZones()));

            /* test 3 */
            Console.WriteLine(string.Join("\n", DateStuff.Date.ConvertTimeToUTC("2019-02-04")));

        }
    }
}
