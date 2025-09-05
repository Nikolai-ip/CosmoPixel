using System;
using _Game.Scripts.Common;
using _Game.Scripts.Common.Movement;
using _Game.Scripts.Core.InputModule;
using Zenject;

namespace _Game.Scripts.Features.Entity
{
    public class EntityMovementController: IDisposable, ITickable, IEnableable
    {
        private IInputService _inputService;
        private readonly IMovementController _movementController;
        private readonly IDirectionLookable _playerLookable;
        private bool _enabled;
        public EntityMovementController(IMovementController movementController, IDirectionLookable playerLookable, IInputService inputService)
        {
            _movementController = movementController;
            _playerLookable = playerLookable;
            _inputService = inputService;
        }

        public void Enable()
        {
            _inputService.OnMovePressed +=  _playerLookable.LookAt;
            _enabled = true;
        }
        public void Disable()
        {
            _inputService.OnMovePressed -=  _playerLookable.LookAt;
            _enabled = false;
        }
        public void Tick()
        {
            if (_enabled)
                _movementController.Move(_inputService.MoveDirection);
        }
        public void Dispose()
        {
            _inputService.OnMovePressed -=  _playerLookable.LookAt;
        }
    }

}