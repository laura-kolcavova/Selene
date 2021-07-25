//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------
namespace Selene
{
    /// <summary>
    /// Custom session data related with <see cref="OpenQA.Selenium.IWebDriver"/>`s <see cref=" OpenQA.Selenium.Remote.SessionId"/>.
    /// </summary>
    public class SessionInfo
    {

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets LoggedIn value.
        /// </summary>
        public bool LoggedIn { get; set; }
    }
}