// -----------------------------------------------------------------------
// <copyright file="WebDriverExtensions.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// A set of extension methods for <see cref="IWebDriver"/> interface.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds the first <see cref="IWebElement"/> on the current context using the given method and recreates it to instance of derived class of <see cref="UIElement"/>.
        /// </summary>
        /// <typeparam name="TUIElement">Derived class of <see cref="UIElement"/>.</typeparam>
        /// <param name="driver">Context.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching <see cref="IWebElement"/> on the current context recreated to instance of derived class of <see cref="UIElement"/>.</returns>
        public static TUIElement FindElement<TUIElement>(this IWebDriver driver, By by)
           where TUIElement : UIElement
        {
            var wrappedElement = driver.FindElement(by);
            return Activator.CreateInstance(typeof(TUIElement), driver, wrappedElement) as TUIElement;
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism and recreates them to instances of derived class of <see cref="UIElement"/>.
        /// </summary>
        /// <typeparam name="TUIElement">Derived class of <see cref="UIElement"/>.</typeparam>
        /// <param name="driver">Context.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A <see cref="ReadOnlyCollection{T}"/> of all <see cref="IWebElement"/> recreated to instances of derived class of <see cref="UIElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<TUIElement> FindElements<TUIElement>(this IWebDriver driver, By by)
            where TUIElement : UIElement
        {
            var list = new List<TUIElement>();

            foreach (var wrappedElement in driver.FindElements(by))
            {
                list.Add(Activator.CreateInstance(typeof(TUIElement), driver, wrappedElement) as TUIElement);
            }

            return list.AsReadOnly();
        }

        /// <summary>
        /// Gets <see cref="RemoteWebDriver.SessionId"/> for the current session of this driver.
        /// </summary>
        /// <param name="driver">The WebDriver instace used to get the SessionId.</param>
        /// <returns>The <see cref="SessionId"/>.</returns>
        public static SessionId GetSessionId(this IWebDriver driver)
        {
            return ((RemoteWebDriver)driver).SessionId;
        }

        /// <summary>
        /// Gets session data associated with <see cref="RemoteWebDriver.SessionId"/> from <see cref="SessionDataStorage"/>.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to get session data.</param>
        /// <returns>The session data.</returns>
        public static Dictionary<string, object> GetSessionData(this IWebDriver driver)
        {
            return SessionDataStorage.TryGet(driver.GetSessionId());
        }

        /// <summary>
        /// Gets parameter value from current URL.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="name">Parameter name.</param>
        /// <returns>Parameter value.</returns>
        public static string GetUrlParam(this IWebDriver driver, string name)
        {
            var param = name += "=";
            var index = driver.Url.IndexOf(param, StringComparison.Ordinal);
            return driver.Url[(index + param.Length) ..];
        }

        /// <summary>
        /// Performs <see cref="DefaultWait{IWebDriver}.Until{TResult}(Func{IWebDriver, TResult})"/> method using the given expected condition delegate and timeout expiration.
        /// </summary>
        /// <typeparam name="TResult">Returned value from expected condition.</typeparam>
        /// <param name="driver">Context.</param>
        /// <param name="condition">Expected condition delegate.</param>
        /// <param name="timeout">Timeout expiration.</param>
        /// <param name="exceptionTypes">Specific types of exceptions to be ignored while waiting for a condition.</param>
        /// <returns>The expected condition`s return value.</returns>
        public static TResult WaitFor<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, TimeSpan? timeout = null, params Type[] exceptionTypes)
        {
            timeout ??= TimeSpan.FromSeconds(SeleneTest.Options.WaitSeconds);

            var wait = new WebDriverWait(driver, timeout.Value);

            wait.IgnoreExceptionTypes(exceptionTypes);

            return wait.Until(condition);
        }

        /// <summary>
        /// Loads a new web page at given URL and then waits to redirect is finished or refreshes page if the URL is the same.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="url">The URL to load. It is best to use a fully qualified URL.</param>
        public static void NavigateToUrl(this IWebDriver driver, string url)
        {
            var oldUrl = driver.Url;
            var newUrl = new Uri(url).AbsolutePath;

            if (!string.Equals(oldUrl, newUrl))
            {
                driver.Navigate().GoToUrl(newUrl);
                driver.WaitFor(d =>
                {
                    return d.Url != oldUrl;
                });
            }
            else
            {
                driver.Navigate().Refresh();
            }
        }

        /// <summary>
        /// Loads a new web page at given relative URL and then waits to redirect is finished or refreshes page if the URL is the same.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="url">The relative URL to load. It is best to use a fully qualified URL.</param>
        public static void NavigateToRelativeUrl(this IWebDriver driver, string url)
        {
            var newUrl = SeleneTest.Options.BaseUrl;

            if (!string.IsNullOrWhiteSpace(url))
            {
                if (url.StartsWith("~/") || url.StartsWith("/"))
                {
                    url = url[1..];
                }

                newUrl += url;
            }

            driver.NavigateToUrl(newUrl);
        }

        /// <summary>
        /// Gives focus to a <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="element">Target <see cref="IWebElement"/>.</param>
        public static void Focus(this IWebDriver driver, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].focus();", element);
        }

        /// <summary>
        /// Removes focus from a <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="element">Fcoused <see cref="IWebElement"/>.</param>
        public static void Unfocus(this IWebDriver driver, IWebElement element)
        {
            new Actions(driver).SendKeys(element, Keys.Tab).Perform();
        }

        /// <summary>
        /// Scrolls to <see cref="IWebElement"/> using <see cref="IJavaScriptExecutor"/>.
        /// </summary>
        /// <param name="driver">Context.</param>
        /// <param name="element">Target <see cref="IWebElement"/>.</param>
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            const string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                            + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                            + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, element);
        }
    }
}
