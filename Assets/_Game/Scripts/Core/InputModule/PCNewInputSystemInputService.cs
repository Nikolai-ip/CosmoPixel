using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.Core.InputModule
{
    public class PCNewInputSystemInputService: IInputService, IInitializable, IDisposable, ITickable
    {
        public Vector2 MoveDirection { get; private set; }
        public event Action OnSwitchEntityPressed;
        public event Action<Vector2> OnMovePressed;
        public event Action<Vector2> OnMoveUnpressed;
        private InputScheme _inputScheme = new();

        public void Initialize()
        {
            _inputScheme.ControlScheme.SwitchEntity.performed += OnSwitchEntity;
            _inputScheme.ControlScheme.Move.performed += OnMove;
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            MoveDirection = ctx.ReadValue<Vector2>();
            Debug.Log("PCNewInputSystemInputService.OnMovePressed");
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
            Debug.Log("Pressed Switch Entity");
            OnSwitchEntityPressed?.Invoke();
        }

        public void Dispose()
        {
            _inputScheme.ControlScheme.SwitchEntity.performed -= OnSwitchEntity;
            _inputScheme.ControlScheme.Move.performed -= OnMove;
        }

        public void Tick()
        {
            MoveDirection = _inputScheme.ControlScheme.Move.ReadValue<Vector2>();
            Debug.Log(MoveDirection);
        }
    }
}