// -----------------------------------------------------------------------
// <copyright file="UIElement.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// Defines a custom <see cref="IWrapsElement"/> object which encapsulates specified <see cref="IWrapsElement"/> instance.
    /// </summary>
    public abstract class UIElement : IWrapsElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UIElement"/> class.
        /// </summary>
        /// <param name="driver">A WebDriver instance.</param>
        /// <param name="wrappedElement">An <see cref="IWebElement"/> instance used to be wrapped by this <see cref="UIElement"/>.</param>
        protected UIElement(IWebDriver driver, IWebElement wrappedElement)
        {
            this.Driver = driver;
            this.WrappedElement = wrappedElement;
        }

        /// <summary>
        /// Gets <see cref="IWebElement"/> instance which is wrapped by this <see cref="UIElement"/>.
        /// </summary>
        public IWebElement WrappedElement { get; }

        /// <summary>
        /// Gets WebDriver instance.
        /// </summary>
        protected IWebDriver Driver { get; }

        //protected UIElement(IWebElement wrappedElement)
        //{
        //    this.driver = wrappedElement.GetDriver();
        //    WrappedElement = wrappedElement;
        //}
    }
}
