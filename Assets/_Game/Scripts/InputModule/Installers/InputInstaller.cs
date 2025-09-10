using _Game.Scripts.Common.DI;
using _Game.Scripts.Common.Events;
using Zenject;

namespace _Game.Scripts.Core.InputModule.Installers
{
    public class InputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesTo<PCNewInputSystemInputService>()
                .AsSingle();
            
            container
                .BindInterfacesAndSelfTo<InputSignalsInvoker>()
                .AsSingle();
            
            container
                .Bind<IEventBus>()
                .To<AdaptedEventBus>()
                .AsSingle()
                .WithArguments(new EventBusLocal());
            
            container
                .Bind<IPointerDirection>()
                .To<MousePointerDirection>()
                .AsSingle();    
        }
    }
}