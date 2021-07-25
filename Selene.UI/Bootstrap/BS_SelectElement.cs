//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.UI.Bootstrap
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selene.Helpers;
    using Selene.Extensions;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class BS_SelectElement : UIElement
    {
        public SelectElement SelectElement { get; }

        public bool IsCombobox { get; }

        public IWebElement SelectedOption => SelectElement.SelectedOption;

        public IWebElement DropdownToggle => WrappedElement.FindElement(By.XPath("../button[contains(@class, 'dropdown-toggle')]"));

        public IWebElement DropdownMenu => WrappedElement.FindElement(By.XPath("../div[contains(@class, 'dropdown-menu')]"));

        public IWebElement TxtSearch => DropdownMenu.FindElement(By.CssSelector(".bs-searchbox input[type='search']"));

        public IWebElement Listbox => DropdownMenu.FindElement(By.CssSelector("div[role='listbox'] > ul"));

        public ReadOnlyCollection<IWebElement> BS_Options => Listbox.FindElements(By.CssSelector("li > a"));

        public bool IsOpen => DropdownMenu.Displayed;

        public BS_SelectElement(IWebDriver driver, IWebElement
            wrappedElement) : base(driver, wrappedElement)
        {
            SelectElement = new SelectElement(wrappedElement);
            IsCombobox = Get.Attr(wrappedElement, "data-live-search") == "true";
        }

        private void OpenDropdownMenu()
        {
            DropdownToggle.Click();
            Driver.WaitFor(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Listbox));
        }

        public void SelectByIndex(int index)
        {
            if (!IsOpen) OpenDropdownMenu();

            BS_Options[index].Click();

            Driver.WaitFor(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(DropdownMenu));
        }

        public void SelectByValue(string value)
        {
            if (!IsOpen) OpenDropdownMenu();

            int index = -1;
            SelectElement.Options
                .Select(o => Get.Val(o))
                .Where(o_value => !string.IsNullOrEmpty(o_value))
                .First(o_value =>
                {
                    index++;
                    return string.Equals(o_value, value);
                });

            BS_Options[index].Click();

            Driver.WaitFor(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(DropdownMenu));
        }

        public void SelectByText(string text)
        {
            if (!IsOpen) OpenDropdownMenu();

            BS_Options.FirstOrDefault(o => string.Equals(o.Text, text))?
                .Click();

            Driver.WaitFor(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(DropdownMenu));
        }

        public void TypeInSearch(string value, bool clear = false)
        {
            if (!IsCombobox) return;

            if (!IsOpen) OpenDropdownMenu();

            Set.Text(TxtSearch, value, clear);

            Driver.WaitFor(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Listbox));
        }
    }
}

