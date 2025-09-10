using System;
using System.Collections.Generic;
using _Game.Scripts.Core.DI;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Human;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity.StateMachine.Installers
{
    public class EntityStateMachineInstaller: SubInstaller
    {
        [SerializeField] private StatesFactory _stateMachineFactory;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<StatesFactory>()
                .FromInstance(_stateMachineFactory)
                .AsSingle();
            
            container
                .Bind<Dictionary<Type, IExitableState>>()
                .FromMethod(ctx=>ctx.Container.Resolve<StatesFactory>().Create())
                .AsSingle();
            
            container
                .Bind(typeof(StateMachineBase), typeof(ITickable), typeof(IInitializable))
                .To<UpdateableStateMachine>()
                .AsSingle();
            
            container
                .BindInterfacesAndSelfTo<StateMachineEnabler>()
                .AsSingle();
        }
    }
}