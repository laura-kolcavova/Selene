//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------
namespace Selene
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;

    public interface IWebElementModel : IWrapsElement
    {
    }

    public abstract class WebElementModel : IWebElementModel
    {
        protected IWebDriver Driver { get; }

        /// <summary>
        /// Gets WrappedElement
        /// </summary>
        public IWebElement WrappedElement { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElementModel"/> class.
        /// </summary>
        /// <param name="driver">Web driver.</param>
        /// <param name="wrappedElement">Wrapped element.</param>
        protected WebElementModel(IWebDriver driver, IWebElement wrappedElement)
        {
            Driver = driver;
            WrappedElement = wrappedElement;
        }
    }
}
