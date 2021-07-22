//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------
namespace Selene
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Extension methods for IWebDriver object.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds the first Selene.IWebElementModel on the current context.
        /// </summary>
        /// <typeparam name="TWebElementModel"></typeparam>
        /// <param name="driver">Extented object.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching OpenQA.Selenium.IWebElement on the current context.</returns>
        public static IWebElementModel FindElement<TWebElementModel>(this IWebDriver driver, By by)
           where TWebElementModel : WebElementModel
        {
            var wrappedElement = driver.FindElement(by);
            var webElementModel = Activator.CreateInstance(typeof(TWebElementModel), driver, wrappedElement) as TWebElementModel;
            return webElementModel;
        }

        /// <summary>
        /// Finds all Selene.IWebElementModel on the current context.
        /// </summary>
        /// <typeparam name="TWebElementModel"></typeparam>
        /// <param name="driver">Extented object.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A ReadOnlyCollection<T> of all IWebElementModel matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElementModel> FindElements<TWebElementModel>(this IWebDriver driver, By by)
            where TWebElementModel : WebElementModel
        {
            var list = new List<IWebElementModel>();
            var wrappedElements = driver.FindElements(by);

            foreach (var wrappedElement in wrappedElements)
            {
                list.Add(Activator.CreateInstance(typeof(TWebElementModel), driver, wrappedElement) as TWebElementModel);
            }

            return list.AsReadOnly();
        }

        /// <summary>
        /// Gets SessionId of WebDriverInstance.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <returns>SessionId of WebDriverInstance.</returns>
        public static SessionId GetSessionId(this IWebDriver driver)
        {
            return ((RemoteWebDriver)driver).SessionId;
        }

        /// <summary>
        /// Gets parameter value from current URL.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="name">Parameter name.</param>
        /// <returns>Parameter string value.</returns>
        public static string GetUrlParam(this IWebDriver driver, string name)
        {
            string param = name += "=";
            int index = driver.Url.IndexOf(param);
            return driver.Url.Substring(index + param.Length);
        }

        /// <summary>
        /// Performs wait action for expected condition.
        /// </summary>
        /// <typeparam name="TResult">Returned value from expected condition.</typeparam>
        /// <param name="driver">Extented object.</param>
        /// <param name="condition">Expected condition.</param>
        /// <param name="timeout">Expiration timeout.</param>
        /// <param name="exceptionTypes">Exceptions to be ignored while waiting for expected condition.</param>
        /// <returns>Expected condition result.</returns>
        public static TResult WaitFor<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, TimeSpan? timeout = null, params Type[] exceptionTypes)
        {
            if (!timeout.HasValue)
            {
                timeout = TimeSpan.FromSeconds(Options.WaitSeconds);
            }

            var wait = new WebDriverWait(driver, timeout.Value);

            wait.IgnoreExceptionTypes(exceptionTypes);

            return wait.Until(condition);
        }

        /// <summary>
        /// Loads new web page at given relative url.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="url">New web page relative url.</param>
        public static void NavigateToRelativeUrl(IWebDriver driver, string url)
        {
            var oldUrl = driver.Url;
            var newUrl = new Uri(Options.AppUrl).AbsolutePath;

            if (!string.IsNullOrWhiteSpace(url))
            {
                if (url.StartsWith("~/") || url.StartsWith("/"))
                {
                    url = url.Substring(1);
                }

                newUrl += url;
            }

            if (!string.Equals(oldUrl, newUrl))
            {
                driver.Navigate().GoToUrl(url);
                driver.WaitFor(Helpers.ExpectedConditions.PageRedirected(oldUrl));
            }
            else
            {
                driver.Navigate().Refresh();
            }
        }

        /// <summary>
        /// Gives focus to a web element.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="element">Target web element.</param>
        public static void Focus(this IWebDriver driver, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].focus();", element);
        }

        /// <summary>
        /// Gives focus to a wrapped web element.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="wrapsElement">Target wrapping element.</param>
        public static void Focus(this IWebDriver driver, IWrapsElement wrapsElement)
        {
            Focus(driver, wrapsElement.WrappedElement);
        }

        /// <summary>
        /// Removes focus from a web element.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="element">Fcoused web element.</param>
        public static void Unfocus(this IWebDriver driver, IWebElement element)
        {
            new Actions(driver).SendKeys(element, Keys.Tab).Perform();
        }

        /// <summary>
        /// Removes focus from a wrapped web element.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="wrapsElement">Focused wrapping element.</param>
        public static void Unfocus(this IWebDriver driver, IWrapsElement wrapsElement)
        {
            Unfocus(driver, wrapsElement.WrappedElement);
        }

        /// <summary>
        /// Scrolls to web element.
        /// </summary>
        /// <param name="driver">Extented object.</param>
        /// <param name="element">Target web element.</param>
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                            + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                            + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            ((IJavaScriptExecutor)driver).ExecuteScript(scrollElementIntoMiddle, element);
        }
    }
}
