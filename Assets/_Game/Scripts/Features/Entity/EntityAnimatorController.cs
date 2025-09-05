using System;
using _Game.Scripts.Common.Movement;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity
{
    public class EntityAnimatorController: IInitializable, IDisposable
    {
        private readonly Animator _animator;
        private readonly IMovementController _movementController;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private const float MOVEMENT_FOR_PLAY_ANIMATION = 0.2f;
        
        public EntityAnimatorController(Animator animator, IMovementController movementController)
        {
            _animator = animator;
            _movementController = movementController;
        }

        public void Initialize()
        {
            _movementController.OnMove += PlayMoveAnimation;
        }

        private void PlayMoveAnimation(Vector2 movement)
        {
            _animator.SetBool(IsMoving, movement.magnitude > MOVEMENT_FOR_PLAY_ANIMATION);
        }
        

        public void Dispose()
        {
            _movementController.OnMove -= PlayMoveAnimation;
        }
    }
}