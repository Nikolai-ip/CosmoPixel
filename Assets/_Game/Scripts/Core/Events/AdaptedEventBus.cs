using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Common.Events
{
    public class AdaptedEventBus: IEventBus
    {
        private readonly IEventBus _eventBus;

        private readonly Dictionary<object, ISignalHandler<ISignal>> _adaptedListeners = new();

        public AdaptedEventBus(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Subscribe<T>(ISignalHandler<T> handler) where T : ISignal
        {
            var signalHandlerAdapter = new SignalHandlerAdapter<T>(handler);
            if (!_adaptedListeners.ContainsKey(handler))
            {
                _adaptedListeners[handler] = signalHandlerAdapter;
                _eventBus.Subscribe<T>(signalHandlerAdapter as ISignalHandler<T>);
            }
            else
            {
                Debug.LogWarning($"{handler} already registered to event {typeof(T).Name}");
            }
        }

        public void Remove<T>(ISignalHandler<T> handler) where T : ISignal
        {
            if (_adaptedListeners.TryGetValue(handler, out var signalHandlerAdapter))
            {
                _eventBus.Remove<T>(signalHandlerAdapter as ISignalHandler<T>);
                _adaptedListeners.Remove(handler);
            }
            else
            {
                Debug.LogWarning($"{handler} does not subscribe to event {typeof(T).Name}");
            }
        }

        public void RiseEvent<T>(T signal) where T : ISignal
        {
            _eventBus.RiseEvent(signal);
        }
    }
}