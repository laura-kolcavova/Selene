//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

using Selene.Extensions;

namespace Selene
{
    using System;
    using System.Collections.Concurrent;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Wrapper class for IWebDriver ConcurrentQueue.
    /// </summary>
    public class WebDriverQueue
    {
        private readonly ConcurrentQueue<IWebDriver> _driverQueue;

        private readonly ConcurrentDictionary<SessionId, SessionInfo> _sessions;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverQueue"/> class.
        /// </summary>
        public WebDriverQueue()
        {
            _driverQueue = new ConcurrentQueue<IWebDriver>();
            _sessions = new ConcurrentDictionary<SessionId, SessionInfo>();
        }

        /// <summary>
        /// Tries to obtain WebDriver from queue or creates new WebDriver instance if queue is empty.
        /// </summary>
        /// <param name="createDriverFunc">Delegate function for creating WebDriver instance.</param>
        /// <returns>Current IWebDriver instance.</returns>
        public IWebDriver Obtain(Func<IWebDriver> createDriverFunc)
        {
            if (!_driverQueue.TryDequeue(out IWebDriver obtainedDriver))
            {
                obtainedDriver = createDriverFunc();
                _sessions.TryAdd(obtainedDriver.GetSessionId(), new SessionInfo());
            }

            return obtainedDriver;
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

            _driverQueue.Enqueue(webDriver);
        }

        /// <summary>
        /// Gets SessionInfo by SessionId of IWebDriver Instance.
        /// </summary>
        /// <param name="sessionId">SessionId of IWebDriver Instance.</param>
        /// <returns>SessionInfo | null.</returns>
        public SessionInfo GetSessionInfo(SessionId sessionId)
        {
            if (_sessions.TryGetValue(sessionId, out SessionInfo sessionInfo))
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
            while (_driverQueue.TryDequeue(out IWebDriver driver))
            {
                driver.Close();
                driver.Quit();
            }

            _sessions.Clear();
        }
    }
}
