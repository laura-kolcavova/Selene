//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.WebElementModels.Bootstrap
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using Selene.Helpers;
    using System;

    public class BS_DatePicker : WebElementModel
    {
        public string Format { get; set; } = "dd.MM.yyyy";

        public IWebElement Dropdown => WrappedElement.FindElement(By.XPath("//div[contains(@class, 'datepicker-dropdown')]"));

        public DateTime Date => GetDate();

        public BS_DatePicker(IWebDriver driver, IWebElement wrappedElement) : base(driver, wrappedElement)
        {
        }

        public void EnterDate(DateTime date)
        {
            EnterDate(FormatHelper.DateToString(date, Format));
        }

        public void EnterDate(string date)
        {
            Set.Text(this, date, true);
        }

        public void SelectDate(DateTime date)
        {
            WrappedElement.Click();

            //SeleniumHelper.WaitUntilVisible(driver, By.CssSelector(".datepicker.datepicker-dropdown"));

            var picker_days = new Picker(Dropdown.FindElement(By.CssSelector(".datepicker-days")));
            var picker_months = new Picker(Dropdown.FindElement(By.CssSelector(".datepicker-months")));

            if (Date.Year != date.Year && Format.Contains("yyyy"))
            {
                GoToYear(date.Year, picker_months, picker_days);
            }

            if (Date.Month != date.Month && Format.Contains("MM"))
            {
                GoToMonth(date.Month, picker_months, picker_days);
            }

            if (Format.Contains("dd"))
            {
                GoToDay(date.Day, picker_days);
            }

        }

        private void GoToYear(int year, Picker picker_months, Picker picker_days)
        {
            if (Format.Contains("dd")) picker_days.BtnSwitch.Click();

            int dp_year = Date.Year;

            while (year != dp_year)
            {
                if (year > dp_year)
                {
                    picker_months.BtnNext.Click();
                    dp_year++;
                }
                else
                {
                    picker_months.BtnPrev.Click();
                    dp_year--;
                }
            }

            picker_months.WrappedElement.FindElement(By.CssSelector(".month.focused")).Click();
        }

        private void GoToMonth(int month, Picker picker_months, Picker picker_days)
        {
            picker_days.BtnSwitch.Click();

            var months = picker_months.WrappedElement.FindElements(By.CssSelector(".month"));

            months[month - 1].Click();
        }

        private void GoToDay(int day, Picker picker_days)
        {
            var days = picker_days.WrappedElement.FindElements(By.CssSelector(".day:not(.old)"));

            days[day - 1].Click();
        }

        private DateTime GetDate()
        {
            if (Get.Val(this) == string.Empty)
            {
                return DateTime.Today;
            }
            else
            {
                return FormatHelper.StringToDate(Get.Val(this), Format);
            }
        }

        internal class Picker : IWrapsElement
        {
            public IWebElement WrappedElement { get; }

            public IWebElement BtnPrev => WrappedElement.FindElement(By.CssSelector(".prev"));
            public IWebElement BtnNext => WrappedElement.FindElement(By.CssSelector(".next"));
            public IWebElement BtnSwitch => WrappedElement.FindElement(By.CssSelector(".datepicker-switch"));

            public Picker(IWebElement element)
            {
                WrappedElement = element;
            }
        }
    }
}
