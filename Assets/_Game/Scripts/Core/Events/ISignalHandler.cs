namespace _Game.Scripts.Common.Events
{
    public interface ISignalHandler<in T> where T : ISignal
    {
        void HandleSignal(T signal);
    }
}