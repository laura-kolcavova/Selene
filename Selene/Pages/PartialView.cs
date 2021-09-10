// -----------------------------------------------------------------------
// <copyright file="PartialView.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Pages
{
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a partial view of <see cref="Page"/> instance.
    /// </summary>
    public abstract class PartialView : IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialView"/> class.
        /// </summary>
        /// <param name="driver">A WebDriver instance.</param>
        /// <param name="parent">A <see cref="Page"/> instance in which is this partial view stored. Used as reference.</param>
        protected PartialView(IWebDriver driver, Page parent)
        {
            this.Driver = driver;
            this.Parent = parent;
        }

        /// <summary>
        /// Gets a <see cref="Page"/> instance in which is this partial view stored.
        /// </summary>
        public Page Parent { get; }

        /// <summary>
        /// Gets a WebDriver instance.
        /// </summary>
        protected IWebDriver Driver { get; }

        /// <inheritdoc/>
        public abstract void Load();
    }
}
