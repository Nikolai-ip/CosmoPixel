namespace _Game.Scripts.Common.Events
{
    public interface IEventBus
    {
        void Subscribe<T>(ISignalHandler<T> handler) where T : ISignal;
        void Remove<T>(ISignalHandler<T> handler) where T : ISignal;
        void RiseEvent<T>(T signal) where T : ISignal;
    }
}