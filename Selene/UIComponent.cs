//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-07-23</date>
//-----------------------------------------------------------------------
namespace Selene
{
    using OpenQA.Selenium;

    public abstract class UIComponent
    {
        protected readonly IWebDriver driver;

        protected UIComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
