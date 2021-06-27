//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------
namespace Selene.Helpers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public static class Set
    {
        public static void Text(IWebElement element, string value, bool clear = false)
        {
            if (clear) element.Clear();
            element.SendKeys(value);
        }

        public static void Text(IWrapsElement wrapsElement, string value, bool clear = false)
        {
            Text(wrapsElement.WrappedElement, value, clear);
        }
    }
}
