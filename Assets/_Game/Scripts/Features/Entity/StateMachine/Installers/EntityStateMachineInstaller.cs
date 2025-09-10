using System;
using System.Collections.Generic;
using _Game.Scripts.Common;
using _Game.Scripts.Common.DI;
using _Game.Scripts.Common.StateMachine;
using _Game.Scripts.Features.Human;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity.StateMachine
{
    public class EntityStateMachineInstaller: SubInstaller
    {
        [SerializeField] private StatesFactory _stateMachineFactory;
        [SerializeField] private StateMachineRunner _stateMachineRunner;
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
                .Bind<StateMachineRunner>()
                .FromInstance(_stateMachineRunner)
                .AsSingle();
        }
    }
}