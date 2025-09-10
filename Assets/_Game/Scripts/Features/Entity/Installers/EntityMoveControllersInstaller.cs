using _Game.Scripts.Common.Movement;
using _Game.Scripts.Core.DI;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity.Installers
{
    public class EntityMoveControllersInstaller: SubInstaller
    {
        [SerializeField] private SmoothMoveController _movementController;
        [SerializeField] private Transform _entity;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IMovementController>()
                .FromInstance(_movementController)
                .AsSingle();

            container.Bind<Transform>()
                .FromInstance(_entity)
                .AsSingle();
            
            container
                .Bind<IDirectionLookable>()
                .To<HorizontalFlipper>().
                AsSingle();
        }
    }

}