using System;
using _Game.Scripts.Common;
using _Game.Scripts.Core.Events;
using _Game.Scripts.Features.Entity.StateMachine.Signals;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.InputModule
{
    public class InputSignalsInvoker: IInitializable, IDisposable, IEnableable
    {
        private readonly IInputService _inputService;
        private readonly IEventBus _inputSignalsEventBus;
        private readonly MoveSignal _moveSignal = new();
        private bool _enabled;

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
            if (!_enabled) return;
            _moveSignal.Phase = phase;
            _moveSignal.MoveParams.Dir = dir;
            _inputSignalsEventBus.RiseEvent(_moveSignal);
        }
        
        public void Dispose()
        {
            _inputService.OnMove -= InvokeMoveSignal;
        }


        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;
    }
}