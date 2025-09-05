using _Game.Scripts.Common.DI;
using Zenject;

namespace _Game.Scripts.Core.InputModule.Installers
{
    public class InputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            // container
            //     .BindInterfacesTo<PCInputService>()
            //     .AsSingle();
            //
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