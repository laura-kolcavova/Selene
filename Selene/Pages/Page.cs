//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using System.Collections.Generic;

namespace Selene.Pages
{
    public abstract class Page : IView
    {
        protected readonly IWebDriver driver;

        public List<PartialView> PartialViews { get; }

        public string Title { get; set; }

        protected Page(IWebDriver driver)
        {
            this.driver = driver;
            PartialViews = new List<PartialView>();
        }

        public void AddView(PartialView partialView)
        {
            PartialViews.Add(partialView);
        }

        public virtual void Load()
        {
            PartialViews.ForEach(v =>
            {
                v.Load();
            });
        }
    }
}
