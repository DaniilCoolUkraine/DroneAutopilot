namespace DroneAutopilot.General
{
    public class Constants
    {
        public const float IDLE_SPEED = 1000;
        public const float UP_SPEED = 1010;
        public const float DOWN_SPEED = 0;

        public const int SCREWS_COUNT = 4;
        
        public const float UP_FORCE = 12f / SCREWS_COUNT;
        public const float IDLE_FORCE = 9.81f / SCREWS_COUNT;
        public const float DOWN_FORCE = 0;

        public const float REWARD_FOR_FLOOR_COLLIDING = -0.0051f;
        public const float REWARD_FOR_GETTING_HIGHER = 0.5f;
        public const float REWARD_FOR_STAYING_UP = 0.005f;

        public const float TOLERANCE = 0.1f;
    }
}