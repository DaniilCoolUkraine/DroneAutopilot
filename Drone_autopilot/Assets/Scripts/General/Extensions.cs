using System;
using System.Collections.Generic;
using UnityEngine;

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

        public static bool VectorsApproximatelyEquals(this Vector3 me, Vector3 vector, float similarity)
        {
            if (Math.Abs(me.x - vector.x) > similarity)
            {
                return false;
            }

            if (Math.Abs(me.y - vector.y) > similarity)
            {
                return false;
            }
            
            if (Math.Abs(me.z - vector.z) > similarity)
            {
                return false;
            }

            return true;
        }
    }
}