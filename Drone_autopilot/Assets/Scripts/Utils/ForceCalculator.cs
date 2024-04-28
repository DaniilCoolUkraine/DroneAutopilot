using System;
using DroneAutopilot.General;

namespace DroneAutopilot.Utils
{
    public class ForceCalculator
    {
        public float RpsToForce(float rotation)
        {
            if (rotation == Constants.IDLE_SPEED)
            {
                return 9.81f;
            }

            if (rotation == Constants.UP_SPEED)
            {
                return 10f;
            }

            if (rotation == Constants.DOWN_SPEED)
            {
                return 9.6f;
            }
            
            throw new NotImplementedException();
        }
    }
}