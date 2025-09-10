using System.Collections.Generic;
using _Game.Scripts.Common;
using _Game.Scripts.Core.DI;
using _Game.Scripts.Features.Player.Transition;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Player.Installers
{
    public class PlayerInstaller: SubInstaller
    {
        [SerializeField] private IControllableEntityMono _defaultEntity;

        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IEntityBufferSorter>()
                .To<ByDistanceEntityContainerSorter>()
                .AsSingle();
            
            container
                .BindInterfacesTo<EntityContainer>()
                .AsSingle()
                .WithArguments(new List<IControllableEntity>() { _defaultEntity });
            
            container
                .BindInterfacesAndSelfTo<TransitionController>()
                .AsSingle();
        }
    }
}