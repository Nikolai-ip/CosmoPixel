using UnityEngine;

namespace _Game.Scripts.Core.InputModule
{
    public class MousePointerDirection : IPointerDirection
    {
        private readonly Camera _camera;

        public MousePointerDirection(Camera camera)
        {
            _camera = camera;
        }

        public Vector2 GetDirection()
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            return (Vector2)(mousePosition - _camera.transform.position).normalized;
        }
    }

}