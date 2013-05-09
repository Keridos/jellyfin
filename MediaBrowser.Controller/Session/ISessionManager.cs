﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBrowser.Model.Session;

namespace MediaBrowser.Controller.Session
{
    /// <summary>
    /// Interface ISessionManager
    /// </summary>
    public interface ISessionManager
    {
        /// <summary>
        /// Occurs when [playback start].
        /// </summary>
        event EventHandler<PlaybackProgressEventArgs> PlaybackStart;

        /// <summary>
        /// Occurs when [playback progress].
        /// </summary>
        event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;

        /// <summary>
        /// Occurs when [playback stopped].
        /// </summary>
        event EventHandler<PlaybackProgressEventArgs> PlaybackStopped;

        /// <summary>
        /// Gets all connections.
        /// </summary>
        /// <value>All connections.</value>
        IEnumerable<SessionInfo> AllConnections { get; }

        /// <summary>
        /// Gets the active connections.
        /// </summary>
        /// <value>The active connections.</value>
        IEnumerable<SessionInfo> RecentConnections { get; }

        /// <summary>
        /// Logs the user activity.
        /// </summary>
        /// <param name="clientType">Type of the client.</param>
        /// <param name="deviceId">The device id.</param>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="user">The user.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        Task LogConnectionActivity(string clientType, string deviceId, string deviceName, User user);

        /// <summary>
        /// Used to report that playback has started for an item
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="item">The item.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <param name="deviceId">The device id.</param>
        /// <param name="deviceName">Name of the device.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        void OnPlaybackStart(User user, BaseItem item, string clientType, string deviceId, string deviceName);

        /// <summary>
        /// Used to report playback progress for an item
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="item">The item.</param>
        /// <param name="positionTicks">The position ticks.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <param name="deviceId">The device id.</param>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        Task OnPlaybackProgress(User user, BaseItem item, long? positionTicks, string clientType, string deviceId, string deviceName);

        /// <summary>
        /// Used to report that playback has ended for an item
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="item">The item.</param>
        /// <param name="positionTicks">The position ticks.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <param name="deviceId">The device id.</param>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        Task OnPlaybackStopped(User user, BaseItem item, long? positionTicks, string clientType, string deviceId, string deviceName);
    }
}