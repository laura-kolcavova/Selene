//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.WebElementModels.Html
{
    using OpenQA.Selenium;
    using Selene.Helpers;

    public class RadioButton : WebElementModel
    {
        public IWebElement Label => GetLabel();

        public bool Selected => WrappedElement.Selected;

        public RadioButton(IWebDriver driver, IWebElement wrappedElement) : base(driver, wrappedElement)
        {
        }

        public void Click()
        {
            Label.Click();
        }

        public void Check()
        {
            if (!Selected) Click();
        }

        public void Uncheck()
        {
            if (Selected) Click();
        }

        private IWebElement GetLabel()
        {
            string id = Get.Id(WrappedElement);
            return WrappedElement.FindElement(By.XPath($"//label[@for='{id}']"));
        }

    }
}
