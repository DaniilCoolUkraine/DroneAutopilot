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

        public static bool ToBool(this int num)
        {
            return num > 0;
        }

        public static bool[] ToBool(this int[] nums)
        {
            bool[] result = new bool[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i].ToBool();
            }

            return result;
        }
    }
}