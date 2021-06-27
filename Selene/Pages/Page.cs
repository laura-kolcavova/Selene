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
        protected IWebDriver Driver { get; }

        public List<PartialView> PartialViews { get; }

        public string Title { get; set; }  

        public Page(IWebDriver driver)
        {
            Driver = driver;
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
