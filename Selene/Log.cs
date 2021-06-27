//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using System;
    using System.Collections.Generic;

    public static class Log
    {
        private static readonly List<string> _log = new List<string>();

        public static void Entry(string message)
        {
            _log.Add(message);
        }

        public static void Pass(string message)
        {
            Entry($"OK - {message}");
        }  

        public static void Fail(string message)
        {
            Entry($"FAIL - {message}");
        }

        public static void Entry(Record record)
        {
            Entry(record.ToString());
        }

        public static void Pass(Record record)
        {
            Pass(record.ToString());
        }

        public static void Fail(Record record)
        {
            Fail(record.ToString());
        }

        public static IEnumerable<string> GetLog()
        {
            return _log;
        }
    }
}
