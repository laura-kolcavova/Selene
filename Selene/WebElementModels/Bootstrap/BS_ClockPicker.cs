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
    using System.Collections.ObjectModel;

    public class BS_ClockPicker : WebElementModel
    {
        public string Format { get; set; } = @"hh\:mm";

        public TimeSpan Time => GetTime();

        public BS_ClockPicker(IWebDriver driver, IWebElement wrappedElement) : base(driver, wrappedElement)
        {
        }

        private TimeSpan GetTime()
        {
            string val = Get.Val(this);

            if (string.IsNullOrEmpty(val))
            {
                return DateTime.Now.TimeOfDay;
            }
            else
            {
                return Helpers.Format.StringToTime(val, Format);
            }
        }

        public void EnterTime(TimeSpan time)
        {
            EnterTime(Helpers.Format.TimeToString(time, Format));
        }

        public void EnterTime(string time)
        {
            Set.Text(this, time, true);
        }

        public void SelectTime(TimeSpan time)
        {
            WrappedElement.Click();

            SelectHour(time.Hours);
            SelectMinute(time.Minutes);
        }

        private void SelectHour(int hour)
        {
            var pickerHours = new Picker(WrappedElement.FindElement(By.XPath("//div[contains(@class, 'clockpicker-hours')]")));

            pickerHours.GetTick(hour).Click();
        }

        private void SelectMinute(int minute)
        {
            var pickerMinutes = new Picker(WrappedElement.FindElement(By.XPath("//div[contains(@class, 'clockpicker-minutes')]")));

            pickerMinutes.GetTick(minute).Click();
        }
    }

    internal class Picker : IWrapsElement
    {
        public IWebElement WrappedElement { get; }

        public ReadOnlyCollection<IWebElement> Ticks => WrappedElement.FindElements(By.CssSelector(".clockpicker-tick"));

        public Picker(IWebElement element)
        {
            WrappedElement = element;
        }

        public IWebElement GetTick(int tick)
        {
            return Ticks[tick];
        }
    }
}
