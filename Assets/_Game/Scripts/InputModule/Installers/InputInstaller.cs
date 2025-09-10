using _Game.Scripts.Core.DI;
using _Game.Scripts.Core.Events;
using Zenject;

namespace _Game.Scripts.InputModule.Installers
{
    public class InputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesTo<PCNewInputSystemInputService>()
                .AsSingle();
            
            container
                .Bind<IPointerDirection>()
                .To<MousePointerDirection>()
                .AsSingle();    
        }
    }
}