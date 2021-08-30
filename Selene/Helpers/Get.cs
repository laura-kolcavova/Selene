﻿// -----------------------------------------------------------------------
// <copyright file="Get.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// Methods for getting values from attributes of <see cref="IWebElement"/>.
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Gets an attribute value.
        /// </summary>
        /// <param name="element">Target element.</param>
        /// <param name="attr">Attribute name.</param>
        /// <returns>attribute value as <see cref="string"/>.</returns>
        public static string Attr(IWebElement element, string attr)
        {
            return element.GetAttribute(attr);
        }

        public static string Attr(IWrapsElement wrapsElement, string attr)
        {
            return wrapsElement.WrappedElement.GetAttribute(attr);
        }

        public static string Css(IWebElement element, string name)
        {
            return element.GetCssValue(name);
        }

        public static string Css(IWrapsElement wrapsElement, string name)
        {
            return wrapsElement.WrappedElement.GetCssValue(name);
        }

        public static string Id(IWebElement element)
        {
            return element.GetAttribute("id");
        }

        public static string Id(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("id");
        }

        public static string Name(IWebElement element)
        {
            return element.GetAttribute("name");
        }

        public static string Name(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("name");
        }

        public static string Text(IWebElement element)
        {
            return element.Text;
        }

        public static string Text(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.Text;
        }

        public static string Val(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string Val(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("value");
        }
    }
}
