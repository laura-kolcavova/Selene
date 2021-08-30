// -----------------------------------------------------------------------
// <copyright file="SessionDataStorage.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Represents a session data storage.
    /// </summary>
    public static class SessionDataStorage
    {
        private static readonly ConcurrentDictionary<SessionId, Dictionary<string, object>> sessions;

        static SessionDataStorage()
        {
            sessions = new ConcurrentDictionary<SessionId, Dictionary<string, object>>();
        }

        /// <summary>
        /// Clears session storage.
        /// </summary>
        public static void Clear()
        {
            sessions.Clear();
        }

        /// <summary>
        /// Attempts to add session data associated with specified <see cref="SessionId"/> instance from the storage.
        /// </summary>
        /// <param name="sessionId"><see cref="SessionId"/> instace used as key.</param>
        /// <param name="sessionData">Session data associated with <paramref name="sessionId"/>.</param>
        /// /// <returns>true if the object was added successfully; otherwise, false.</returns>
        public static bool TryAdd(SessionId sessionId, Dictionary<string, object> sessionData)
        {
            return sessions.TryAdd(sessionId, sessionData);
        }

        /// <summary>
        /// Attempts to remove session data associated with specified <see cref="SessionId"/> instance from the storage.
        /// </summary>
        /// <param name="sessionId"><see cref="SessionId"/> instace used as key.</param>
        /// /// <returns>true if the object was removed successfully; otherwise, false.</returns>
        public static bool TryRemove(SessionId sessionId)
        {
            return sessions.TryRemove(sessionId, out _);
        }

        /// <summary>
        /// Attempts to get session data associated with specified <see cref="SessionId"/> instance from the storage.
        /// </summary>
        /// <param name="sessionId"><see cref="SessionId"/> instace used as key.</param>
        /// <returns>session data if key was found in the storage; otherwise, null.</returns>
        public static Dictionary<string, object> TryGet(SessionId sessionId)
        {
            if (sessions.TryGetValue(sessionId, out var sessionData))
            {
                return sessionData;
            }
            else
            {
                return null;
            }
        }
    }
}
