//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public abstract class UIElement : IWrapsElement
    {
        protected readonly IWebDriver Driver;

        /// <summary>
        /// Gets WrappedElement
        /// </summary>
        public IWebElement WrappedElement { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIElement"/> class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        /// <param name="wrappedElement">Wrapped element.</param>
        protected UIElement(IWebDriver driver, IWebElement wrappedElement)
        {
            Driver = driver;
            WrappedElement = wrappedElement;
        }

        //protected UIElement(IWebElement wrappedElement)
        //{
        //    this.driver = wrappedElement.GetDriver();
        //    WrappedElement = wrappedElement;
        //}
    }
}
