// -----------------------------------------------------------------------
// <copyright file="Set.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// Methods for setting values to attributes of <see cref="IWebElement"/>.
    /// </summary>
    public static class Set
    {
        /// <summary>
        /// Invokes <see cref="IWebElement.SendKeys(string)"/> method.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="clear"></param>
        public static void Text(IWebElement element, string value, bool clear = false)
        {
            if (clear) element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Invokes <see cref="IWebElement.SendKeys(string)"/> method on wrapped <see cref="IWebElement"/> of <see cref="IWrapsElement"/>.
        /// </summary>
        /// <param name="wrapsElement"></param>
        /// <param name="value"></param>
        /// <param name="clear"></param>
        public static void Text(IWrapsElement wrapsElement, string value, bool clear = false)
        {
            Text(wrapsElement.WrappedElement, value, clear);
        }
    }
}
