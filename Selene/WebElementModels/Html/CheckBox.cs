//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.WebElementModels.Html
{
    using OpenQA.Selenium;

    public class CheckBox : WebElementModel
    {
        public IWebElement Label => WrappedElement.FindElement(By.XPath($"//label[@for='{WrappedElement.GetAttribute("id")}']"));

        public bool Selected => WrappedElement.Selected;

        public CheckBox(IWebDriver driver, IWebElement wrappedElement) : base(driver, wrappedElement)
        {
        }

        public void Click()
        {
            Label.Click();
        }

        public void Check()
        {
            // if (Get.Val(Element) == "false") Click();
            if (!Selected) Click();
        }

        public void Uncheck()
        {
            if (Selected) Click();
        }
    }
}
