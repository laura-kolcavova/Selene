//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------
namespace Selene
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Wrapper for  IWebDriver ConcurrentQueue.
    /// </summary>
    public class WebDriverPool
    {
        private readonly ConcurrentQueue<IWebDriver> driverQueue;

        private readonly Dictionary<SessionId, SessionInfo> sessions;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverPool"/> class.
        /// </summary>
        public WebDriverPool()
        {
            driverQueue = new ConcurrentQueue<IWebDriver>();
            sessions = new Dictionary<SessionId, SessionInfo>();
        }

        /// <summary>
        /// Tries to obtain WebDriver from queue or creates new WebDriver instance if queue is empty.
        /// </summary>
        /// <param name="createDriverFunc">Delegate function for creating WebDriver instance.</param>
        /// <returns>Current IWebDriver instance.</returns>
        public IWebDriver Create(Func<IWebDriver> createDriverFunc)
        {
            if (!driverQueue.TryDequeue(out IWebDriver obtainedDriver))
            {
                var driver = createDriverFunc();
                sessions.Add(driver.GetSessionId(), new SessionInfo());
                return driver;
            }
            else
            {
                return obtainedDriver;
            }
        }

        /// <summary>
        /// Adds IWebDriver instance to the end of queue.
        /// </summary>
        /// <param name="webDriver">IWebDriver instance to enqueue.</param>
        public void Free(IWebDriver webDriver)
        {
            if (webDriver == null)
            {
                throw new ArgumentNullException(nameof(webDriver));
            }

            driverQueue.Enqueue(webDriver);
        }

        /// <summary>
        /// Gets SessionInfo by SessionId of IWebDriver Instance.
        /// </summary>
        /// <param name="sessionId">SessionId of IWebDriver Instance.</param>
        /// <returns>SessionInfo | null.</returns>
        public SessionInfo GetSessionInfo(SessionId sessionId)
        {
            if (sessions.TryGetValue(sessionId, out SessionInfo sessionInfo))
            {
                return sessionInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Close and quit all drivers and remove them from queue.
        /// </summary>
        public void QuitAllDrivers()
        {
            while (driverQueue.TryDequeue(out IWebDriver driver))
            {
                driver.Close();
                driver.Quit();
            }

            sessions.Clear();
        }
    }
}