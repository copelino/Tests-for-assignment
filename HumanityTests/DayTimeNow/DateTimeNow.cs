using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanityTests
{
    public static class DateTimeNow
    {
        public static string GetFormatedDateNow(string testName)
        {
            DateTime date = DateTime.Now;

            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();
            string second = date.Second.ToString();

            string dateFormat = testName + "-" + day + "-" + month + "-" + year + "-" + hour + "_" + minute + "_" + second;

            return dateFormat;
        }

        internal static string GetFormatedDateNow(object testName)
        {
            throw new NotImplementedException();
        }

    }
}
