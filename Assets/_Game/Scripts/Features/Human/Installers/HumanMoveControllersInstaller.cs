using _Game.Scripts.Common;
using _Game.Scripts.Common.DI;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Human.Installers
{
    public class HumanMoveControllersInstaller: SubInstaller
    {
        [SerializeField] private SmoothMoveController _movementController;
        [SerializeField] private Transform _player;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IMovementController>()
                .FromInstance(_movementController)
                .AsSingle();

            container.Bind<Transform>()
                .FromInstance(_player)
                .AsSingle();
            
            container
                .Bind<IDirectionLookable>()
                .To<HorizontalFlipper>().
                AsSingle();
            
            container
                .BindInterfacesAndSelfTo<HumanController>()
                .AsSingle();
        }
    }
}