using DroneAutopilot.InputReader;

namespace DroneAutopilot.AI.InputSubstitution
{
    public class AiInputCalculator : ISingleInputCalculator
    {
        private bool _isPressed;

        public void SimulatePress(bool isPressed)
        {
            _isPressed = isPressed;
        }
        
        public bool Calculate()
        {
            return _isPressed;
        }
    }
}