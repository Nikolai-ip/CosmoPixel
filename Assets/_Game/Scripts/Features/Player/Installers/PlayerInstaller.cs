using System.Collections.Generic;
using _Game.Scripts.Common;
using _Game.Scripts.Common.DI;
using _Game.Scripts.Features.Player.Transition;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Player
{
    public class PlayerInstaller: SubInstaller
    {
        [SerializeField] private IControllableEntityMono _defaultEntity;

        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesAndSelfTo<TransitionController>()
                .AsSingle()
                .WithArguments(new List<IControllableEntity>() { _defaultEntity });        
        }
    }
}