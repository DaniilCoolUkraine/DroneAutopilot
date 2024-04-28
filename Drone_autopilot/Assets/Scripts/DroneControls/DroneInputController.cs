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
        
        private ISingleInputCalculator _upForceCalculator;
        private ISingleInputCalculator _downForceCalculator;
        private IVectorInputCalculator _directionCalculator;
        
        public void Init(ISingleInputCalculator upForceCalculator, ISingleInputCalculator downForceCalculator,
            IVectorInputCalculator directionCalculator)
        {
            _upForceCalculator = upForceCalculator;
            _downForceCalculator = downForceCalculator;
            _directionCalculator = directionCalculator;
        }

        public void Init()
        {
            _upForceCalculator = new UpInputCalculator();
            _downForceCalculator = new DownInputCalculator();
            _directionCalculator = new MovementDirectionCalculator();
        }
        
        private void Update()
        {
            int upForceInput = _upForceCalculator.Calculate();
            int downForceInput = _downForceCalculator.Calculate();

            Vector2 direction = _directionCalculator.Calculate();

            if (upForceInput > downForceInput)
            {
                TopRightRps = Constants.UP_SPEED;
                BottomRightRps = Constants.UP_SPEED;
                TopLeftRps = Constants.UP_SPEED;
                BottomLeftRps = Constants.UP_SPEED;
            }
            else if (upForceInput < downForceInput)
            {
                TopRightRps = Constants.DOWN_SPEED;
                BottomRightRps = Constants.DOWN_SPEED;
                TopLeftRps = Constants.DOWN_SPEED;
                BottomLeftRps = Constants.DOWN_SPEED;
            }

            if (upForceInput == downForceInput)
            {
                TopRightRps = 0;
                BottomRightRps = 0;
                TopLeftRps = 0;
                BottomLeftRps = 0;
            }

            if (direction.x == 1)
            {
                TopRightRps = Constants.IDLE_SPEED;
                TopLeftRps = Constants.IDLE_SPEED;

                BottomRightRps = Constants.UP_SPEED;
                BottomLeftRps = Constants.UP_SPEED;
            }
            else if (direction.x == -1)
            {
                TopRightRps = Constants.UP_SPEED;
                TopLeftRps = Constants.UP_SPEED;

                BottomRightRps = Constants.IDLE_SPEED;
                BottomLeftRps = Constants.IDLE_SPEED;
            }

            if (direction.y == 1)
            {
                TopRightRps = Constants.IDLE_SPEED;
                BottomRightRps = Constants.IDLE_SPEED;

                TopLeftRps = Constants.UP_SPEED;
                BottomLeftRps = Constants.UP_SPEED;
            }
            if (direction.y == -1)
            {
                TopRightRps = Constants.UP_SPEED;
                BottomRightRps = Constants.UP_SPEED;

                TopLeftRps = Constants.IDLE_SPEED;
                BottomLeftRps = Constants.IDLE_SPEED;
            }

            if (direction.x == 0)
            {
                
            }
        }
    }
}