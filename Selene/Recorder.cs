//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using System;
    using System.Collections.Generic;

    public static class Recorder
    {
        private static List<string> _log = new List<string>();

        public static void Entry(string message)
        {
            _log.Add(message);
        }

        public static void PassRecord(Record record)
        {
            Entry($"PASS - {record}");
        }

        public static void FailRecord(Record record)
        {
            Entry($"FAIL - {record}");
        }

        public static IEnumerable<string> GetLog()
        {
            return _log;
        }
    }
}
