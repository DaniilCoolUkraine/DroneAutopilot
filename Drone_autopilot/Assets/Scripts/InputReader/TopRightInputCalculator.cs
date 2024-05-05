using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class TopRightInputCalculator : ISingleInputCalculator
    {
        public bool Calculate()
        {
            return Input.GetKey(KeyCode.W);
        }
    }
}