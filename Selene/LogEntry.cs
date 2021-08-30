// -----------------------------------------------------------------------
// <copyright file="LogEntry.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    /// <summary>
    /// Defines a log entry object used by <see cref="Selene.Logger"/>.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Gets or sets an action name.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets a response text value.
        /// </summary>
        public string Response { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string output = this.Action;

            if (!string.IsNullOrEmpty(this.Response))
            {
                output += " - " + this.Response;
            }

            return output;
        }
    }
}
