using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public interface IVectorInputCalculator
    {
        public Vector2 Calculate();
    }
}