using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Game.Scripts.Core.InputModule
{

    [Obsolete]
    public class PCInputService : IInputService, ITickable
    {
        public Vector2 MoveDirection =>
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        public event Action OnSwitchEntityPressed;
        public event Action<Vector2, InputActionPhase> OnMove;

        public event Action<Vector2> OnMovePressed;
        public event Action<Vector2> OnMoveUnpressed;   
        bool _movePressed;

        public void Tick()
        {
            if (MoveDirection.magnitude != 0)
            {
                _movePressed = true;
                OnMovePressed?.Invoke(MoveDirection);
            }

            if (MoveDirection.magnitude == 0 && _movePressed)
            {
                _movePressed = false;
                OnMoveUnpressed?.Invoke(MoveDirection);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                OnSwitchEntityPressed?.Invoke();
            }
        }
    }

}