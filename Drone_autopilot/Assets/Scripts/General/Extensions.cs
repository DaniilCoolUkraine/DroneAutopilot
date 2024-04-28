using System;
using System.Collections.Generic;

namespace DroneAutopilot.General
{
    public static class Extensions
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action.Invoke(element);
            }
        }
    }
}