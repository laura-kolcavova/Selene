//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.Helpers
{
    using System;

    public static class FormatHelper
    {
        public static string DateToString(DateTime date, string format = "dd.MM.yyyy")
        {
            return date.ToString(format);
        }

        public static DateTime StringToDate(string date, string format = "dd.MM.yyyy")
        {
            return DateTime.ParseExact(date, format, null);
        }

        public static TimeSpan StringToTime(string time, string format = @"hh\:mm")
        {
            return TimeSpan.ParseExact(time, format, null);
        }

        public static string TimeToString(TimeSpan time, string format = @"hh\:mm")
        {
            return time.ToString(format);
        }
    }
}
