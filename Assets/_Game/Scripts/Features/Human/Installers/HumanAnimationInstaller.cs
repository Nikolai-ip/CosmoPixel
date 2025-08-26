using _Game.Scripts.Common.DI;
using _Game.Scripts.Features.Human.Controllers;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Human.Installers
{
    public class HumanAnimationInstaller: SubInstaller
    {
        [SerializeField] private Animator _animator;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<Animator>()
                .FromInstance(_animator)
                .AsSingle();
            
            container
                .BindInterfacesTo<PlayerAnimatorController>()
                .AsCached();
            
            
        }
    }
}