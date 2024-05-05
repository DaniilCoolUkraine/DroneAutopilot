using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class BottomLeftInputCalculator: ISingleInputCalculator
    {
        public bool Calculate()
        {
            return Input.GetKey(KeyCode.S);
        }
    }
}