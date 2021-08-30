// -----------------------------------------------------------------------
// <copyright file="FormatHelper.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Helpers
{
    using System;

    /// <summary>
    /// A set of convert methods using common formatting conventions.
    /// </summary>
    public static class FormatHelper
    {
        /// <summary>
        /// Converts <see cref="DateTime"/> value to <see cref="string"/> using given format convention.
        /// </summary>
        /// <param name="date">Source value.</param>
        /// <param name="format">Format convention.</param>
        /// <returns>Converted value as <see cref="string"/>.</returns>
        public static string DateToString(DateTime date, string format = "dd.MM.yyyy")
        {
            return date.ToString(format);
        }

        /// <summary>
        /// Converts <see cref="string"/> value to <see cref="DateTime"/> using given format convention.
        /// </summary>
        /// <param name="date">Source value.</param>
        /// <param name="format">Format convention.</param>
        /// <returns>Converted value as <see cref="DateTime"/>.</returns>
        public static DateTime StringToDate(string date, string format = "dd.MM.yyyy")
        {
            return DateTime.ParseExact(date, format, null);
        }

        /// <summary>
        /// Converts <see cref="string"/> value to <see cref="TimeSpan"/> using given format convention.
        /// </summary>
        /// <param name="date">Source value.</param>
        /// <param name="format">Format convention.</param>
        /// <returns>Converted value as <see cref="TimeSpan"/>.</returns>
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
