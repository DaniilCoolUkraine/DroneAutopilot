using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class MovementDirectionCalculator : IVectorInputCalculator
    {
        public Vector2 Calculate()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}