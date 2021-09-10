// -----------------------------------------------------------------------
// <copyright file="Get.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// A set of helper methods used for getting values from attributes of <see cref="IWebElement"/>and <see cref="IWrapsElement"/> instances.
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Gets an attribute value from element by given attribute name.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="attr">The attribute name.</param>
        /// <returns>The attribute value as <see cref="string"/>.</returns>
        public static string Attr(IWebElement element, string attr)
        {
            return element.GetAttribute(attr);
        }

        /// <summary>
        /// Gets a wrapped element and then gets an attribute value from the wrapped element by given attribute name.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The attribute value as <see cref="string"/>.</returns>
        public static string Attr(IWrapsElement wrapsElement, string attributeName)
        {
            return wrapsElement.WrappedElement.GetAttribute(attributeName);
        }

        /// <summary>
        /// Gets a css value from the element by given css property name.
        /// </summary>
        /// <param name="element">The wrapping element.</param>
        /// <param name="propertyName">The css property name.</param>
        /// <returns>The css attribute value as <see cref="string"/>.</returns>
        public static string Css(IWebElement element, string propertyName)
        {
            return element.GetCssValue(propertyName);
        }

        /// <summary>
        /// Gets a wrapped element and then gets a css value from the wrapped element by given css property name.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <param name="propertyName">The css property name.</param>
        /// <returns>The css attribute value as <see cref="string"/>.</returns>
        public static string Css(IWrapsElement wrapsElement, string propertyName)
        {
            return wrapsElement.WrappedElement.GetCssValue(propertyName);
        }

        /// <summary>
        /// Gets an id value from the element.
        /// </summary>
        /// <param name="element">The wrapping element.</param>
        /// <returns>The id value as <see cref="string"/>.</returns>
        public static string Id(IWebElement element)
        {
            return element.GetAttribute("id");
        }

        /// <summary>
        /// Gets a wrapped element and then gets an id value from the wrapped element.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <returns>The id value as <see cref="string"/>.</returns>
        public static string Id(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("id");
        }

        /// <summary>
        /// Gets a name value from the element.
        /// </summary>
        /// <param name="element">The wrapping element.</param>
        /// <returns>The name value as <see cref="string"/>.</returns>
        public static string Name(IWebElement element)
        {
            return element.GetAttribute("name");
        }

        /// <summary>
        /// Gets a wrapped element and then gets a name value from the wrapped element.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <returns>The name value as <see cref="string"/>.</returns>
        public static string Name(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("name");
        }

        /// <summary>
        /// Gets an inner text from the element.
        /// </summary>
        /// <param name="element">The wrapping element.</param>
        /// <returns>The inner text as <see cref="string"/>.</returns>
        public static string Text(IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Gets a wrapped element and then gets an inner text from the wrapped element.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <returns>The inner text as <see cref="string"/>.</returns>
        public static string Text(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.Text;
        }

        /// <summary>
        /// Gets an input value from the element.
        /// </summary>
        /// <param name="element">The wrapping element.</param>
        /// <returns>The input value as <see cref="string"/>.</returns>
        public static string Val(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Gets a wrapped element and then gets an inner text from the wrapped element.
        /// </summary>
        /// <param name="wrapsElement">The wrapping element.</param>
        /// <returns>The input value as <see cref="string"/>.</returns>
        public static string Val(IWrapsElement wrapsElement)
        {
            return wrapsElement.WrappedElement.GetAttribute("value");
        }
    }
}
