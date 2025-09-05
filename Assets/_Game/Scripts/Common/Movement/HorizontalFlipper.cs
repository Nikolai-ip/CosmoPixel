using UnityEngine;

namespace _Game.Scripts.Common.Movement
{
    public class HorizontalFlipper : IDirectionLookable
    {
        private readonly Transform _transform;

        public HorizontalFlipper(Transform transform)
        {
            _transform = transform;
        }

        public void LookAt(Vector2 targetPosition)
        {
            _transform.localScale = new Vector3(Mathf.Sign(targetPosition.x), _transform.localScale.y, _transform.localScale.z);
        }
    }
}