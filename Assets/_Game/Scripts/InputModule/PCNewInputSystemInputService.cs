using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.InputModule
{
    public class PCNewInputSystemInputService: IInputService, IInitializable, ITickable
    {
        public event Action OnSwitchEntityPressed;
        public event Action<Vector2, InputActionPhase> OnMove;
        private readonly InputScheme _inputScheme = new();
        private bool _isMoving;

        public void Initialize()
        {
            _inputScheme.Enable();
            _inputScheme.Player.SwitchEntity.performed += OnSwitchEntity;
            _inputScheme.Player.Move.performed += OnMoveHandle;
            _inputScheme.Player.Move.started += OnMoveHandle;
            _inputScheme.Player.Move.canceled += OnMoveHandle;
        }


        public void Tick()
        {
            if (_isMoving)
            {
                Vector2 move = _inputScheme.Player.Move.ReadValue<Vector2>();
                OnMove?.Invoke(move, InputActionPhase.Performed);
            }
        }

        private void OnMoveHandle(InputAction.CallbackContext ctx)
        {
            OnMove?.Invoke(ctx.ReadValue<Vector2>(), ctx.phase);
            if (ctx.phase == InputActionPhase.Started)
                _isMoving = true;
            else if (ctx.phase == InputActionPhase.Canceled)
                _isMoving = false;
        }

        private void OnSwitchEntity(InputAction.CallbackContext ctx)
        {
            OnSwitchEntityPressed?.Invoke();
        }
    }
}