using System.Collections.Generic;
using _Game.Scripts.Common;
using _Game.Scripts.Common.DI;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Human.Installers
{
    public class EntityInstaller: SubInstaller
    {
        [SerializeField] private IControllableEntityMono _entity;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IControllableEntityMono>()
                .FromInstance(_entity)
                .AsSingle();
            container
                .Bind<IControllableEntity>()
                .FromFactory<EntityFactory>()
                .AsSingle()
                .NonLazy();
            
        }
    }

    public class EntityFactory : IFactory<IControllableEntity>
    {
        private List<IEnableable> _enableableComponents;
        private IControllableEntityMono _enableableComponentsContainer;

        public EntityFactory(List<IEnableable> enableableComponents, IControllableEntityMono enableableComponentsContainer)
        {
            _enableableComponents = enableableComponents;
            _enableableComponentsContainer = enableableComponentsContainer;
        }

        public IControllableEntity Create()
        {
            _enableableComponentsContainer.SetComponents(_enableableComponents);
            return _enableableComponentsContainer;
        }
    }
}