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
    /// A set of helper methods used for setting values to attributes of <see cref="IWebElement"/> and <see cref="IWrapsElement"/> instances.
    /// </summary>
    public static class Set
    {
        /// <summary>
        /// Simulates a typing text into the element. Clears the element input before typing if clear flag is set to true.
        /// </summary>
        /// <param name="element">The element used for simulating.</param>
        /// <param name="text">The text value used to typing into the element.</param>
        /// <param name="clear">The clear flag - clears the element input before typing if set to true, otherwise not.</param>
        public static void Text(IWebElement element, string text, bool clear = false)
        {
            if (clear)
            {
                element.Clear();
            }

            element.SendKeys(text);
        }

        /// <summary>
        /// Gets a wrapped element and simulates a typing text into the wrapped element. Clears the wrapped element input before typing if clear flag is set to true.
        /// </summary>
        /// <param name="wrapsElement">The wraping element used for get the wrapped elemnt and simulating.</param>
        /// <param name="text">The text value used to typing into the element.</param>
        /// <param name="clear">The clear flag - clears the wrapped element input before typing if set to true, otherwise not.</param>
        public static void Text(IWrapsElement wrapsElement, string text, bool clear = false)
        {
            Text(wrapsElement.WrappedElement, text, clear);
        }
    }
}
