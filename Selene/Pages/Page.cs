// -----------------------------------------------------------------------
// <copyright file="Page.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Pages
{
    using System.Collections.Generic;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a web page.
    /// </summary>
    public abstract class Page : IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="driver">A WebDriver instance.</param>
        protected Page(IWebDriver driver)
        {
            this.Driver = driver;
            this.PartialViews = new List<PartialView>();
        }

        /// <summary>
        /// Gets or sets a title of the page.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets a <see cref="PartialView"/> list.
        /// </summary>
        public List<PartialView> PartialViews { get; }

        /// <summary>
        /// Gets a WenDriver instance.
        /// </summary>
        protected IWebDriver Driver { get; }

        /// <summary>
        /// Add a <see cref="PartialView"/> instace to list.
        /// </summary>
        /// <param name="partialView">The <see cref="PartialView"/> used to add to the list.</param>
        public void AddPartialView(PartialView partialView)
        {
            this.PartialViews.Add(partialView);
        }

        /// <inheritdoc/>
        public virtual void Load()
        {
            this.PartialViews.ForEach(v => v.Load());
        }
    }
}
