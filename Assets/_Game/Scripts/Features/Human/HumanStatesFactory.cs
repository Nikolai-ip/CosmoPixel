using System;
using System.Collections.Generic;
using _Game.Scripts.Common.Movement;
using _Game.Scripts.Core.Events;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine.States;
using Zenject;

namespace _Game.Scripts.Features.Human
{
    public class HumanStatesFactory: StatesFactory
    {
        private IMovementController _entityMovementController;
        private IDirectionLookable _directionLookable;
        private IEventBus _inputEventBus;

        [Inject]
        public void Construct(IMovementController entityMovementController, IDirectionLookable directionLookable, IEventBus inputEventBus)
        {
            _entityMovementController = entityMovementController;
            _directionLookable = directionLookable;
            _inputEventBus = inputEventBus;
        }

        public override Dictionary<Type, IExitableState> Create()
        {
            return new Dictionary<Type, IExitableState>()
            {
                { typeof(DisabledStateMachineState), new DisabledStateMachineState()},
                { typeof(IdleState),  new IdleState(_inputEventBus)},
                { typeof(MoveState),  new MoveState(_entityMovementController, _directionLookable, _inputEventBus)}
            };
        }
    }
}