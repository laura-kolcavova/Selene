// -----------------------------------------------------------------------
// <copyright file="UIComponent.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using OpenQA.Selenium;

    /// <summary>
    /// Definec custom UI component object.
    /// </summary>
    public abstract class UIComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIComponent"/> class.
        /// </summary>
        /// <param name="driver">A WebDriver instance.</param>
        protected UIComponent(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets WebDriver instance.
        /// </summary>
        protected IWebDriver Driver { get; }
    }
}
