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


using UnityEngine;
using RimuruDev.Internal.Codebase.ActionUpdater.Enum;
using RimuruDev.Internal.Codebase.ActionUpdater.Service;

namespace RimuruDev.Internal.Codebase.Example
{
    /// <summary>
    /// Hero class that demonstrates how to subscribe to update events using the IActionUpdaterService.
    /// It logs different types of updates: FixedUpdate, Update, and LateUpdate.
    /// </summary>
    public sealed class Hero
    {
        private const string DebugFormat = "<color=yellow>{0}</color>";
        private readonly IActionUpdaterService updaterService;

        /// <summary>
        /// Initializes a new instance of the Hero class.
        /// </summary>
        /// <param name="updaterService">The IActionUpdaterService instance to use for subscribing to update events.</param>
        public Hero(IActionUpdaterService updaterService) =>
            this.updaterService = updaterService;

        /// <summary>
        /// Prepares the Hero by subscribing to various update types.
        /// </summary>
        public void Prepare()
        {
            updaterService.Subscribe(OnFixedUpdate, UpdateType.FixedUpdate);
            updaterService.Subscribe(OnUpdate, UpdateType.Update);
            updaterService.Subscribe(OnLateUpdate, UpdateType.LateUpdate);
        }

        private void OnFixedUpdate() =>
            LogFormat("OnFixedUpdate");

        private void OnUpdate() =>
            LogFormat("OnUpdate");

        private void OnLateUpdate() =>
            LogFormat("OnLateUpdate");

        /// <summary>
        /// Logs the specified message in a formatted manner.
        /// </summary>
        /// <param name="message">The message to log.</param>
        private void LogFormat(string message) =>
            Debug.LogFormat(DebugFormat, message);
    }
}