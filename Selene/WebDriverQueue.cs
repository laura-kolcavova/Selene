// -----------------------------------------------------------------------
// <copyright file="WebDriverQueue.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using System;
    using System.Collections.Concurrent;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a <see cref="ConcurrentQueue{T}"/> of WebDriver instances.
    /// </summary>
    public class WebDriverQueue
    {
        private readonly ConcurrentQueue<IWebDriver> driverQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverQueue"/> class.
        /// </summary>
        public WebDriverQueue()
        {
            this.driverQueue = new ConcurrentQueue<IWebDriver>();
        }

        /// <summary>
        /// Attempts to obtain previously created instance of WebDriver from queue or creates new instance of WebDriver by specified delegate if queue is empty.
        /// </summary>
        /// <param name="createDriverMethod">The delegate used to create WebDriver instance.</param>
        /// <returns>Previously created instance of WebDriver obtained from queue if queue is not empty; otherwise, new instance of WebDriver.</returns>
        public IWebDriver Obtain(Func<IWebDriver> createDriverMethod)
        {
            if (!this.driverQueue.TryDequeue(out IWebDriver obtainedDriver))
            {
                obtainedDriver = createDriverMethod();
            }

            return obtainedDriver;
        }

        /// <summary>
        /// Adds WebDriver instance to the end of queue.
        /// </summary>
        /// <param name="webDriver">A WebDriver instance used to add to the end of queue.</param>
        public void Free(IWebDriver webDriver)
        {
            if (webDriver == null)
            {
                throw new ArgumentNullException(nameof(webDriver));
            }

            this.driverQueue.Enqueue(webDriver);
        }

        /// <summary>
        /// Close and quit all WebDriver instances and clears whole queue.
        /// </summary>
        public void QuitAllDrivers()
        {
            while (this.driverQueue.TryDequeue(out IWebDriver driver))
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
