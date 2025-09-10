using System;
using UnityEngine;

namespace _Game.Scripts.Common.Movement
{
    public class SmoothMoveController : MonoBehaviour, IMovementController
    {
        [SerializeField] private Rigidbody2D _rb;

        [Header("Movement Settings")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _acceleration = 10f;
        [SerializeField] private float _deceleration = 15f;
        [SerializeField] private float _decelerationThreshold = 0.1f;
        [SerializeField] private float _velPower = 1.5f;
        private Vector2 _moveInput;
        public event Action<Vector2> OnMove;

        public void Move(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }

        private void FixedUpdate()
        {
            Vector2 targetVelocity = _moveInput * _speed;
            Vector2 velocityDelta = targetVelocity - _rb.linearVelocity;

            float accelRate = (velocityDelta.magnitude > _decelerationThreshold) ? _acceleration : _deceleration;
            velocityDelta *= accelRate;

            Vector2 poweredDiff = new(
                Mathf.Pow(Mathf.Abs(velocityDelta.x), _velPower) * Mathf.Sign(velocityDelta.x),
                Mathf.Pow(Mathf.Abs(velocityDelta.y), _velPower) * Mathf.Sign(velocityDelta.y)
            );

            if (poweredDiff.magnitude < 0.1f)
                poweredDiff = Vector2.zero;

            _rb.AddForce(poweredDiff);
            OnMove?.Invoke(_rb.linearVelocity);
        }
    }

}