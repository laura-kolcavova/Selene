// -----------------------------------------------------------------------
// <copyright file="SeleneOptions.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    /// <summary>
    /// Represents a settings options used internaly by <see cref="Selene"/> library.
    /// </summary>
    public class SeleneOptions
    {
        /// <summary>
        /// Gets or sets default wait seconds.
        /// </summary>
        public int WaitSeconds { get; set; }

        /// <summary>
        /// Gets or sets a base url.
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
