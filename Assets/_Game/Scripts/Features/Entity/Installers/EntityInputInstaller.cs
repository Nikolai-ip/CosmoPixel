using _Game.Scripts.Core.DI;
using _Game.Scripts.Core.Events;
using _Game.Scripts.InputModule;
using Zenject;

namespace _Game.Scripts.Features.Entity.Installers
{
    public class EntityInputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesAndSelfTo<InputSignalsInvoker>()
                .AsSingle();
            
            container
                .Bind<IEventBus>()
                .To<AdaptedEventBus>()
                .AsSingle()
                .WithArguments(new EventBusLocal());
        }
    }
}