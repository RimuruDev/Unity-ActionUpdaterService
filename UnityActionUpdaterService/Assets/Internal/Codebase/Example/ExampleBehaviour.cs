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

namespace RimuruDev.Internal.Codebase.Example
{
    /// <summary>
    /// ExampleBehaviour demonstrates how to use the IActionUpdaterService in a MonoBehaviour.
    /// It initializes and uses a Hero object which is not a MonoBehaviour.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class ExampleBehaviour : MonoBehaviour
    {
        private Hero hero;
        private IActionUpdaterService actionUpdater;

        /// <summary>
        /// Injects the IActionUpdaterService dependency.
        /// This method is called by Zenject to provide the service instance.
        /// </summary>
        /// <param name="actionUpdater">The action updater service to be used.</param>
        [Inject]
        private void Constructor(IActionUpdaterService actionUpdater) =>
            this.actionUpdater = actionUpdater;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Initializes the Hero object and prepares it for updates.
        /// </summary>
        private void Start()
        {
            hero = new Hero(actionUpdater);
            hero.Prepare();
        }
    }
}