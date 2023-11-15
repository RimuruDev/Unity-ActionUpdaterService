// Resharper disable all
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System;
using System.Diagnostics.CodeAnalysis;
using RimuruDev.Internal.Codebase.ActionUpdater.Enum;

namespace RimuruDev.Internal.Codebase.ActionUpdater.Service
{
    /// <summary>
    /// Provides a service for subscribing actions to Unity's lifecycle methods.
    /// </summary>
    public interface IActionUpdaterService : IDisposable
    {
        /// <summary>
        /// Subscribes an action to a specified update type.
        /// </summary>
        /// <param name="updateable">The action to subscribe.</param>
        /// <param name="updateType">The type of update to subscribe to (FixedUpdate, Update, or LateUpdate).</param>
        public void Subscribe([NotNull] Action updateable, UpdateType updateType);

        /// <summary>
        /// Unsubscribes an action from a specified update type.
        /// </summary>
        /// <param name="updateable">The action to unsubscribe.</param>
        /// <param name="updateType">The type of update to unsubscribe from.</param>
        public void Unsubscribe([NotNull] Action updateable, UpdateType updateType);

        /// <summary>
        /// Invokes actions subscribed to FixedUpdate.
        /// </summary>
        public void FixedUpdate();

        /// <summary>
        /// Invokes actions subscribed to Update.
        /// </summary>
        public void Update();

        /// <summary>
        /// Invokes actions subscribed to LateUpdate.
        /// </summary>
        public void LateUpdate();

        /// <summary>
        /// Pauses or resumes the execution of subscribed actions.
        /// </summary>
        /// <param name="pause">True to pause actions, false to resume.</param>
        public void SetPause(bool pause);
    }
}