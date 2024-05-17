using DroneAutopilot.General;
using UnityEngine;

namespace DroneAutopilot.AI
{
    public class Ground : MonoBehaviour, IObstacle
    {
        public float GetReward => Constants.REWARD_FOR_FLOOR_COLLIDING;
    }
}