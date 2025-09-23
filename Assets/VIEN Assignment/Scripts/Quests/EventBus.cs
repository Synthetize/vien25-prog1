using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> Subscribers = new();

    public static void Subscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (!Subscribers.ContainsKey(type))
        {
            Subscribers[type] = new List<Delegate>();
        }
        Subscribers[type].Add(callback);
    }

    public static void Unsubscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var subscriber)) return;
        subscriber.Remove(callback);
        if (Subscribers[type].Count == 0)
        {
            Subscribers.Remove(type);
        }
    }

    public static void Publish<T>(T eventData)
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var subscriber)) return;
        foreach (var callback in subscriber)
        {
            ((Action<T>)callback)?.Invoke(eventData);
        }
    }
}