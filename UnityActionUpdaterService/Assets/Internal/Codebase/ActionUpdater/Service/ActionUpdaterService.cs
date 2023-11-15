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
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using RimuruDev.Internal.Codebase.ActionUpdater.Enum;

namespace RimuruDev.Internal.Codebase.ActionUpdater.Service
{
    /// <summary>
    /// Manages the subscription of actions to Unity's update methods (FixedUpdate, Update, LateUpdate).
    /// Allows for centralized control of update logic, with the ability to pause all actions.
    /// </summary>
    public sealed class ActionUpdaterService : IActionUpdaterService
    {
        private readonly List<Action> fixedUpdateActionCache = new();
        private readonly List<Action> updateActionCache = new();
        private readonly List<Action> lateUpdateActionCache = new();

        private event Action OnFixedUpdate;
        private event Action OnUpdate;
        private event Action OnLateUpdate;

        private bool isPause;

        /// <summary>
        /// Subscribes an action to a specified update method.
        /// </summary>
        /// <param name="updateable">The action to subscribe.</param>
        /// <param name="updateType">The type of update method to subscribe to (FixedUpdate, Update, or LateUpdate).</param>
        public void Subscribe([NotNull] Action updateable, UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.FixedUpdate:
                    OnFixedUpdate += updateable;
                    fixedUpdateActionCache.Add(updateable);
                    break;
                case UpdateType.Update:
                    OnUpdate += updateable;
                    updateActionCache.Add(updateable);
                    break;
                case UpdateType.LateUpdate:
                    OnLateUpdate += updateable;
                    lateUpdateActionCache.Add(updateable);
                    break;
                default:
                    Debug.LogError($"ArgumentOutOfRangeException: {nameof(updateType)}, {updateType}");
                    break;
            }
        }

        /// <summary>
        /// Unsubscribes an action from a specified update method.
        /// </summary>
        /// <param name="updateable">The action to unsubscribe.</param>
        /// <param name="updateType">The type of update method to unsubscribe from.</param>
        public void Unsubscribe([NotNull] Action updateable, UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.FixedUpdate:
                    OnFixedUpdate -= updateable;
                    fixedUpdateActionCache.Remove(updateable);
                    break;
                case UpdateType.Update:
                    OnUpdate -= updateable;
                    updateActionCache.Remove(updateable);
                    break;
                case UpdateType.LateUpdate:
                    OnLateUpdate -= updateable;
                    lateUpdateActionCache.Remove(updateable);
                    break;
                default:
                    Debug.LogError($"ArgumentOutOfRangeException: {nameof(updateType)}, {updateType}");
                    break;
            }
        }

        /// <summary>
        /// Invokes all actions subscribed to FixedUpdate.
        /// </summary>
        public void FixedUpdate()
        {
            if (isPause)
                return;

            OnFixedUpdate?.Invoke();
        }

        /// <summary>
        /// Invokes all actions subscribed to Update.
        /// </summary>
        public void Update()
        {
            if (isPause)
                return;

            OnUpdate?.Invoke();
        }

        /// <summary>
        /// Invokes all actions subscribed to LateUpdate.
        /// </summary>
        public void LateUpdate()
        {
            if (isPause)
                return;

            OnLateUpdate?.Invoke();
        }

        /// <summary>
        /// Sets or unsets the pause state of the update actions.
        /// </summary>
        /// <param name="pause">True to pause, false to resume.</param>
        public void SetPause(bool pause) =>
            isPause = pause;

        /// <summary>
        /// Unsubscribes all actions from their respective update methods.
        /// </summary>
        public void Dispose()
        {
            UnsubscribeAll(fixedUpdateActionCache, ref OnFixedUpdate);
            UnsubscribeAll(updateActionCache, ref OnUpdate);
            UnsubscribeAll(lateUpdateActionCache, ref OnLateUpdate);
        }

        private static void UnsubscribeAll(ICollection<Action> actionList, ref Action eventDelegate)
        {
            eventDelegate = actionList.Aggregate(eventDelegate, (current, action) => current - action);

            actionList.Clear();
        }
    }
}