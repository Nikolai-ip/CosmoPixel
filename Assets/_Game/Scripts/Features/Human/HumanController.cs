using System;
using _Game.Scripts.Common;
using _Game.Scripts.Core.InputModule;
using Zenject;

namespace _Game.Scripts.Features.Human
{
    public class HumanController: IDisposable, ITickable
    {
        private IInputService _inputService;
        private readonly IMovementController _movementController;
        private readonly IDirectionLookable _playerLookable;
        
        public HumanController(IMovementController movementController,IDirectionLookable playerLookable)
        {
            _movementController = movementController;
            _playerLookable = playerLookable;
        }

        public void SetInputService(IInputService service)
        {
            _inputService = service;
            _inputService.OnMovePressed +=  _playerLookable.LookAt;
        }
        public void Tick()
        {
            if (_inputService != null)
                _movementController.Move(_inputService.MoveDirection);
        }
        public void Dispose()
        {
            if (_inputService != null)
                _inputService.OnMovePressed -=  _playerLookable.LookAt;
        }
    }

}