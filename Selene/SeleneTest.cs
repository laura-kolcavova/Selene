// -----------------------------------------------------------------------
// <copyright file="SeleneTest.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using System;

    /// <summary>
    /// Defines an abstract base test.
    /// </summary>
    public abstract class SeleneTest
    {
        private static SeleneOptions configuredOptionsInstance;

        /// <summary>
        /// Gets the <see cref="SeleneOptions"/> instance.
        /// </summary>
        internal static SeleneOptions Options => configuredOptionsInstance;

        /// <summary>
        /// Add the <see cref="SeleneOptions"/> to the <see cref="Selene"/> library.
        /// </summary>
        /// <param name="configureOptions">The setup action used to configure the settings options.</param>
        /// <returns>The <see cref="ISeleneBuilder"/>.</returns>
        public ISeleneBuilder AddSelene(Action<SeleneOptions> configureOptions)
        {
            var seleneBuilder = new SeleneBuilder();
            var optionsProvider = new SeleneOptions();

            configureOptions.Invoke(optionsProvider);
            configuredOptionsInstance = optionsProvider;

            return seleneBuilder;
        }
    }
}
