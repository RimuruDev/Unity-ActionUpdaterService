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

namespace RimuruDev.Internal.Codebase.ActionUpdater.Enum
{
    /// <summary>
    /// Specifies the type of update method to which an action can be subscribed.
    /// </summary>
    [Serializable]
    public enum UpdateType : byte
    {
        /// <summary>
        /// Subscribe to the FixedUpdate method, which is called every fixed framerate frame.
        /// Suitable for updates in physics calculations.
        /// </summary>
        FixedUpdate = 0,

        /// <summary>
        /// Subscribe to the Update method, which is called once per frame.
        /// Suitable for most game logic.
        /// </summary>
        Update = 1,

        /// <summary>
        /// Subscribe to the LateUpdate method, which is called once per frame after Update.
        /// Suitable for actions that require objects to be updated first.
        /// </summary>
        LateUpdate = 2,
    }
}