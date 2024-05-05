using DroneAutopilot.General;
using DroneAutopilot.InputReader;
using UnityEngine;

namespace DroneAutopilot.DroneControls
{
    public class DroneInputController : MonoBehaviour
    {
        public float TopRightRps { get; private set; }
        public float BottomRightRps { get; private set; }
        public float TopLeftRps { get; private set; }
        public float BottomLeftRps { get; private set; }
        
        private ISingleInputCalculator _topRightInputCalculator;
        private ISingleInputCalculator _bottomRightInputCalculator;
        private ISingleInputCalculator _topLeftInputCalculator;
        private ISingleInputCalculator _bottomLeftInputCalculator;
        
        public void Init(ISingleInputCalculator topRightInputCalculator, ISingleInputCalculator bottomRightInputCalculator,
            ISingleInputCalculator topLeftInputCalculator, ISingleInputCalculator bottomLeftInputCalculator)
        {
            _topRightInputCalculator = topRightInputCalculator;
            _bottomRightInputCalculator = bottomRightInputCalculator;
            _topLeftInputCalculator = topLeftInputCalculator;
            _bottomLeftInputCalculator = bottomLeftInputCalculator;
        }

        public void Init()
        {
            _topRightInputCalculator = new TopRightInputCalculator();
            _bottomRightInputCalculator = new BottomRightInputCalculator();
            _topLeftInputCalculator = new TopLeftInputCalculator();
            _bottomLeftInputCalculator = new BottomLeftInputCalculator();
        }

        private void Update()
        {
            TopRightRps = _topRightInputCalculator.Calculate() ? Constants.UP_SPEED : Constants.DOWN_SPEED;
            BottomRightRps = _bottomRightInputCalculator.Calculate() ? Constants.UP_SPEED : Constants.DOWN_SPEED;
            TopLeftRps = _topLeftInputCalculator.Calculate() ? Constants.UP_SPEED : Constants.DOWN_SPEED;
            BottomLeftRps = _bottomLeftInputCalculator.Calculate() ? Constants.UP_SPEED : Constants.DOWN_SPEED;
        }
    }
}