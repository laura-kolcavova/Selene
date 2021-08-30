// -----------------------------------------------------------------------
// <copyright file="WebElementExtensions.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// A set of extension methods for <see cref="IWebElement"/> interface.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Gets <see cref="IWebDriver"/> from the element.
        /// </summary>
        /// <param name="element">Context.</param>
        /// <returns><see cref="IWebDriver"/>.</returns>
        public static IWebDriver GetDriver(this IWebElement element)
        {
            var realElement = element.GetType() != typeof(RemoteWebElement)
                  ? element
                  : ((IWrapsElement)element).WrappedElement;

            return ((IWrapsDriver)realElement).WrappedDriver;
        }
    }
}
