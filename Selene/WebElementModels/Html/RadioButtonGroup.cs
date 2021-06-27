//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.WebElementModels.Html
{
    using OpenQA.Selenium;
    using Selene.Helpers;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class RadioButtonGroup
    {
        public ReadOnlyCollection<RadioButton> Buttons { get; }

        public RadioButton SelectedButton => Buttons.FirstOrDefault(e => e.Selected);

        private readonly IWebDriver _driver;

        public RadioButtonGroup(IWebDriver driver, ReadOnlyCollection<RadioButton> radioButtons)
        {
            _driver = driver;
            Buttons = radioButtons;
        }

        public RadioButtonGroup(IWebDriver driver, ReadOnlyCollection<IWebElement> elements)
        {
            _driver = driver;
            Buttons = elements.Select(we => new RadioButton(driver, we)).ToList().AsReadOnly();
        }

        public void SelectByValue(string value)
        {
            Buttons
                .FirstOrDefault(b => string.Equals(Get.Val(b), value))
                .Check();
        }

        public void SelectByIndex(int index)
        {
            Buttons[index].Check();
        }


    }

}
