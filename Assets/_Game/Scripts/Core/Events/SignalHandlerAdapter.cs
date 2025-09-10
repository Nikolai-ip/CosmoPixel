namespace _Game.Scripts.Core.Events
{
    public class SignalHandlerAdapter<T>: ISignalHandler<ISignal> where T : ISignal
    {
        private readonly ISignalHandler<T> _inner;
        public SignalHandlerAdapter(ISignalHandler<T> inner)
        {
            _inner = inner;
        }

        public void HandleSignal(ISignal signal)
        {
            _inner.HandleSignal((T)signal);
        }
    }
}