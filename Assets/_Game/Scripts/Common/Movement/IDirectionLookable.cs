using UnityEngine;

namespace _Game.Scripts.Common.Movement
{
    public interface IDirectionLookable
    {
        void LookAt(Vector2 targetPosition);
    }
}