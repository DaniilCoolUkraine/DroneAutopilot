using System;
using DroneAutopilot.General;

namespace DroneAutopilot.Utils
{
    public class ForceCalculator : IForceCalculator
    {
        public float RpsToForce(float rotation)
        {
            if (rotation == Constants.IDLE_SPEED)
            {
                return Constants.IDLE_FORCE;
            }

            if (rotation == Constants.UP_SPEED)
            {
                return Constants.UP_FORCE;
            }

            if (rotation == Constants.DOWN_SPEED)
            {
                return Constants.DOWN_FORCE;
            }
            
            throw new NotImplementedException("Unknown speed");
        }
    }
}