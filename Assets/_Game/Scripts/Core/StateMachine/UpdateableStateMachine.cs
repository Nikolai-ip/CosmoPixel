using System;
using System.Collections.Generic;
using _Game.Scripts.Common.Events;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Common.StateMachine
{
    public class UpdateableStateMachine: StateMachineBase, ITickable
    {
        private IUpdatableState _updatableState;

        public UpdateableStateMachine(Dictionary<Type, IExitableState> states) : base(states)
        { }

        public override void Enter<TState>()
        {
            base.Enter<TState>();
            CastState<IUpdatableState>(out _updatableState);
        }   
        public override void Enter<TState, TPayLoad>(TPayLoad payLoad)
        {
            base.Enter<TState, TPayLoad>(payLoad);
            CastState<IUpdatableState>(out _updatableState);
        }
        public void Tick()
        {
            _updatableState?.Update();
        }
    }
}