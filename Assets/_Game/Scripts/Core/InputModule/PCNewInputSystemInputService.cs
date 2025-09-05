using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.Core.InputModule
{
    public class PCNewInputSystemInputService: IInputService, IInitializable
    {
        public Vector2 MoveDirection { get; private set; }
        public event Action OnSwitchEntityPressed;
        public event Action<Vector2> OnMovePressed;
        public event Action<Vector2> OnMoveUnpressed;
        private readonly InputScheme _inputScheme = new();

        public void Initialize()
        {
            _inputScheme.Enable();
            _inputScheme.ControlScheme.SwitchEntity.performed += OnSwitchEntity;
            _inputScheme.ControlScheme.Move.performed += OnMove;
            _inputScheme.ControlScheme.Move.started += OnMove;
            _inputScheme.ControlScheme.Move.canceled += OnMove;
        }
        

        private void OnMove(InputAction.CallbackContext ctx)
        {
            MoveDirection = ctx.ReadValue<Vector2>();
            if (ctx.phase == InputActionPhase.Started)
            {
                OnMovePressed?.Invoke(MoveDirection);
            }

            if (ctx.phase == InputActionPhase.Canceled)
            {
                OnMoveUnpressed?.Invoke(MoveDirection);
            }
        }

        private void OnSwitchEntity(InputAction.CallbackContext ctx)
        {
            OnSwitchEntityPressed?.Invoke();
        }
    }
}