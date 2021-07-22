////-----------------------------------------------------------------------
////  <author>Laura Kolčavová</author>
////  <date>2021-06-27</date>
////-----------------------------------------------------------------------

//namespace Selene.Helpers
//{
//    using OpenQA.Selenium;
//    using System;
//    using System.Collections.ObjectModel;
//    using System.Linq;

//    /// /// <summary>
//    /// Supplies a set of common conditions that can be waited for using <see cref="WebDriverWait"/>.
//    /// </summary>
//    public static class ExpectedConditions
//    {
//        /// <summary>
//        /// An expectation for checking the page was redirected.
//        /// </summary>
//        /// <param name="oldUrl">The old URL.</param>
//        /// <returns><see langword="true"/> when the page redirected; otherwise, <see langword="false"/>.</returns>
//        public static Func<IWebDriver, bool> PageRedirected(string oldUrl)
//        {
//            return (driver) =>
//            {
//                return driver.Url != oldUrl;
//            };
//        }

//        public static Func<IWebDriver, IWebElement> ElementIsAttached(By locator)
//        {
//            return (driver) =>
//            {
//                return driver.FindElement(locator);
//            };
//        }

//        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> AllElementsAreAttached(By locator)
//        {
//            return (driver) =>
//            {
//                var elements = driver.FindElements(locator);
//                return elements.Any() ? elements : null;
//            };
//        }

//        public static Func<IWebDriver, bool> ElementIsDettached(IWebElement element)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return element == null || !element.Enabled;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return true;
//                }
//            };
//        }

//        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    var element = driver.FindElement(locator);
//                    return element.Displayed ? element : null;
//                }
//                catch(StaleElementReferenceException)
//                {
//                    return null;
//                }
//            };
//        }

//        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return element.Displayed;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return false;
//                }
//            };
//        }

//        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> AllElementsAreVisible(By locator)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    var elements = driver.FindElements(locator);
//                    return !elements.Any(element => !element.Displayed) ? elements : null;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return null;
//                }
//            };
//        }

//        public static Func<IWebDriver, bool> AllElementsAreVisible(ReadOnlyCollection<IWebElement> elements)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return !elements.Any(element => !element.Displayed);
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return false;
//                }
//            };
//        }

//        public static Func<IWebDriver, bool> ElementIsUnvisible(By locator)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    var element = driver.FindElement(locator);
//                    return !element.Displayed;
//                }
//                catch (NoSuchElementException)
//                {
//                    return true;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return true;
//                }
//            };
//        }

//        public static Func<IWebDriver, bool> ElementIsUnvisible(IWebElement element)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return !element.Displayed;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return true;
//                }
//            };
//        }

//        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    var element = driver.FindElement(locator);
//                    return element.Displayed && element.Enabled ? element : null;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return null;
//                }
//            };
//        }

//        public static Func<IWebDriver, bool> ElementToBeClickable(IWebElement element)
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return element.Displayed && element.Enabled;
//                }
//                catch (StaleElementReferenceException)
//                {
//                    return false;
//                }
//            };
//        }

//        public static Func<IWebDriver, IAlert> AlertIsPresent()
//        {
//            return (driver) =>
//            {
//                try
//                {
//                    return driver.SwitchTo().Alert();
//                }
//                catch (NoAlertPresentException)
//                {
//                    return null;
//                }
//            };
//        }
//    }
//}
