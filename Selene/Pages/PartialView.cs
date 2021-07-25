//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.Pages
{
    using OpenQA.Selenium;

    public abstract class PartialView : IView
    {
        protected readonly IWebDriver Driver;

        public Page Parent { get; }

        protected PartialView(IWebDriver driver, Page parent)
        {
            this.Driver = driver;
            Parent = parent;
        }

        public abstract void Load();
    }
}
