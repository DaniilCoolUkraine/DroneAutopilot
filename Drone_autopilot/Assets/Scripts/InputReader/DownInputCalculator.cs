using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class DownInputCalculator : ISingleInputCalculator
    {
        public int Calculate()
        {
            if (Input.GetKey(KeyCode.Q))
                return 1;

            return 0;
        }
    }
}