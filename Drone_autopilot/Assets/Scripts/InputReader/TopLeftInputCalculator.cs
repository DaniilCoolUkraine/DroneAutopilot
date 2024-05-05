using UnityEngine;

namespace DroneAutopilot.InputReader
{
    public class TopLeftInputCalculator: ISingleInputCalculator
    {
        public bool Calculate()
        {
            return Input.GetKey(KeyCode.A);
        }
    }
}