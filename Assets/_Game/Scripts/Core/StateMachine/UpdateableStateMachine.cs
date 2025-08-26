using UnityEngine;
using Zenject;

namespace _Game.Scripts.Core.StateMachine
{
    public class UpdateableStateMachine: StateMachineBase, ITickable
    {
        private IUpdatableState _updatableState;
        protected override void Enter<TState>()
        {
            base.Enter<TState>();
            SetUpdateableState();
        }

        protected override void Enter<TState, TPayLoad>(TPayLoad payLoad)
        {
            base.Enter<TState, TPayLoad>(payLoad);
            SetUpdateableState();
        }

        private void SetUpdateableState()
        {
            if (_currentState is IUpdatableState updateableState)
            {
                _updatableState = updateableState;
            }
            else
            {
                Debug.LogWarning($"{_currentState.GetType().Name} is not an IUpdatableState");
            }
        }

        public void Tick()
        {
            _updatableState?.Update();
        }
    }
}