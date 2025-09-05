using System;
using UnityEngine;

namespace _Game.Scripts.Core.InputModule
{
    public interface IInputService
    {
        Vector2 MoveDirection { get; }
        event Action OnSwitchEntityPressed;
        event Action<Vector2> OnMovePressed;
        event Action<Vector2> OnMoveUnpressed;   
    }
}