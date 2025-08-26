using _Game.Scripts.Common.DI;
using _Game.Scripts.Core.InputModule;
using Zenject;

namespace _Game.Scripts.Features.Human.Installers
{
    public class PlayerInputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesTo<PCInputService>()
                .AsSingle();
            
            container
                .Bind<IPointerDirection>()
                .To<MousePointerDirection>()
                .AsSingle();
        }
    }
}