namespace _Game.Scripts.Core.Events
{
    public interface ISignalHandler<in T> where T : ISignal
    {
        void HandleSignal(T signal);
    }
}