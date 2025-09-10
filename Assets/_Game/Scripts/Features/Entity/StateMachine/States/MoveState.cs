using _Game.Scripts.Common.Movement;
using _Game.Scripts.Core.Events;
using _Game.Scripts.Core.StateMachine;
using _Game.Scripts.Features.Entity.StateMachine.Signals;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game.Scripts.Features.Entity.StateMachine.States
{
    public class MoveState: IPayLoadedState<MoveParams>, ISignalHandler<MoveSignal>
    {
        private readonly IMovementController _movementController;
        private readonly IDirectionLookable _playerLookable;
        private StateMachineBase _sm;
        private readonly IEventBus _inputEventBus;
        public MoveState(IMovementController movementController, IDirectionLookable playerLookable, IEventBus inputEventBus)
        {
            _movementController = movementController;
            _playerLookable = playerLookable;
            _inputEventBus = inputEventBus;
        }

        public void SetStateMachine(StateMachineBase sm)
        {
            _sm = sm;
        }

        public void Enter(MoveParams payload)
        {
            _inputEventBus.Subscribe<MoveSignal>(this);
        }
        
        public void Exit()
        {
            _inputEventBus.Remove<MoveSignal>(this);
        }
        
        public void HandleSignal(MoveSignal signal)
        {
            _movementController.Move(signal.MoveParams.Dir);
            if (signal.Phase == InputActionPhase.Canceled)
                _sm.Enter<IdleState>();
            else
                _playerLookable.LookAt(signal.MoveParams.Dir);
        }
    }
}