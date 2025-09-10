using _Game.Scripts.Core.DI;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.Entity.Installers
{
    public class EntityAnimationInstaller: SubInstaller
    {
        [SerializeField] private Animator _animator;
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<Animator>()
                .FromInstance(_animator)
                .AsSingle();
            
            container
                .BindInterfacesTo<EntityAnimatorController>()
                .AsCached();
        }
    }
}