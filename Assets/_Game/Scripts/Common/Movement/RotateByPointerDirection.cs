using _Game.Scripts.Core.InputModule;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Common.Movement
{
    public class RotateByPointerDirection
    {
        private readonly IPointerDirection _pointerDirection;
        private readonly Transform _rotatableTr;
        
        [Inject(Id = "Rotatable")]
        public RotateByPointerDirection(IPointerDirection pointerDirection, Transform rotatableTr)
        {
            _pointerDirection = pointerDirection;
            _rotatableTr = rotatableTr;
        }

        public void Rotate()
        {
            Vector2 direction = _pointerDirection.GetDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rotatableTr.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}