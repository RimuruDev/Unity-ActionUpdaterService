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
using RimuruDev.Internal.Codebase.ActionUpdater.Service;

namespace RimuruDev.Internal.Codebase.Example
{
    public sealed class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.Bind<IActionUpdaterService>().To<ActionUpdaterService>().AsSingle();
    }
}