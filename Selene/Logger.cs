// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines an object used for logging.
    /// </summary>
    public class Logger
    {
        private readonly List<string> entries;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.entries = new List<string>();
        }

        /// <summary>
        /// Stores the specified text value to the end of entries list.
        /// </summary>
        /// <param name="text">The text value to store.</param>
        public void Write(string text)
        {
            this.entries.Add(text);
        }

        /// <summary>
        /// Stores a string representation of <see cref="LogEntry"/> instance to the end of entries list.
        /// </summary>
        /// <param name="logEntry">The <see cref="LogEntry"/> instance to store.</param>
        public void Write(LogEntry logEntry)
        {
            this.Write(logEntry.ToString());
        }

        /// <summary>
        /// Stores the spcecified text value in format specified as pass level to the end of entries list.
        /// </summary>
        /// <param name="text">The text value to store.</param>
        public void Pass(string text)
        {
            this.Write($"OK - {text}");
        }

        /// <summary>
        /// Stores a string representation of <see cref="LogEntry"/> instance in format specified as pass level to the end of entries list.
        /// </summary>
        /// <param name="logEntry">The <see cref="LogEntry"/> instance to store.</param>
        public void Pass(LogEntry logEntry)
        {
            this.Pass(logEntry.ToString());
        }

        /// <summary>
        /// Stores the spcecified text value in format specified as fail level to the end of entries list.
        /// </summary>
        /// <param name="text">The text value to store.</param>
        /// <param name="failMessage">A fail message.</param>
        public void Fail(string text, string failMessage = null)
        {
            var output = $"FAIL - {text}";

            if (!string.IsNullOrEmpty(failMessage))
            {
                output += $" ({failMessage})";
            }

            this.Write(output);
        }

        /// <summary>
        /// Stores a string representation of <see cref="LogEntry"/> instance in format specified as fail level to the end of entries list.
        /// </summary>
        /// <param name="logEntry">The <see cref="LogEntry"/> instance to store.</param>
        /// <param name="failMessage">A fail message.</param>
        public void Fail(LogEntry logEntry, string failMessage = null)
        {
            this.Fail(logEntry.ToString(), failMessage);
        }

        /// <summary>
        /// Gets a entries list as <see cref="IEnumerable{T}"/> interface.
        /// </summary>
        /// <returns>The entries list as <see cref="IEnumerable{T}"/> interface.</returns>
        public IEnumerable<string> GetEntries()
        {
            return this.entries;
        }
    }
}
