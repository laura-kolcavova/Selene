//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.UI.Html
{
    using OpenQA.Selenium;
    using Selene.Helpers;
    using Selene.UI.Html;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class RadioButtonGroupComponent : UIComponent
    {
        public ReadOnlyCollection<RadioButtonElement> Buttons { get; }

        public RadioButtonElement SelectedButton => Buttons.FirstOrDefault(e => e.Selected);

        public RadioButtonGroupComponent(IWebDriver driver, params RadioButtonElement[]  radioButtons )
            : base(driver)
        {
            Buttons = radioButtons.ToList().AsReadOnly();
        }

        public void SelectByValue(string value)
        {
            Buttons
                .FirstOrDefault(b => string.Equals(Get.Val(b), value))?
                .Check();
        }

        public void SelectByIndex(int index)
        {
            Buttons[index].Check();
        }
    }
}
