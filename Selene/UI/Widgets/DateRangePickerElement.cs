//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.UI.Widgets
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selene.Helpers;

    public class DateRangePickerElement : UIElement
    {
        public string Format { get; set; } = "dd.MM.yyyy H:mm";

        public IWebElement Dropdown => driver.FindElement(By.CssSelector(".daterangepicker.dropdown-menu[style*='display: block']"));

        public IWebElement SelectHour => Dropdown.FindElement(By.CssSelector(".hourselect"));

        public IWebElement SelectMinute => Dropdown.FindElement(By.CssSelector(".minuteselect"));

        public IWebElement SelectMonth => Dropdown.FindElement(By.CssSelector(".monthselect"));

        public IWebElement SelectYear => Dropdown.FindElement(By.CssSelector(".yearselect"));

        public DateTime Date => GetDate();

        public DateRangePickerElement(IWebDriver driver, IWebElement webElement)
            : base(driver, webElement)
        {
        }
        public void EnterDate(DateTime date)
        {
            EnterDate(Helpers.Format.DateToString(date, Format));
        }

        public void EnterDate(string date)
        {
            Set.Text(this, date, true);
            //Driver.WaitForAndSendKeys(WrappedElement, date, log);
        }

        public void SelectDate(DateTime date)
        {
            WrappedElement.Click();

            //Driver.WaitForAndClick(WrappedElement, log);

            //Driver.WaitFor(ElementToBeClickable(Dropdown), log);

            if (Format.Contains("yyyy") && Date.Year != date.Year)
            {
                GoToYear(date.Year);
            }

            if (Format.Contains("MM") && Date.Month != date.Month)
            {
                GoToMonth(date.Month);
            }

            if (Format.Contains("dd"))
            {
                GoToDay(date.Day);
            }

            // h

            // m

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        private DateTime GetDate()
        {
            if (Get.Val(this)?.Length == 0)
            {
                return DateTime.Today;
            }
            else
            {
                return Helpers.Format.StringToDate(Get.Val(this), Format);
            }
        }

        private void GoToDay(int day)
        {
            var dayPickers = Dropdown.FindElements(By.CssSelector("body td.available:not(.off)"));
            dayPickers[day - 1].Click();
        }

        private void GoToMonth(int month)
        {
            var selectMonth = new SelectElement(SelectMonth);
            selectMonth.SelectByValue(month.ToString());
        }

        private void GoToYear(int year)
        {
            var selectYear = new SelectElement(SelectYear);
            selectYear.SelectByValue(year.ToString());
        }
    }
}
