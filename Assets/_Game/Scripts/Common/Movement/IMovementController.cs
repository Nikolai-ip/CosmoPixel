using System;
using UnityEngine;

namespace _Game.Scripts.Common.Movement
{
    public interface IMovementController
    {
        void Move(Vector2 moveInput);
        event Action<Vector2> OnMove;
    }
}