using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public interface IVectorInputCalculator
    {
        /// <summary>
        /// Calculates movement direction based on user input
        /// </summary>
        /// <returns>Vector2 where:
        /// "W" press returns 1
        /// "S" press returns -1
        /// "D" press returns 1
        /// "A" press returns -1
        /// </returns>
        public Vector2 Calculate();
    }
}