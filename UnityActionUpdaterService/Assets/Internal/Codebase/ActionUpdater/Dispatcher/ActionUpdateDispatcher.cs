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

using Zenject;
using UnityEngine;
using RimuruDev.Internal.Codebase.ActionUpdater.Service;

namespace RimuruDev.Internal.Codebase.ActionUpdater.Dispatcher
{
    /// <summary>
    /// The ActionUpdateDispatcher is responsible for dispatching update calls
    /// to the IActionUpdaterService. It ensures that these updates continue
    /// across different scenes, as it persists across scene loads.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class ActionUpdateDispatcher : MonoBehaviour
    {
        private IActionUpdaterService actionUpdater;

        /// <summary>
        /// Injects the IActionUpdaterService dependency.
        /// This method is called by Zenject to provide the service instance.
        /// </summary>
        /// <param name="actionUpdater">The action updater service to be used for dispatching update events.</param>
        [Inject]
        private void Constructor(IActionUpdaterService actionUpdater) =>
            this.actionUpdater = actionUpdater;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Ensures this object is not destroyed when loading a new scene.
        /// </summary>
        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Called every fixed framerate frame. Delegates the call to the action updater service.
        /// </summary>
        private void FixedUpdate() =>
            actionUpdater?.FixedUpdate();

        /// <summary>
        /// Called every frame. Delegates the call to the action updater service.
        /// </summary>
        private void Update() =>
            actionUpdater?.Update();

        /// <summary>
        /// Called every frame after Update. Delegates the call to the action updater service.
        /// </summary>
        private void LateUpdate() =>
            actionUpdater?.LateUpdate();

        /// <summary>
        /// Called when the application is quitting. Disposes the action updater service.
        /// </summary>
        private void OnApplicationQuit() =>
            actionUpdater?.Dispose();
    }
}