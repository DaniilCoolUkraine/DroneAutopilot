using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class DownForceCalculator : ISingleInputCalculator
    {
        public int Calculate()
        {
            if (Input.GetKey(KeyCode.Q))
                return 1;

            return 0;
        }
    }
}