// -----------------------------------------------------------------------
// <copyright file="Performer.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using System;

    /// <summary>
    /// Defines a set of helper methods for invoking delegate methods in try-catch blocks.
    /// </summary>
    public static class Performer
    {
        /// <summary>
        /// Invokes an <see cref="Action"/> delegate in try-catch block.
        /// Stores action description in format specified as pass or fail level (as result of try-catch block) by given <see cref="Logger"/> instance.
        /// Throws exception from catch block.
        /// </summary>
        /// <param name="action">The action delegate to be invoked in try-catch block.</param>
        /// <param name="actionDescription">The action description used to store by <paramref name="logger"/>.</param>
        /// <param name="logger">The <see cref="Logger"/> instance used to store action description.</param>
        public static void Do(Action action, string actionDescription, Logger logger)
        {
            try
            {
                action.Invoke();
                logger.Pass(actionDescription);
            }
            catch (Exception e)
            {
                logger.Fail(actionDescription, e.Message);
                throw;
            }
        }

        /// <summary>
        /// Invokes an <see cref="Action"/> delegate in try-catch block.
        /// Stores string representation of <see cref="LogEntry"/> instance in format specified as pass or fail level (as result of try-catch block) by given <see cref="Logger"/> instance.
        /// Throws exception from catch block.
        /// </summary>
        /// <param name="action">The action delegate to be invoked in try-catch block.</param>
        /// <param name="logEntry">The <see cref="LogEntry"/> instance used to store by <paramref name="logger"/>.</param>
        /// <param name="logger">The <see cref="Logger"/> instance used to store action description.</param>
        public static void Do(Action action, LogEntry logEntry, Logger logger)
        {
            Do(action, logEntry.ToString(), logger);
        }

        /// <summary>
        /// Attempts to invoke an <see cref="Action"/> delegate in try-catch block.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that the delegate encapsulates.</typeparam>
        /// <param name="action">The action delegate to be invoked in try-catch block.</param>
        /// <returns>The return value of the method that the delegate encapsulates.</returns>
        public static TResult Try<TResult>(Func<TResult> action)
        {
            try
            {
                return action.Invoke();
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Attempts to invoke an <see cref="Action"/> delegate in try-catch block.
        /// Stores action description in format specified as pass or fail level (as result of try-catch block) by given <see cref="Logger"/> instance.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that the delegate encapsulates.</typeparam>
        /// <param name="action">The action delegate to be invoked in try-catch block.</param>
        /// <param name="actionDescription">The action description used to store by <paramref name="logger"/>.</param>
        /// <param name="logger">The <see cref="Logger"/> instance used to store action description.</param>
        /// <returns>The return value of the method that the delegate encapsulates.</returns>
        public static TResult Try<TResult>(Func<TResult> action, string actionDescription, Logger logger)
        {
            TResult result;

            try
            {
                result = action.Invoke();
                logger.Pass(actionDescription);
            }
            catch (Exception e)
            {
                result = default;
                logger.Fail(actionDescription, e.Message);
            }

            return result;
        }

        /// <summary>
        /// Attempts to invoke an <see cref="Action"/> delegate in try-catch block.
        /// Stores string representation of <see cref="LogEntry"/> instance in format specified as pass or fail level (as result of try-catch block) by given <see cref="Logger"/> instance.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that the delegate encapsulates.</typeparam>
        /// <param name="action">The action delegate to be invoked in try-catch block.</param>
        /// <param name="logEntry">The <see cref="LogEntry"/> instance used to store by <paramref name="logger"/>.</param>
        /// <param name="logger">The <see cref="Logger"/> instance used to store action description.</param>
        /// <returns>The return value of the method that the delegate encapsulates.</returns>
        public static TResult Try<TResult>(Func<TResult> action, LogEntry logEntry, Logger logger)
        {
            return Try(action, logEntry.ToString(), logger);
        }
    }
}
