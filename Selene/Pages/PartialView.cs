//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public abstract class PartialView : IView
    {
        protected IWebDriver Driver { get; }

        public Page Parent { get; }

        public PartialView(IWebDriver driver, Page parent)
        {
            Driver = driver;
            Parent = parent;
        }

        public abstract void Load();
    }
}
