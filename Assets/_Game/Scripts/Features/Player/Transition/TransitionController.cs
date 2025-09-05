using System;
using System.Collections.Generic;
using _Game.Scripts.Common;
using _Game.Scripts.Core.InputModule;
using _Game.Scripts.Utilities;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Player.Transition
{
    public class TransitionController: IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private ITriggerEventInvoker _triggerEventInvoker;
        private readonly List<IControllableEntity> _entityBuffer;
        private IControllableEntity _currentEntity;
        public TransitionController(IInputService inputService, List<IControllableEntity> entityBuffer)
        {
            _inputService = inputService;
            _entityBuffer = entityBuffer;
        }
        
        public void Initialize()
        {
            _inputService.OnSwitchEntityPressed += TrySwitchFirstEntity;
            TrySwitchFirstEntity();
        }

        private void TrySwitchFirstEntity()
        {
            if (_entityBuffer.Count > 0)
            {
                SetEntity(_entityBuffer[0]);
                ResetTrigger();
            }
        }

        private void SetEntity(IControllableEntity entity)
        {
            _currentEntity?.StopControl();
            _currentEntity = entity;
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
            {
                Debug.LogError($"{_currentEntity.EntityGameObject.name} has no trigger event invoker");
            }
        }

        private void OnTriggerExit(Collider2D col)
        {
            if (ItIsEntityAndBufferDoesntContain(col, out IControllableEntity entity))
                _entityBuffer.Add(entity);
        }

        private bool ItIsEntityAndBufferDoesntContain(Collider2D col, out IControllableEntity entity) =>
            col.TryGetComponent(out entity) && !_entityBuffer.Contains(entity);

        private void OnTriggerEnter(Collider2D col)
        {
            if (ItIsEntityAndBufferDoesntContain(col, out IControllableEntity entity))
                _entityBuffer.Remove(entity);
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