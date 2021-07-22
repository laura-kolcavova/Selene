//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-07-23</date>
//-----------------------------------------------------------------------
namespace Selene.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Remote;

    public static class IWebElementExtensions
    {
        public static IWebDriver GetDriver(this IWebElement element)
        {
            var realElement = element.GetType() != typeof(RemoteWebElement)
                  ? element
                  : ((IWrapsElement)element).WrappedElement;

            return ((IWrapsDriver)realElement).WrappedDriver;
        }
    }
}
