using System;
using System.Collections.Generic;
using _Game.Scripts.Common.Events;
using _Game.Scripts.Features.Entity.StateMachine.Signals;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.Core.InputModule
{
    public class InputSignalsInvoker: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly IEventBus _inputSignalsEventBus;
        private readonly MoveSignal _moveSignal = new();

        public InputSignalsInvoker(IInputService inputService, IEventBus inputSignalsEventBus)
        {
            _inputService = inputService;
            _inputSignalsEventBus = inputSignalsEventBus;
        }
        public void Initialize()
        {
            _inputService.OnMove += InvokeMoveSignal;
        }
        
        private void InvokeMoveSignal(Vector2 dir, InputActionPhase phase)
        {
            _moveSignal.Phase = phase;
            _moveSignal.MoveParams.Dir = dir;
            _inputSignalsEventBus.RiseEvent(_moveSignal);
        }
        
        public void Dispose()
        {
            _inputService.OnMove -= InvokeMoveSignal;
        }


    }
}