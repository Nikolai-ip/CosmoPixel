using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game.Scripts.InputModule
{
    public interface IInputService
    {
        event Action OnSwitchEntityPressed;
        event Action<Vector2, InputActionPhase> OnMove;
    }
}