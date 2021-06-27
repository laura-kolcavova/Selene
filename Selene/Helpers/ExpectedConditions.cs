//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.Helpers
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ExpectedConditions
    {
        /// <summary>
        /// An expectation for checking the page was redirected.
        /// </summary>
        /// <param name="oldUrl">The old URL.</param>
        /// <returns><see langword="true"/> when the page redirected; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebDriver, bool> PageRedirected(string oldUrl)
        {
            return (driver) =>
            {
                return driver.Url != oldUrl;
            };
        }
    }
}
