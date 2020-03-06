using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DomainModel
{
    public static class DomainEvents
    {
        private static AsyncLocal<List<Delegate>> actions; // Do not initialize

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new AsyncLocal<List<Delegate>>();
                actions.Value = new List<Delegate>();
            }
            actions.Value.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (actions == null)
            {
                return;
            }
            foreach (var action in actions.Value.OfType<Action<T>>())
            {
                ((Action<T>)action).Invoke(args);
            }
        }
    }
}