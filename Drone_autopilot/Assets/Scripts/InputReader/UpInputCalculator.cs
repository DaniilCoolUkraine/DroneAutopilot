using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class UpInputCalculator : ISingleInputCalculator
    {
        public int Calculate()
        {
            if (Input.GetKey(KeyCode.E))
                return 1;

            return 0;
        }
    }
}