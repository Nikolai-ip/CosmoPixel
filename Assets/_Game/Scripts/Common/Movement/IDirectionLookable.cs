using UnityEngine;

namespace _Game.Scripts.Common
{
    public interface IDirectionLookable
    {
        void LookAt(Vector2 targetPosition);
    }
}