using System;
using System.Collections.Generic;

namespace Assets.Scripts.EventBus
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public static void Subscribe<TEvent>(Action<TEvent> callback) where TEvent : IEvent
        {
            var type = typeof(TEvent);
            if (!_subscribers.ContainsKey(type))
                _subscribers[type] = new List<Delegate>();

            _subscribers[type].Add(callback);
        }

        public static void Unsubscribe<TEvent>(Action<TEvent> callback) where TEvent : IEvent
        {
            var type = typeof(TEvent);
            if (_subscribers.TryGetValue(type, out var list))
            {
                list.Remove(callback);
                if (list.Count == 0)
                    _subscribers.Remove(type);
            }
        }

        public static void Raise<TEvent>(TEvent evt) where TEvent : IEvent
        {
            var type = typeof(TEvent);
            if (_subscribers.TryGetValue(type, out var list))
            {
                foreach (var callback in list)
                {
                    (callback as Action<TEvent>)?.Invoke(evt);
                }
            }
        }

        public static void ClearAll()
        {
            _subscribers.Clear();
        }
    }
}
