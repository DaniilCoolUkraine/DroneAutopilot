using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class BottomRightInputCalculator: ISingleInputCalculator
    {
        public bool Calculate()
        {
            return Input.GetKey(KeyCode.D);
        }
    }
}