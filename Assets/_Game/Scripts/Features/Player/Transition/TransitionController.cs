using System;
using _Game.Scripts.Common;
using _Game.Scripts.InputModule;
using _Game.Scripts.Utilities;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Player.Transition
{
    public class TransitionController: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly IEntityContainer _entityContainer;
        private readonly IEntityBuffer _entityBuffer;
        private readonly IEntityBufferSorter  _entityBufferSorter;
        private IControllableEntity _currentEntity;
        private ITriggerEventInvoker _triggerEventInvoker;

        public TransitionController(IInputService inputService, IEntityContainer entityContainer, IEntityBuffer entityBuffer, IEntityBufferSorter entityBufferSorter)
        {
            _inputService = inputService;
            _entityContainer = entityContainer;
            _entityBufferSorter = entityBufferSorter;
            _entityBuffer = entityBuffer;
        }
        
        public void Initialize()
        {
            _inputService.OnSwitchEntityPressed += TrySwitchFirstEntity;
            TrySwitchFirstEntity();
        }

        private void TrySwitchFirstEntity()
        {
            _entityBufferSorter.Sort(_entityBuffer, _currentEntity);
            if (_entityContainer.TryGetEntity(out var entity))
            {
                SetEntity(entity);
                ResetTrigger();
                
            }
        }

        private void SetEntity(IControllableEntity entity)
        {
            _currentEntity?.StopControl();
            _currentEntity = entity;
            Debug.Log($"Switch entity on {entity.EntityGameObject.name}");
            _currentEntity.StartControl();
        }

        private void ResetTrigger()
        {
            var triggerEventInvoker = _currentEntity.EntityGameObject.GetComponentInChildren<ITriggerEventInvoker>();
            if (triggerEventInvoker != null)
            {
                _triggerEventInvoker = triggerEventInvoker;
                _triggerEventInvoker.OnTriggerEnter += OnTriggerEnter;
                _triggerEventInvoker.OnTriggerExit += OnTriggerExit;
            }
            else
                Debug.LogError($"{_currentEntity.EntityGameObject.name} has no trigger event invoker");
            
        }

        private void OnTriggerEnter(Collider2D col)
        {
            if (col.TryGetComponent(out IControllableEntity entity))
                _entityContainer.TryAddEntity(entity);

        }
        private void OnTriggerExit(Collider2D col)
        {
            if (col.TryGetComponent(out IControllableEntity entity))
                _entityContainer.TryRemove(entity);
        }



        public void Dispose()
        {
            if (_triggerEventInvoker != null)
            {
                _triggerEventInvoker.OnTriggerEnter -= OnTriggerEnter;
                _triggerEventInvoker.OnTriggerExit -= OnTriggerExit;
            }
            _inputService.OnSwitchEntityPressed -= TrySwitchFirstEntity;
        }
    }
}