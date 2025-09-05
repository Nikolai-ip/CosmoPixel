using System.Collections.Generic;
using _Game.Scripts.Common;
using UnityEngine;

namespace _Game.Scripts.Features.Entity
{
    public class EntityComponentsController: IControllableEntityMono
    {
        private List<IEnableable> _enableableComponents;
        public override void SetComponents(List<IEnableable> enableableComponents)
        {
            _enableableComponents = enableableComponents;
            _enableableComponents ??= new List<IEnableable>();
        }
        
        public override void StartControl()
        {
            foreach (var component in _enableableComponents)
                component.Enable();
        }
        public override void StopControl()
        {
            foreach (var component in _enableableComponents)
                component.Disable();
            
        }

        public override GameObject EntityGameObject => gameObject;
    }
}